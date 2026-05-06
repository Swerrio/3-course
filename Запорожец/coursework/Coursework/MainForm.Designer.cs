namespace Coursework
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLeftMain = new System.Windows.Forms.FlowLayoutPanel();
            this.loggedInAs = new System.Windows.Forms.Label();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnRentals = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.lblStatusDatabase = new System.Windows.Forms.Label();
            this.pnlStatsMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStatsRevenue = new System.Windows.Forms.Button();
            this.btnStatsPopular = new System.Windows.Forms.Button();
            this.btnStatsExport = new System.Windows.Forms.Button();
            this.pnlRentMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRentNew = new System.Windows.Forms.Button();
            this.btnRentReturn = new System.Windows.Forms.Button();
            this.btnRentActive = new System.Windows.Forms.Button();
            this.btnRentOverdue = new System.Windows.Forms.Button();
            this.pnlClientsMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClientAdd = new System.Windows.Forms.Button();
            this.btnClientEdit = new System.Windows.Forms.Button();
            this.btnClientHistory = new System.Windows.Forms.Button();
            this.btnClientBlacklist = new System.Windows.Forms.Button();
            this.pnlInventoryMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInvAdd = new System.Windows.Forms.Button();
            this.btnInvEdit = new System.Windows.Forms.Button();
            this.btnInvDelete = new System.Windows.Forms.Button();
            this.btnInvStatus = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.btnInvSearch = new System.Windows.Forms.Button();
            this.pnlLeftAir = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlLeftMain.SuspendLayout();
            this.pnlStatsMenu.SuspendLayout();
            this.pnlRentMenu.SuspendLayout();
            this.pnlClientsMenu.SuspendLayout();
            this.pnlInventoryMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeftMain
            // 
            this.pnlLeftMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlLeftMain.Controls.Add(this.loggedInAs);
            this.pnlLeftMain.Controls.Add(this.btnInventory);
            this.pnlLeftMain.Controls.Add(this.btnClients);
            this.pnlLeftMain.Controls.Add(this.btnRentals);
            this.pnlLeftMain.Controls.Add(this.btnStatistic);
            this.pnlLeftMain.Controls.Add(this.btnLeave);
            this.pnlLeftMain.Controls.Add(this.lblStatusDatabase);
            this.pnlLeftMain.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMain.Name = "pnlLeftMain";
            this.pnlLeftMain.Size = new System.Drawing.Size(293, 228);
            this.pnlLeftMain.TabIndex = 0;
            // 
            // loggedInAs
            // 
            this.loggedInAs.AutoSize = true;
            this.loggedInAs.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loggedInAs.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.loggedInAs.Location = new System.Drawing.Point(3, 0);
            this.loggedInAs.Name = "loggedInAs";
            this.loggedInAs.Size = new System.Drawing.Size(217, 20);
            this.loggedInAs.TabIndex = 5;
            this.loggedInAs.Text = "Вы вошли как:  admin          ";
            // 
            // btnInventory
            // 
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInventory.Location = new System.Drawing.Point(3, 23);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(287, 29);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "Инвентарь";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnClients
            // 
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnClients.Location = new System.Drawing.Point(3, 58);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(287, 29);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnRentals
            // 
            this.btnRentals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentals.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRentals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRentals.Location = new System.Drawing.Point(3, 93);
            this.btnRentals.Name = "btnRentals";
            this.btnRentals.Size = new System.Drawing.Size(287, 29);
            this.btnRentals.TabIndex = 2;
            this.btnRentals.Text = "Прокаты";
            this.btnRentals.UseVisualStyleBackColor = true;
            this.btnRentals.Click += new System.EventHandler(this.btnRentals_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistic.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStatistic.Location = new System.Drawing.Point(3, 128);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(287, 29);
            this.btnStatistic.TabIndex = 3;
            this.btnStatistic.Text = "Статистика";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeave.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLeave.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLeave.Location = new System.Drawing.Point(3, 163);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(287, 29);
            this.btnLeave.TabIndex = 4;
            this.btnLeave.Text = "Выход";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // lblStatusDatabase
            // 
            this.lblStatusDatabase.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatusDatabase.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatusDatabase.Location = new System.Drawing.Point(3, 195);
            this.lblStatusDatabase.Name = "lblStatusDatabase";
            this.lblStatusDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatusDatabase.Size = new System.Drawing.Size(287, 27);
            this.lblStatusDatabase.TabIndex = 1;
            this.lblStatusDatabase.Text = "База данных: Неизвестно";
            this.lblStatusDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatsMenu
            // 
            this.pnlStatsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlStatsMenu.Controls.Add(this.btnStatsRevenue);
            this.pnlStatsMenu.Controls.Add(this.btnStatsPopular);
            this.pnlStatsMenu.Controls.Add(this.btnStatsExport);
            this.pnlStatsMenu.Location = new System.Drawing.Point(3, 240);
            this.pnlStatsMenu.Name = "pnlStatsMenu";
            this.pnlStatsMenu.Size = new System.Drawing.Size(290, 347);
            this.pnlStatsMenu.TabIndex = 5;
            this.pnlStatsMenu.Visible = false;
            // 
            // btnStatsRevenue
            // 
            this.btnStatsRevenue.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatsRevenue.Location = new System.Drawing.Point(3, 3);
            this.btnStatsRevenue.Name = "btnStatsRevenue";
            this.btnStatsRevenue.Size = new System.Drawing.Size(284, 26);
            this.btnStatsRevenue.TabIndex = 2;
            this.btnStatsRevenue.Text = "Выручка за период";
            this.btnStatsRevenue.UseVisualStyleBackColor = true;
            this.btnStatsRevenue.Click += new System.EventHandler(this.btnStatsRevenue_Click);
            // 
            // btnStatsPopular
            // 
            this.btnStatsPopular.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatsPopular.Location = new System.Drawing.Point(3, 35);
            this.btnStatsPopular.Name = "btnStatsPopular";
            this.btnStatsPopular.Size = new System.Drawing.Size(284, 26);
            this.btnStatsPopular.TabIndex = 3;
            this.btnStatsPopular.Text = "Популярный товар";
            this.btnStatsPopular.UseVisualStyleBackColor = true;
            this.btnStatsPopular.Click += new System.EventHandler(this.btnStatsPopular_Click);
            // 
            // btnStatsExport
            // 
            this.btnStatsExport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatsExport.Location = new System.Drawing.Point(3, 67);
            this.btnStatsExport.Name = "btnStatsExport";
            this.btnStatsExport.Size = new System.Drawing.Size(284, 26);
            this.btnStatsExport.TabIndex = 4;
            this.btnStatsExport.Text = "Отчет в Excel";
            this.btnStatsExport.UseVisualStyleBackColor = true;
            this.btnStatsExport.Click += new System.EventHandler(this.btnStatsExport_Click);
            // 
            // pnlRentMenu
            // 
            this.pnlRentMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlRentMenu.Controls.Add(this.btnRentNew);
            this.pnlRentMenu.Controls.Add(this.btnRentReturn);
            this.pnlRentMenu.Controls.Add(this.btnRentActive);
            this.pnlRentMenu.Controls.Add(this.btnRentOverdue);
            this.pnlRentMenu.Location = new System.Drawing.Point(3, 240);
            this.pnlRentMenu.Name = "pnlRentMenu";
            this.pnlRentMenu.Size = new System.Drawing.Size(290, 347);
            this.pnlRentMenu.TabIndex = 4;
            this.pnlRentMenu.Visible = false;
            // 
            // btnRentNew
            // 
            this.btnRentNew.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRentNew.Location = new System.Drawing.Point(3, 3);
            this.btnRentNew.Name = "btnRentNew";
            this.btnRentNew.Size = new System.Drawing.Size(284, 26);
            this.btnRentNew.TabIndex = 1;
            this.btnRentNew.Text = "Оформить прокат";
            this.btnRentNew.UseVisualStyleBackColor = true;
            this.btnRentNew.Click += new System.EventHandler(this.btnRentNew_Click);
            // 
            // btnRentReturn
            // 
            this.btnRentReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRentReturn.Location = new System.Drawing.Point(3, 35);
            this.btnRentReturn.Name = "btnRentReturn";
            this.btnRentReturn.Size = new System.Drawing.Size(284, 26);
            this.btnRentReturn.TabIndex = 2;
            this.btnRentReturn.Text = "Принять возврат";
            this.btnRentReturn.UseVisualStyleBackColor = true;
            this.btnRentReturn.Click += new System.EventHandler(this.btnRentReturn_Click);
            // 
            // btnRentActive
            // 
            this.btnRentActive.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRentActive.Location = new System.Drawing.Point(3, 67);
            this.btnRentActive.Name = "btnRentActive";
            this.btnRentActive.Size = new System.Drawing.Size(284, 26);
            this.btnRentActive.TabIndex = 3;
            this.btnRentActive.Text = "Текущие аренды";
            this.btnRentActive.UseVisualStyleBackColor = true;
            // 
            // btnRentOverdue
            // 
            this.btnRentOverdue.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRentOverdue.Location = new System.Drawing.Point(3, 99);
            this.btnRentOverdue.Name = "btnRentOverdue";
            this.btnRentOverdue.Size = new System.Drawing.Size(284, 26);
            this.btnRentOverdue.TabIndex = 4;
            this.btnRentOverdue.Text = "Просроченные";
            this.btnRentOverdue.UseVisualStyleBackColor = true;
            this.btnRentOverdue.Click += new System.EventHandler(this.btnRentOverdue_Click);
            // 
            // pnlClientsMenu
            // 
            this.pnlClientsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlClientsMenu.Controls.Add(this.btnClientAdd);
            this.pnlClientsMenu.Controls.Add(this.btnClientEdit);
            this.pnlClientsMenu.Controls.Add(this.btnClientHistory);
            this.pnlClientsMenu.Controls.Add(this.btnClientBlacklist);
            this.pnlClientsMenu.Location = new System.Drawing.Point(3, 240);
            this.pnlClientsMenu.Name = "pnlClientsMenu";
            this.pnlClientsMenu.Size = new System.Drawing.Size(290, 347);
            this.pnlClientsMenu.TabIndex = 3;
            this.pnlClientsMenu.Visible = false;
            // 
            // btnClientAdd
            // 
            this.btnClientAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClientAdd.Location = new System.Drawing.Point(3, 3);
            this.btnClientAdd.Name = "btnClientAdd";
            this.btnClientAdd.Size = new System.Drawing.Size(284, 26);
            this.btnClientAdd.TabIndex = 1;
            this.btnClientAdd.Text = "Регистрация клиента";
            this.btnClientAdd.UseVisualStyleBackColor = true;
            this.btnClientAdd.Click += new System.EventHandler(this.btnClientAdd_Click);
            // 
            // btnClientEdit
            // 
            this.btnClientEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClientEdit.Location = new System.Drawing.Point(3, 35);
            this.btnClientEdit.Name = "btnClientEdit";
            this.btnClientEdit.Size = new System.Drawing.Size(284, 26);
            this.btnClientEdit.TabIndex = 2;
            this.btnClientEdit.Text = "Изменить данные";
            this.btnClientEdit.UseVisualStyleBackColor = true;
            this.btnClientEdit.Click += new System.EventHandler(this.btnClientEdit_Click);
            // 
            // btnClientHistory
            // 
            this.btnClientHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClientHistory.Location = new System.Drawing.Point(3, 67);
            this.btnClientHistory.Name = "btnClientHistory";
            this.btnClientHistory.Size = new System.Drawing.Size(284, 26);
            this.btnClientHistory.TabIndex = 3;
            this.btnClientHistory.Text = "История прокатов";
            this.btnClientHistory.UseVisualStyleBackColor = true;
            this.btnClientHistory.Click += new System.EventHandler(this.btnClientHistory_Click);
            // 
            // btnClientBlacklist
            // 
            this.btnClientBlacklist.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClientBlacklist.Location = new System.Drawing.Point(3, 99);
            this.btnClientBlacklist.Name = "btnClientBlacklist";
            this.btnClientBlacklist.Size = new System.Drawing.Size(284, 26);
            this.btnClientBlacklist.TabIndex = 4;
            this.btnClientBlacklist.Text = "В черный список";
            this.btnClientBlacklist.UseVisualStyleBackColor = true;
            this.btnClientBlacklist.Click += new System.EventHandler(this.btnClientBlacklist_Click);
            // 
            // pnlInventoryMenu
            // 
            this.pnlInventoryMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlInventoryMenu.Controls.Add(this.btnInvAdd);
            this.pnlInventoryMenu.Controls.Add(this.btnInvEdit);
            this.pnlInventoryMenu.Controls.Add(this.btnInvDelete);
            this.pnlInventoryMenu.Controls.Add(this.btnInvStatus);
            this.pnlInventoryMenu.Controls.Add(this.searchTextBox);
            this.pnlInventoryMenu.Controls.Add(this.btnInvSearch);
            this.pnlInventoryMenu.Location = new System.Drawing.Point(3, 240);
            this.pnlInventoryMenu.Name = "pnlInventoryMenu";
            this.pnlInventoryMenu.Size = new System.Drawing.Size(290, 347);
            this.pnlInventoryMenu.TabIndex = 2;
            this.pnlInventoryMenu.Visible = false;
            // 
            // btnInvAdd
            // 
            this.btnInvAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInvAdd.Location = new System.Drawing.Point(3, 3);
            this.btnInvAdd.Name = "btnInvAdd";
            this.btnInvAdd.Size = new System.Drawing.Size(284, 26);
            this.btnInvAdd.TabIndex = 0;
            this.btnInvAdd.Text = "Добавить товар";
            this.btnInvAdd.UseVisualStyleBackColor = true;
            this.btnInvAdd.Click += new System.EventHandler(this.btnInvAdd_Click);
            // 
            // btnInvEdit
            // 
            this.btnInvEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInvEdit.Location = new System.Drawing.Point(3, 35);
            this.btnInvEdit.Name = "btnInvEdit";
            this.btnInvEdit.Size = new System.Drawing.Size(284, 26);
            this.btnInvEdit.TabIndex = 1;
            this.btnInvEdit.Text = "Изменить";
            this.btnInvEdit.UseVisualStyleBackColor = true;
            this.btnInvEdit.Click += new System.EventHandler(this.btnInvEdit_Click);
            // 
            // btnInvDelete
            // 
            this.btnInvDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInvDelete.Location = new System.Drawing.Point(3, 67);
            this.btnInvDelete.Name = "btnInvDelete";
            this.btnInvDelete.Size = new System.Drawing.Size(284, 26);
            this.btnInvDelete.TabIndex = 2;
            this.btnInvDelete.Text = "Списать/Удалить";
            this.btnInvDelete.UseVisualStyleBackColor = true;
            this.btnInvDelete.Click += new System.EventHandler(this.btnInvDelete_Click);
            // 
            // btnInvStatus
            // 
            this.btnInvStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInvStatus.Location = new System.Drawing.Point(3, 99);
            this.btnInvStatus.Name = "btnInvStatus";
            this.btnInvStatus.Size = new System.Drawing.Size(284, 26);
            this.btnInvStatus.TabIndex = 3;
            this.btnInvStatus.Text = "В ремонт / Из ремонта";
            this.btnInvStatus.UseVisualStyleBackColor = true;
            this.btnInvStatus.Click += new System.EventHandler(this.btnInvStatus_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(3, 131);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(158, 38);
            this.searchTextBox.TabIndex = 5;
            // 
            // btnInvSearch
            // 
            this.btnInvSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnInvSearch.Location = new System.Drawing.Point(167, 131);
            this.btnInvSearch.Name = "btnInvSearch";
            this.btnInvSearch.Size = new System.Drawing.Size(120, 38);
            this.btnInvSearch.TabIndex = 4;
            this.btnInvSearch.Text = "Поиск по названию";
            this.btnInvSearch.UseVisualStyleBackColor = true;
            this.btnInvSearch.Click += new System.EventHandler(this.btnInvSearch_Click);
            // 
            // pnlLeftAir
            // 
            this.pnlLeftAir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlLeftAir.Location = new System.Drawing.Point(3, 240);
            this.pnlLeftAir.Name = "pnlLeftAir";
            this.pnlLeftAir.Size = new System.Drawing.Size(290, 347);
            this.pnlLeftAir.TabIndex = 6;
            this.pnlLeftAir.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(299, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(996, 587);
            this.dgvData.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1294, 588);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlLeftAir);
            this.Controls.Add(this.pnlLeftMain);
            this.Controls.Add(this.pnlStatsMenu);
            this.Controls.Add(this.pnlRentMenu);
            this.Controls.Add(this.pnlClientsMenu);
            this.Controls.Add(this.pnlInventoryMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.pnlLeftMain.ResumeLayout(false);
            this.pnlLeftMain.PerformLayout();
            this.pnlStatsMenu.ResumeLayout(false);
            this.pnlRentMenu.ResumeLayout(false);
            this.pnlClientsMenu.ResumeLayout(false);
            this.pnlInventoryMenu.ResumeLayout(false);
            this.pnlInventoryMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlLeftMain;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Label loggedInAs;
        private System.Windows.Forms.Label lblStatusDatabase;
        private System.Windows.Forms.FlowLayoutPanel pnlStatsMenu;
        private System.Windows.Forms.Button btnStatsRevenue;
        private System.Windows.Forms.Button btnStatsPopular;
        private System.Windows.Forms.Button btnStatsExport;
        private System.Windows.Forms.FlowLayoutPanel pnlRentMenu;
        private System.Windows.Forms.Button btnRentNew;
        private System.Windows.Forms.Button btnRentReturn;
        private System.Windows.Forms.Button btnRentActive;
        private System.Windows.Forms.Button btnRentOverdue;
        private System.Windows.Forms.FlowLayoutPanel pnlClientsMenu;
        private System.Windows.Forms.Button btnClientAdd;
        private System.Windows.Forms.Button btnClientEdit;
        private System.Windows.Forms.Button btnClientHistory;
        private System.Windows.Forms.Button btnClientBlacklist;
        private System.Windows.Forms.FlowLayoutPanel pnlInventoryMenu;
        private System.Windows.Forms.Button btnInvAdd;
        private System.Windows.Forms.Button btnInvEdit;
        private System.Windows.Forms.Button btnInvDelete;
        private System.Windows.Forms.Button btnInvStatus;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button btnInvSearch;
        private System.Windows.Forms.FlowLayoutPanel pnlLeftAir;
        private System.Windows.Forms.DataGridView dgvData;
    }
}