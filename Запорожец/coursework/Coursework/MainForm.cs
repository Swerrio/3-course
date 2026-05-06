using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Coursework
{
    public partial class MainForm : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=12qwasZX;Database=Coursework";
        private NpgsqlDataAdapter adapter;
        private DataTable dt;

        public MainForm()
        {
            InitializeComponent();
            ShowSection(pnlLeftAir);
            UpdateDatabaseStatus();
            LoadGlobalStats();

            dgvData.AllowUserToAddRows = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.DefaultValuesNeeded += dgvData_DefaultValuesNeeded;
            dgvData.MultiSelect = false;
        }

        #region Система навигации

        private void ShowSection(Panel selectedPanel)
        {
            Panel[] allMenus = { pnlInventoryMenu, pnlClientsMenu, pnlRentMenu, pnlStatsMenu };
            foreach (var menu in allMenus) menu.Visible = false;
            selectedPanel.Visible = true;
            selectedPanel.BringToFront();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ShowSection(pnlInventoryMenu);
            LoadDataWithUpdateSupport("SELECT item_id, model_name, hourly_rate, status FROM inventory");
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ShowSection(pnlClientsMenu);
            LoadDataWithUpdateSupport("SELECT client_id, full_name, phone, passport_data, is_blacklisted FROM clients");
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            ShowSection(pnlRentMenu);
            LoadDataWithUpdateSupport("SELECT rental_id, client_id, item_id, start_time, end_time_planned, total_price FROM rentals");
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            ShowSection(pnlStatsMenu);
            LoadGlobalStats();
            LoadDataWithUpdateSupport("SELECT * FROM rentals ORDER BY start_time DESC LIMIT 15");
        }

        #endregion

        #region Основная Логика (Сохранение, Удаление, Обновление)

        private void SaveChanges()
        {
            if (dt == null) return;

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    if (adapter != null)
                    {
                        adapter.SelectCommand.Connection = conn;
                        NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adapter);
                        adapter.Update(dt);
                        RefreshCurrentTab();
                        MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGlobalStats();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void RefreshCurrentTab()
        {
            if (pnlInventoryMenu.Visible) btnInventory_Click(null, null);
            else if (pnlClientsMenu.Visible) btnClients_Click(null, null);
            else if (pnlRentMenu.Visible) btnRentals_Click(null, null);
            else if (pnlStatsMenu.Visible) btnStatistic_Click(null, null); // Имя исправлено здесь
        }

        private void DeleteSelectedRows()
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Удалить выбранные записи?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvData.SelectedRows)
                    {
                        if (!row.IsNewRow) dgvData.Rows.Remove(row);
                    }
                    SaveChanges();
                }
            }
        }

        #endregion

        private void dgvData_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Если мы во вкладке инвентаря
            if (pnlInventoryMenu.Visible)
            {
                // Проверяем наличие колонки перед записью, чтобы избежать Exception
                if (dgvData.Columns.Contains("status"))
                {
                    e.Row.Cells["status"].Value = "available";
                }
            }
            // Если мы во вкладке клиентов
            else if (pnlClientsMenu.Visible)
            {
                if (dgvData.Columns.Contains("is_blacklisted"))
                {
                    e.Row.Cells["is_blacklisted"].Value = false;
                }
            }
        }

        #region Дополнительные функции (Черный список, Экспорт, Статистика)

        private void btnClientBlacklist_Click(object sender, EventArgs e)
        {
            // Используем CurrentRow — это та строка, где сейчас находится курсор/фокус
            if (dgvData.CurrentRow != null && !dgvData.CurrentRow.IsNewRow)
            {
                var row = dgvData.CurrentRow;

                // Завершаем редактирование, если пользователь что-то печатал
                dgvData.EndEdit();

                var clientId = row.Cells["client_id"].Value;
                if (clientId == DBNull.Value) return;

                // Используем COALESCE, чтобы если в базе NULL, он превратился в false и кнопка сработала
                string sql = $@"UPDATE clients 
                        SET is_blacklisted = NOT COALESCE(is_blacklisted, false) 
                        WHERE client_id = {clientId}";

                ExecuteNonQuery(sql);
                RefreshCurrentTab();

                MessageBox.Show("Статус ЧС изменен.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента в таблице.");
            }
        }

        private void btnStatsExport_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV файл (*.csv)|*.csv", FileName = "Report_" + DateTime.Now.ToString("yyyyMMdd_HHmm") };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dgvData.Columns.Count; i++)
                        sb.Append(dgvData.Columns[i].HeaderText + (i == dgvData.Columns.Count - 1 ? "" : ";"));
                    sb.AppendLine();

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.IsNewRow) continue;
                        for (int i = 0; i < dgvData.Columns.Count; i++)
                            sb.Append(row.Cells[i].Value?.ToString().Replace(";", " ") + (i == dgvData.Columns.Count - 1 ? "" : ";"));
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Данные экспортированы.");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка экспорта: " + ex.Message); }
            }
        }

        private void btnInvStatus_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                var row = dgvData.SelectedRows[0];
                // Проверяем наличие item_id (он в первой колонке согласно твоему SELECT)
                if (row.Cells[0].Value == DBNull.Value) return;

                int itemId = Convert.ToInt32(row.Cells[0].Value);
                string currentStatus = row.Cells["status"].Value?.ToString() ?? "available";
                string newStatus = (currentStatus == "available") ? "repair" : "available";

                // Прямое обновление в базе
                string sql = $"UPDATE inventory SET status = '{newStatus}' WHERE item_id = {itemId}";
                ExecuteNonQuery(sql);

                RefreshCurrentTab(); // Перезагружаем таблицу, чтобы увидеть изменения
            }
            else
            {
                MessageBox.Show("Выберите строку в таблице инвентаря.");
            }
        }

        private void btnClientHistory_Click(object sender, EventArgs e) // Привяжи к кнопке в меню прокатов
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                // Берем client_id из таблицы rentals
                var clientId = dgvData.SelectedRows[0].Cells["client_id"].Value;
                if (clientId != DBNull.Value)
                {
                    ShowSection(pnlRentMenu);
                    LoadDataWithUpdateSupport($"SELECT * FROM rentals WHERE client_id = {clientId}");
                    MessageBox.Show($"Показана история для клиента ID: {clientId}");
                }
            }
        }

        private void btnStatsRevenue_Click(object sender, EventArgs e)
        {
            string start = Prompt.ShowDialog("Начало (ГГГГ-ММ-ДД):", "Выручка");
            string end = Prompt.ShowDialog("Конец (ГГГГ-ММ-ДД):", "Выручка");

            if (!string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    // ФИКС: Приводим start_time к типу date перед сравнением 
                    // или сравниваем с началом следующего дня
                    string sql = @"
                SELECT SUM(total_price) 
                FROM rentals 
                WHERE start_time::date >= @start::date 
                  AND start_time::date <= @end::date";

                    var cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("start", start);
                    cmd.Parameters.AddWithValue("end", end);

                    var res = cmd.ExecuteScalar();

                    // Обработка случая, если выручка 0 (результат будет DBNull)
                    decimal totalRevenue = (res == DBNull.Value) ? 0 : Convert.ToDecimal(res);

                    MessageBox.Show($"Выручка за период с {start} по {end}: {totalRevenue} руб.");
                }
            }
        }

        private void btnRentOverdue_Click(object sender, EventArgs e)
        {
            ShowSection(pnlRentMenu);
            LoadDataWithUpdateSupport("SELECT * FROM rentals WHERE end_time_planned < NOW() AND end_time_actual IS NULL");
        }

        private void btnRentReturn_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && !dgvData.CurrentRow.IsNewRow)
            {
                var row = dgvData.CurrentRow;
                if (row.Cells["rental_id"].Value == null || row.Cells["rental_id"].Value == DBNull.Value) return;
                var rentalId = row.Cells["rental_id"].Value;

                // Изменяем SQL: сначала освобождаем товар, потом УДАЛЯЕМ запись проката
                string sql = $@"
            UPDATE inventory SET status = 'available' WHERE item_id = 
                (SELECT item_id FROM rentals WHERE rental_id = {rentalId} LIMIT 1);
            DELETE FROM rentals WHERE rental_id = {rentalId};";

                ExecuteNonQuery(sql);

                btnRentals_Click(null, null);
                MessageBox.Show("Товар возвращен, запись о прокате удалена.");
            }
        }

        private void btnStatsPopular_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT i.model_name, COUNT(r.rental_id) as count 
                           FROM inventory i 
                           JOIN rentals r ON i.item_id = r.item_id 
                           GROUP BY i.model_name ORDER BY count DESC LIMIT 1";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) MessageBox.Show($"Топ товар: {reader["model_name"]} ({reader["count"]} раз)");
                }
            }
        }

        #endregion

        #region Обработчики для Дизайнера (События кнопок)

        private void btnInvAdd_Click(object sender, EventArgs e) => SaveChanges();
        private void btnInvEdit_Click(object sender, EventArgs e) => SaveChanges();
        private void btnInvDelete_Click(object sender, EventArgs e) => DeleteSelectedRows();

        private void btnClientAdd_Click(object sender, EventArgs e) => SaveChanges();
        private void btnClientEdit_Click(object sender, EventArgs e) => SaveChanges();
        private void btnClientDelete_Click(object sender, EventArgs e) => DeleteSelectedRows();

        private void btnRentNew_Click(object sender, EventArgs e)
        {
            using (RentForm rf = new RentForm(connString))
            {
                if (rf.ShowDialog() == DialogResult.OK)
                {
                    btnRentals_Click(null, null);
                    LoadGlobalStats();
                }
            }
        }
        private void btnInvSearch_Click(object sender, EventArgs e) => searchTextBox_TextChanged(null, null);
        private void btnLeave_Click(object sender, EventArgs e) => Application.Exit();

        #endregion

        #region Сервисные методы БД

        private void LoadDataWithUpdateSupport(string sql)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    adapter = new NpgsqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dgvData.DataSource = dt;
                    if (dgvData.Columns.Count > 0) dgvData.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
        }

        private void ExecuteNonQuery(string sql)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                try { conn.Open(); new NpgsqlCommand(sql, conn).ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void UpdateDatabaseStatus()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                try { conn.Open(); lblStatusDatabase.Text = "БД: Онлайн"; lblStatusDatabase.ForeColor = Color.Green; }
                catch { lblStatusDatabase.Text = "БД: Оффлайн"; lblStatusDatabase.ForeColor = Color.Red; }
            }
        }

        private void LoadGlobalStats() { /* Можно добавить логику обновления лейблов с общей суммой */ }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string search = searchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                RefreshCurrentTab(); // Возвращаем все данные, если строка поиска пуста
                return;
            }

            // Поиск по инвентарю (можно расширить для других вкладок через if-else)
            if (pnlInventoryMenu.Visible)
            {
                LoadDataWithUpdateSupport($"SELECT * FROM inventory WHERE model_name ILIKE '%{search}%'");
            }
            else if (pnlClientsMenu.Visible)
            {
                LoadDataWithUpdateSupport($"SELECT * FROM clients WHERE full_name ILIKE '%{search}%'");
            }
        }

        #endregion
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form() { Width = 400, Height = 160, FormBorderStyle = FormBorderStyle.FixedDialog, Text = caption, StartPosition = FormStartPosition.CenterScreen };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "Ok", Left = 270, Width = 90, Top = 90, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textBox); prompt.Controls.Add(confirmation); prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

    public class RentForm : Form
    {
        private string _connString;
        ComboBox cbClients = new ComboBox { Left = 20, Top = 40, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
        ComboBox cbItems = new ComboBox { Left = 20, Top = 90, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
        NumericUpDown numHours = new NumericUpDown { Left = 20, Top = 140, Width = 100, Minimum = 1, Value = 1 };
        Label lblPrice = new Label { Left = 130, Top = 142, Text = "Итого: 0 руб.", Width = 150, Font = new Font("Arial", 10, FontStyle.Bold) };
        Button btnSave = new Button { Text = "Оформить", Left = 180, Top = 180, Width = 90, DialogResult = DialogResult.OK };

        public RentForm(string connString)
        {
            _connString = connString;
            this.Text = "Новый прокат";
            this.Size = new Size(320, 260);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            this.Controls.Add(new Label { Text = "Выберите клиента:", Left = 20, Top = 20, Width = 200 });
            this.Controls.Add(cbClients);
            this.Controls.Add(new Label { Text = "Выберите товар (в наличии):", Left = 20, Top = 70, Width = 200 });
            this.Controls.Add(cbItems);
            this.Controls.Add(new Label { Text = "Часы:", Left = 20, Top = 120 });
            this.Controls.Add(numHours);
            this.Controls.Add(lblPrice);
            this.Controls.Add(btnSave);

            LoadData();

            // Авторасчет при изменении товара или часов
            cbItems.SelectedIndexChanged += (s, e) => Calculate();
            numHours.ValueChanged += (s, e) => Calculate();
            btnSave.Click += BtnSave_Click;
        }

        private void LoadData()
        {
            using (var conn = new NpgsqlConnection(_connString))
            {
                conn.Open();
                // Фикс: Показываем всех, у кого НЕ true (включая тех, у кого NULL)
                var cmdClients = new NpgsqlCommand("SELECT client_id, full_name FROM clients WHERE is_blacklisted IS NOT TRUE", conn);
                using (var r = cmdClients.ExecuteReader())
                {
                    cbClients.Items.Clear(); // Очищаем перед загрузкой
                    while (r.Read()) cbClients.Items.Add(new { Id = r[0], Name = r[1].ToString() });
                }

                var cmdItems = new NpgsqlCommand("SELECT item_id, model_name, hourly_rate FROM inventory WHERE status = 'available'", conn);
                using (var r = cmdItems.ExecuteReader())
                {
                    cbItems.Items.Clear();
                    while (r.Read()) cbItems.Items.Add(new { Id = r[0], Name = r[1].ToString(), Rate = r[2] });
                }
            }
            cbClients.DisplayMember = "Name";
            cbItems.DisplayMember = "Name";
        }

        private void Calculate()
        {
            if (cbItems.SelectedItem == null) return;
            dynamic item = cbItems.SelectedItem;
            decimal total = (decimal)item.Rate * numHours.Value;
            lblPrice.Text = $"Итого: {total} руб.";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cbClients.SelectedItem == null || cbItems.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
                this.DialogResult = DialogResult.None;
                return;
            }

            dynamic client = cbClients.SelectedItem;
            dynamic item = cbItems.SelectedItem;
            decimal total = (decimal)item.Rate * numHours.Value;

            using (var conn = new NpgsqlConnection(_connString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    // 1. Создаем запись о прокате
                    var cmd = new NpgsqlCommand(@"INSERT INTO rentals (client_id, item_id, start_time, end_time_planned, total_price) 
                    VALUES (@c, @i, NOW(), NOW() + interval '1 hour' * @h, @p)", conn);
                    cmd.Parameters.AddWithValue("c", client.Id);
                    cmd.Parameters.AddWithValue("i", item.Id);
                    cmd.Parameters.AddWithValue("h", (int)numHours.Value);
                    cmd.Parameters.AddWithValue("p", total);
                    cmd.ExecuteNonQuery();

                    // 2. Меняем статус товара на 'rented'
                    var cmdUpdate = new NpgsqlCommand("UPDATE inventory SET status = 'rented' WHERE item_id = @i", conn);
                    cmdUpdate.Parameters.AddWithValue("i", item.Id);
                    cmdUpdate.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Прокат успешно оформлен!");
                }
                catch (Exception ex) { trans.Rollback(); MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }
    }
}