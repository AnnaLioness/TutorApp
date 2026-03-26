namespace TutorApp
{
    partial class FormReport
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

        private void InitializeComponent()
        {
            lblProfitCurrent = new Label();
            lblProfitChange = new Label();
            lblLessonsCount = new Label();
            lblStudentsStats = new Label();
            lblAverageCheck = new Label();
            lblWarning = new Label();
            lblTopTypes = new Label();
            lblChart = new Label();
            listTopTypes = new ListBox();
            dgvChart = new DataGridView();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblDateRange = new Label();
            ButtonWeek = new CustomControls.RJControls.RJButton();
            ButtonMonth = new CustomControls.RJControls.RJButton();
            ButtonYear = new CustomControls.RJControls.RJButton();
            ButtonExportPDF = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)dgvChart).BeginInit();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblProfitCurrent
            // 
            lblProfitCurrent.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProfitCurrent.ForeColor = Color.SteelBlue;
            lblProfitCurrent.Location = new Point(20, 220);
            lblProfitCurrent.Name = "lblProfitCurrent";
            lblProfitCurrent.Size = new Size(350, 35);
            lblProfitCurrent.TabIndex = 4;
            lblProfitCurrent.Text = "💰 Прибыль за период: —";
            // 
            // lblProfitChange
            // 
            lblProfitChange.Font = new Font("Segoe UI", 10F);
            lblProfitChange.Location = new Point(20, 260);
            lblProfitChange.Name = "lblProfitChange";
            lblProfitChange.Size = new Size(700, 25);
            lblProfitChange.TabIndex = 5;
            lblProfitChange.Text = "📊 Изменение: —";
            // 
            // lblLessonsCount
            // 
            lblLessonsCount.Font = new Font("Segoe UI", 10F);
            lblLessonsCount.Location = new Point(20, 290);
            lblLessonsCount.Name = "lblLessonsCount";
            lblLessonsCount.Size = new Size(400, 25);
            lblLessonsCount.TabIndex = 6;
            lblLessonsCount.Text = "📚 Проведено уроков: —";
            // 
            // lblStudentsStats
            // 
            lblStudentsStats.Font = new Font("Segoe UI", 10F);
            lblStudentsStats.Location = new Point(20, 320);
            lblStudentsStats.Name = "lblStudentsStats";
            lblStudentsStats.Size = new Size(400, 25);
            lblStudentsStats.TabIndex = 7;
            lblStudentsStats.Text = "👥 Активные ученики: —";
            // 
            // lblAverageCheck
            // 
            lblAverageCheck.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAverageCheck.ForeColor = Color.SteelBlue;
            lblAverageCheck.Location = new Point(20, 350);
            lblAverageCheck.Name = "lblAverageCheck";
            lblAverageCheck.Size = new Size(350, 25);
            lblAverageCheck.TabIndex = 8;
            lblAverageCheck.Text = "💳 Средний чек: —";
            // 
            // lblWarning
            // 
            lblWarning.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblWarning.ForeColor = Color.OrangeRed;
            lblWarning.Location = new Point(20, 170);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(600, 30);
            lblWarning.TabIndex = 9;
            lblWarning.TextAlign = ContentAlignment.MiddleCenter;
            lblWarning.Visible = false;
            // 
            // lblTopTypes
            // 
            lblTopTypes.AutoSize = true;
            lblTopTypes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTopTypes.ForeColor = Color.FromArgb(52, 73, 94);
            lblTopTypes.Location = new Point(20, 390);
            lblTopTypes.Name = "lblTopTypes";
            lblTopTypes.Size = new Size(282, 23);
            lblTopTypes.TabIndex = 10;
            lblTopTypes.Text = "⭐ ПОПУЛЯРНЫЕ НАПРАВЛЕНИЯ";
            // 
            // lblChart
            // 
            lblChart.AutoSize = true;
            lblChart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChart.ForeColor = Color.FromArgb(52, 73, 94);
            lblChart.Location = new Point(440, 390);
            lblChart.Name = "lblChart";
            lblChart.Size = new Size(233, 23);
            lblChart.TabIndex = 12;
            lblChart.Text = "📈 ДИНАМИКА ПРИБЫЛИ";
            // 
            // listTopTypes
            // 
            listTopTypes.BackColor = Color.FromArgb(248, 248, 248);
            listTopTypes.BorderStyle = BorderStyle.FixedSingle;
            listTopTypes.Font = new Font("Segoe UI", 9F);
            listTopTypes.FormattingEnabled = true;
            listTopTypes.Location = new Point(20, 420);
            listTopTypes.Name = "listTopTypes";
            listTopTypes.Size = new Size(380, 122);
            listTopTypes.TabIndex = 11;
            // 
            // dgvChart
            // 
            dgvChart.AllowUserToAddRows = false;
            dgvChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChart.BackgroundColor = Color.White;
            dgvChart.BorderStyle = BorderStyle.None;
            dgvChart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChart.GridColor = Color.LightGray;
            dgvChart.Location = new Point(440, 420);
            dgvChart.Name = "dgvChart";
            dgvChart.ReadOnly = true;
            dgvChart.RowHeadersVisible = false;
            dgvChart.RowHeadersWidth = 51;
            dgvChart.Size = new Size(400, 130);
            dgvChart.TabIndex = 13;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.LightSkyBlue;
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblDateRange);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(900, 80);
            headerPanel.TabIndex = 14;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(230, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(396, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 ОТЧЁТ ПО ПРИБЫЛИ";
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblDateRange.ForeColor = Color.Black;
            lblDateRange.Location = new Point(352, 50);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(160, 23);
            lblDateRange.TabIndex = 1;
            lblDateRange.Text = "Выберите период";
            // 
            // ButtonWeek
            // 
            ButtonWeek.BackColor = Color.DeepSkyBlue;
            ButtonWeek.BackgroundColor = Color.DeepSkyBlue;
            ButtonWeek.BorderColor = Color.PaleVioletRed;
            ButtonWeek.BorderRadius = 10;
            ButtonWeek.BorderSize = 0;
            ButtonWeek.FlatAppearance.BorderSize = 0;
            ButtonWeek.FlatStyle = FlatStyle.Flat;
            ButtonWeek.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonWeek.ForeColor = Color.Black;
            ButtonWeek.Location = new Point(139, 86);
            ButtonWeek.Name = "ButtonWeek";
            ButtonWeek.Size = new Size(188, 50);
            ButtonWeek.TabIndex = 15;
            ButtonWeek.Text = "📅 НЕДЕЛЯ";
            ButtonWeek.TextColor = Color.Black;
            ButtonWeek.UseVisualStyleBackColor = false;
            // 
            // ButtonMonth
            // 
            ButtonMonth.BackColor = Color.DeepSkyBlue;
            ButtonMonth.BackgroundColor = Color.DeepSkyBlue;
            ButtonMonth.BorderColor = Color.PaleVioletRed;
            ButtonMonth.BorderRadius = 10;
            ButtonMonth.BorderSize = 0;
            ButtonMonth.FlatAppearance.BorderSize = 0;
            ButtonMonth.FlatStyle = FlatStyle.Flat;
            ButtonMonth.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonMonth.ForeColor = Color.Black;
            ButtonMonth.Location = new Point(342, 86);
            ButtonMonth.Name = "ButtonMonth";
            ButtonMonth.Size = new Size(188, 50);
            ButtonMonth.TabIndex = 16;
            ButtonMonth.Text = "📆 МЕСЯЦ";
            ButtonMonth.TextColor = Color.Black;
            ButtonMonth.UseVisualStyleBackColor = false;
            // 
            // ButtonYear
            // 
            ButtonYear.BackColor = Color.DeepSkyBlue;
            ButtonYear.BackgroundColor = Color.DeepSkyBlue;
            ButtonYear.BorderColor = Color.PaleVioletRed;
            ButtonYear.BorderRadius = 10;
            ButtonYear.BorderSize = 0;
            ButtonYear.FlatAppearance.BorderSize = 0;
            ButtonYear.FlatStyle = FlatStyle.Flat;
            ButtonYear.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonYear.ForeColor = Color.Black;
            ButtonYear.Location = new Point(548, 86);
            ButtonYear.Name = "ButtonYear";
            ButtonYear.Size = new Size(188, 50);
            ButtonYear.TabIndex = 17;
            ButtonYear.Text = "📈 ГОД";
            ButtonYear.TextColor = Color.Black;
            ButtonYear.UseVisualStyleBackColor = false;
            // 
            // ButtonExportPDF
            // 
            ButtonExportPDF.BackColor = Color.LightSkyBlue;
            ButtonExportPDF.BackgroundColor = Color.LightSkyBlue;
            ButtonExportPDF.BorderColor = Color.PaleVioletRed;
            ButtonExportPDF.BorderRadius = 10;
            ButtonExportPDF.BorderSize = 0;
            ButtonExportPDF.FlatAppearance.BorderSize = 0;
            ButtonExportPDF.FlatStyle = FlatStyle.Flat;
            ButtonExportPDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonExportPDF.ForeColor = Color.Black;
            ButtonExportPDF.Location = new Point(700, 157);
            ButtonExportPDF.Name = "ButtonExportPDF";
            ButtonExportPDF.Size = new Size(188, 50);
            ButtonExportPDF.TabIndex = 18;
            ButtonExportPDF.Text = "📄 ЭКСПОРТ В PDF";
            ButtonExportPDF.TextColor = Color.Black;
            ButtonExportPDF.UseVisualStyleBackColor = false;
            ButtonExportPDF.Click += ButtonExportPDF_Click;
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(ButtonExportPDF);
            Controls.Add(ButtonYear);
            Controls.Add(ButtonMonth);
            Controls.Add(ButtonWeek);
            Controls.Add(headerPanel);
            Controls.Add(dgvChart);
            Controls.Add(lblChart);
            Controls.Add(listTopTypes);
            Controls.Add(lblTopTypes);
            Controls.Add(lblWarning);
            Controls.Add(lblAverageCheck);
            Controls.Add(lblStudentsStats);
            Controls.Add(lblLessonsCount);
            Controls.Add(lblProfitChange);
            Controls.Add(lblProfitCurrent);
            Name = "FormReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отчёт по прибыли";
            ((System.ComponentModel.ISupportInitialize)dgvChart).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblProfitCurrent;
        private System.Windows.Forms.Label lblProfitChange;
        private System.Windows.Forms.Label lblLessonsCount;
        private System.Windows.Forms.Label lblStudentsStats;
        private System.Windows.Forms.Label lblAverageCheck;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblTopTypes;
        private System.Windows.Forms.Label lblChart;
        private System.Windows.Forms.ListBox listTopTypes;
        private System.Windows.Forms.DataGridView dgvChart;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDateRange;
        private CustomControls.RJControls.RJButton ButtonWeek;
        private CustomControls.RJControls.RJButton ButtonMonth;
        private CustomControls.RJControls.RJButton ButtonYear;
        private CustomControls.RJControls.RJButton ButtonExportPDF;
    }

}
