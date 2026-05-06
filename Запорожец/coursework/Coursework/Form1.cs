using Npgsql;
using System;
using System.Windows.Forms;

namespace Coursework
{
    public partial class loginForm : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=12qwasZX;Database=Coursework";

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void CheckConnection()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к БД: " + ex.Message, "Ошибка");
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT full_name, role FROM employees WHERE login = @login AND password_hash = crypt(@pass, password_hash)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("login", login);
                        cmd.Parameters.AddWithValue("pass", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader.GetString(0);
                                string role = reader.GetString(1);

                                // Скрываем текущую форму
                                this.Hide();

                                // Создаем главную форму (MainForm) и передаем туда данные если нужно
                                MainForm mainApp = new MainForm();

                                // Передаем имя пользователя в Label на главной форме (если он public или через конструктор)
                                // mainApp.loggedInAs.Text = $"Вы вошли как: {fullName}"; 

                                // Важно: обрабатываем закрытие MainForm, чтобы закрыть все приложение целиком
                                mainApp.FormClosed += (s, args) => this.Close();

                                mainApp.Show();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы с базой данных: " + ex.Message, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}