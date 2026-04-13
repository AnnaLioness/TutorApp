namespace TutorApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Students = new CustomControls.RJControls.RJButton();
            Lessons = new CustomControls.RJControls.RJButton();
            ButtonMaterials = new CustomControls.RJControls.RJButton();
            ButtonReport = new CustomControls.RJControls.RJButton();
            ButtonVkSettings = new CustomControls.RJControls.RJButton();
            ButtonPublications = new CustomControls.RJControls.RJButton();
            SuspendLayout();
            // 
            // Students
            // 
            Students.BackColor = Color.White;
            Students.BackgroundColor = Color.White;
            Students.BorderColor = Color.PaleVioletRed;
            Students.BorderRadius = 10;
            Students.BorderSize = 0;
            Students.FlatAppearance.BorderSize = 0;
            Students.FlatStyle = FlatStyle.Flat;
            Students.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Students.ForeColor = Color.FromArgb(70, 119, 207);
            Students.Location = new Point(99, 69);
            Students.Name = "Students";
            Students.Size = new Size(188, 50);
            Students.TabIndex = 0;
            Students.Text = "Ученики";
            Students.TextColor = Color.FromArgb(70, 119, 207);
            Students.UseVisualStyleBackColor = false;
            Students.Click += Students_Click;
            // 
            // Lessons
            // 
            Lessons.BackColor = Color.White;
            Lessons.BackgroundColor = Color.White;
            Lessons.BorderColor = Color.PaleVioletRed;
            Lessons.BorderRadius = 10;
            Lessons.BorderSize = 0;
            Lessons.FlatAppearance.BorderSize = 0;
            Lessons.FlatStyle = FlatStyle.Flat;
            Lessons.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Lessons.ForeColor = Color.FromArgb(70, 119, 207);
            Lessons.Location = new Point(99, 145);
            Lessons.Name = "Lessons";
            Lessons.Size = new Size(188, 50);
            Lessons.TabIndex = 1;
            Lessons.Text = "Уроки";
            Lessons.TextColor = Color.FromArgb(70, 119, 207);
            Lessons.UseVisualStyleBackColor = false;
            Lessons.Click += Lessons_Click;
            // 
            // ButtonMaterials
            // 
            ButtonMaterials.BackColor = Color.White;
            ButtonMaterials.BackgroundColor = Color.White;
            ButtonMaterials.BorderColor = Color.PaleVioletRed;
            ButtonMaterials.BorderRadius = 10;
            ButtonMaterials.BorderSize = 0;
            ButtonMaterials.FlatAppearance.BorderSize = 0;
            ButtonMaterials.FlatStyle = FlatStyle.Flat;
            ButtonMaterials.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonMaterials.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonMaterials.Location = new Point(99, 224);
            ButtonMaterials.Name = "ButtonMaterials";
            ButtonMaterials.Size = new Size(188, 50);
            ButtonMaterials.TabIndex = 2;
            ButtonMaterials.Text = "Материалы";
            ButtonMaterials.TextColor = Color.FromArgb(70, 119, 207);
            ButtonMaterials.UseVisualStyleBackColor = false;
            ButtonMaterials.Click += ButtonMaterials_Click;
            // 
            // ButtonReport
            // 
            ButtonReport.BackColor = Color.White;
            ButtonReport.BackgroundColor = Color.White;
            ButtonReport.BorderColor = Color.PaleVioletRed;
            ButtonReport.BorderRadius = 10;
            ButtonReport.BorderSize = 0;
            ButtonReport.FlatAppearance.BorderSize = 0;
            ButtonReport.FlatStyle = FlatStyle.Flat;
            ButtonReport.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonReport.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonReport.Location = new Point(85, 301);
            ButtonReport.Name = "ButtonReport";
            ButtonReport.Size = new Size(219, 50);
            ButtonReport.TabIndex = 3;
            ButtonReport.Text = "Отчёт и статистика";
            ButtonReport.TextColor = Color.FromArgb(70, 119, 207);
            ButtonReport.UseVisualStyleBackColor = false;
            ButtonReport.Click += ButtonReport_Click;
            // 
            // ButtonVkSettings
            // 
            ButtonVkSettings.BackColor = Color.FromArgb(130, 179, 255);
            ButtonVkSettings.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonVkSettings.BorderColor = Color.White;
            ButtonVkSettings.BorderRadius = 10;
            ButtonVkSettings.BorderSize = 1;
            ButtonVkSettings.FlatAppearance.BorderSize = 0;
            ButtonVkSettings.FlatStyle = FlatStyle.Flat;
            ButtonVkSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonVkSettings.ForeColor = Color.White;
            ButtonVkSettings.Location = new Point(64, 447);
            ButtonVkSettings.Name = "ButtonVkSettings";
            ButtonVkSettings.Size = new Size(272, 50);
            ButtonVkSettings.TabIndex = 4;
            ButtonVkSettings.Text = "Настройка работы с Vk";
            ButtonVkSettings.TextColor = Color.White;
            ButtonVkSettings.UseVisualStyleBackColor = false;
            ButtonVkSettings.Click += ButtonVkSettings_Click;
            // 
            // ButtonPublications
            // 
            ButtonPublications.BackColor = Color.White;
            ButtonPublications.BackgroundColor = Color.White;
            ButtonPublications.BorderColor = Color.PaleVioletRed;
            ButtonPublications.BorderRadius = 10;
            ButtonPublications.BorderSize = 0;
            ButtonPublications.FlatAppearance.BorderSize = 0;
            ButtonPublications.FlatStyle = FlatStyle.Flat;
            ButtonPublications.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonPublications.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonPublications.Location = new Point(85, 374);
            ButtonPublications.Name = "ButtonPublications";
            ButtonPublications.Size = new Size(219, 50);
            ButtonPublications.TabIndex = 5;
            ButtonPublications.Text = "Публикации Vk";
            ButtonPublications.TextColor = Color.FromArgb(70, 119, 207);
            ButtonPublications.UseVisualStyleBackColor = false;
            ButtonPublications.Click += ButtonPublications_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 527);
            BackColor = Color.FromArgb(130, 179, 255);
            Controls.Add(ButtonPublications);
            Controls.Add(ButtonVkSettings);
            Controls.Add(ButtonReport);
            Controls.Add(ButtonMaterials);
            Controls.Add(Lessons);
            Controls.Add(Students);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная";
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.RJControls.RJButton Students;
        private CustomControls.RJControls.RJButton Lessons;
        private CustomControls.RJControls.RJButton ButtonMaterials;
        private CustomControls.RJControls.RJButton ButtonReport;
        private CustomControls.RJControls.RJButton ButtonVkSettings;
        private CustomControls.RJControls.RJButton ButtonPublications;
    }
}
