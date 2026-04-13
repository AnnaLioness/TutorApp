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
            ButtonWeek = new CustomControls.RJControls.RJButton();
            ButtonMonth = new CustomControls.RJControls.RJButton();
            ButtonYear = new CustomControls.RJControls.RJButton();
            ButtonExportPDF = new CustomControls.RJControls.RJButton();
            lblDateRange = new Label();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChart).BeginInit();
            SuspendLayout();
            // 
            // lblProfitCurrent
            // 
            lblProfitCurrent.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblProfitCurrent.ForeColor = Color.White;
            lblProfitCurrent.Location = new Point(23, 281);
            lblProfitCurrent.Name = "lblProfitCurrent";
            lblProfitCurrent.Size = new Size(510, 35);
            lblProfitCurrent.TabIndex = 4;
            lblProfitCurrent.Text = "💰 Прибыль за период: —";
            // 
            // lblProfitChange
            // 
            lblProfitChange.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblProfitChange.ForeColor = Color.White;
            lblProfitChange.Location = new Point(23, 321);
            lblProfitChange.Name = "lblProfitChange";
            lblProfitChange.Size = new Size(700, 25);
            lblProfitChange.TabIndex = 5;
            lblProfitChange.Text = "📊 Изменение: —";
            // 
            // lblLessonsCount
            // 
            lblLessonsCount.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblLessonsCount.ForeColor = Color.White;
            lblLessonsCount.Location = new Point(23, 351);
            lblLessonsCount.Name = "lblLessonsCount";
            lblLessonsCount.Size = new Size(510, 25);
            lblLessonsCount.TabIndex = 6;
            lblLessonsCount.Text = "📚 Проведено уроков: —";
            // 
            // lblStudentsStats
            // 
            lblStudentsStats.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblStudentsStats.ForeColor = Color.White;
            lblStudentsStats.Location = new Point(23, 381);
            lblStudentsStats.Name = "lblStudentsStats";
            lblStudentsStats.Size = new Size(510, 25);
            lblStudentsStats.TabIndex = 7;
            lblStudentsStats.Text = "👥 Активные ученики: —";
            // 
            // lblAverageCheck
            // 
            lblAverageCheck.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblAverageCheck.ForeColor = Color.White;
            lblAverageCheck.Location = new Point(23, 416);
            lblAverageCheck.Name = "lblAverageCheck";
            lblAverageCheck.Size = new Size(510, 25);
            lblAverageCheck.TabIndex = 8;
            lblAverageCheck.Text = "💳 Средний чек: —";
            // 
            // lblWarning
            // 
            lblWarning.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblWarning.ForeColor = Color.OrangeRed;
            lblWarning.Location = new Point(23, 231);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(653, 30);
            lblWarning.TabIndex = 9;
            lblWarning.TextAlign = ContentAlignment.MiddleCenter;
            lblWarning.Visible = false;
            // 
            // lblTopTypes
            // 
            lblTopTypes.AutoSize = true;
            lblTopTypes.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTopTypes.ForeColor = Color.White;
            lblTopTypes.Location = new Point(23, 451);
            lblTopTypes.Name = "lblTopTypes";
            lblTopTypes.Size = new Size(276, 23);
            lblTopTypes.TabIndex = 10;
            lblTopTypes.Text = "⭐ ПОПУЛЯРНЫЕ НАПРАВЛЕНИЯ";
            // 
            // lblChart
            // 
            lblChart.AutoSize = true;
            lblChart.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblChart.ForeColor = Color.White;
            lblChart.Location = new Point(443, 451);
            lblChart.Name = "lblChart";
            lblChart.Size = new Size(227, 23);
            lblChart.TabIndex = 12;
            lblChart.Text = "📈 ДИНАМИКА ПРИБЫЛИ";
            // 
            // listTopTypes
            // 
            listTopTypes.BackColor = Color.FromArgb(248, 248, 248);
            listTopTypes.BorderStyle = BorderStyle.FixedSingle;
            listTopTypes.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            listTopTypes.FormattingEnabled = true;
            listTopTypes.Location = new Point(23, 481);
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
            dgvChart.Location = new Point(443, 481);
            dgvChart.Name = "dgvChart";
            dgvChart.ReadOnly = true;
            dgvChart.RowHeadersVisible = false;
            dgvChart.RowHeadersWidth = 51;
            dgvChart.Size = new Size(400, 130);
            dgvChart.TabIndex = 13;
            // 
            // ButtonWeek
            // 
            ButtonWeek.BackColor = Color.White;
            ButtonWeek.BackgroundColor = Color.White;
            ButtonWeek.BorderColor = Color.PaleVioletRed;
            ButtonWeek.BorderRadius = 10;
            ButtonWeek.BorderSize = 0;
            ButtonWeek.FlatAppearance.BorderSize = 0;
            ButtonWeek.FlatStyle = FlatStyle.Flat;
            ButtonWeek.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ButtonWeek.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonWeek.Location = new Point(156, 149);
            ButtonWeek.Name = "ButtonWeek";
            ButtonWeek.Size = new Size(188, 50);
            ButtonWeek.TabIndex = 15;
            ButtonWeek.Text = "📅 НЕДЕЛЯ";
            ButtonWeek.TextColor = Color.FromArgb(70, 119, 207);
            ButtonWeek.UseVisualStyleBackColor = false;
            // 
            // ButtonMonth
            // 
            ButtonMonth.BackColor = Color.White;
            ButtonMonth.BackgroundColor = Color.White;
            ButtonMonth.BorderColor = Color.PaleVioletRed;
            ButtonMonth.BorderRadius = 10;
            ButtonMonth.BorderSize = 0;
            ButtonMonth.FlatAppearance.BorderSize = 0;
            ButtonMonth.FlatStyle = FlatStyle.Flat;
            ButtonMonth.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ButtonMonth.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonMonth.Location = new Point(359, 149);
            ButtonMonth.Name = "ButtonMonth";
            ButtonMonth.Size = new Size(188, 50);
            ButtonMonth.TabIndex = 16;
            ButtonMonth.Text = "📆 МЕСЯЦ";
            ButtonMonth.TextColor = Color.FromArgb(70, 119, 207);
            ButtonMonth.UseVisualStyleBackColor = false;
            // 
            // ButtonYear
            // 
            ButtonYear.BackColor = Color.White;
            ButtonYear.BackgroundColor = Color.White;
            ButtonYear.BorderColor = Color.PaleVioletRed;
            ButtonYear.BorderRadius = 10;
            ButtonYear.BorderSize = 0;
            ButtonYear.FlatAppearance.BorderSize = 0;
            ButtonYear.FlatStyle = FlatStyle.Flat;
            ButtonYear.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ButtonYear.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonYear.Location = new Point(565, 149);
            ButtonYear.Name = "ButtonYear";
            ButtonYear.Size = new Size(188, 50);
            ButtonYear.TabIndex = 17;
            ButtonYear.Text = "📈 ГОД";
            ButtonYear.TextColor = Color.FromArgb(70, 119, 207);
            ButtonYear.UseVisualStyleBackColor = false;
            // 
            // ButtonExportPDF
            // 
            ButtonExportPDF.BackColor = Color.FromArgb(130, 179, 255);
            ButtonExportPDF.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonExportPDF.BorderColor = Color.White;
            ButtonExportPDF.BorderRadius = 10;
            ButtonExportPDF.BorderSize = 1;
            ButtonExportPDF.FlatAppearance.BorderSize = 0;
            ButtonExportPDF.FlatStyle = FlatStyle.Flat;
            ButtonExportPDF.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonExportPDF.ForeColor = Color.White;
            ButtonExportPDF.Location = new Point(712, 218);
            ButtonExportPDF.Name = "ButtonExportPDF";
            ButtonExportPDF.Size = new Size(207, 50);
            ButtonExportPDF.TabIndex = 18;
            ButtonExportPDF.Text = "📄 ЭКСПОРТ В PDF";
            ButtonExportPDF.TextColor = Color.White;
            ButtonExportPDF.UseVisualStyleBackColor = false;
            ButtonExportPDF.Click += ButtonExportPDF_Click;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblDateRange.ForeColor = Color.White;
            lblDateRange.Location = new Point(379, 113);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(152, 23);
            lblDateRange.TabIndex = 1;
            lblDateRange.Text = "Выберите период";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(273, 72);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(370, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 ОТЧЁТ ПО ПРИБЫЛИ";
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(931, 628);
            Controls.Add(lblDateRange);
            Controls.Add(lblTitle);
            Controls.Add(ButtonExportPDF);
            Controls.Add(ButtonYear);
            Controls.Add(ButtonMonth);
            Controls.Add(ButtonWeek);
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
        private CustomControls.RJControls.RJButton ButtonWeek;
        private CustomControls.RJControls.RJButton ButtonMonth;
        private CustomControls.RJControls.RJButton ButtonYear;
        private CustomControls.RJControls.RJButton ButtonExportPDF;
        private Label lblDateRange;
        private Label lblTitle;
    }

}
