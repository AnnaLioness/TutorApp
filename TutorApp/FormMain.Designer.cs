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
            SuspendLayout();
            // 
            // Students
            // 
            Students.BackColor = Color.DeepSkyBlue;
            Students.BackgroundColor = Color.DeepSkyBlue;
            Students.BorderColor = Color.PaleVioletRed;
            Students.BorderRadius = 10;
            Students.BorderSize = 0;
            Students.FlatAppearance.BorderSize = 0;
            Students.FlatStyle = FlatStyle.Flat;
            Students.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Students.ForeColor = Color.Black;
            Students.Location = new Point(304, 29);
            Students.Name = "Students";
            Students.Size = new Size(188, 50);
            Students.TabIndex = 0;
            Students.Text = "Ученики";
            Students.TextColor = Color.Black;
            Students.UseVisualStyleBackColor = false;
            Students.Click += Students_Click;
            // 
            // Lessons
            // 
            Lessons.BackColor = Color.DeepSkyBlue;
            Lessons.BackgroundColor = Color.DeepSkyBlue;
            Lessons.BorderColor = Color.PaleVioletRed;
            Lessons.BorderRadius = 10;
            Lessons.BorderSize = 0;
            Lessons.FlatAppearance.BorderSize = 0;
            Lessons.FlatStyle = FlatStyle.Flat;
            Lessons.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Lessons.ForeColor = Color.Black;
            Lessons.Location = new Point(304, 105);
            Lessons.Name = "Lessons";
            Lessons.Size = new Size(188, 50);
            Lessons.TabIndex = 1;
            Lessons.Text = "Уроки";
            Lessons.TextColor = Color.Black;
            Lessons.UseVisualStyleBackColor = false;
            Lessons.Click += Lessons_Click;
            // 
            // ButtonMaterials
            // 
            ButtonMaterials.BackColor = Color.DeepSkyBlue;
            ButtonMaterials.BackgroundColor = Color.DeepSkyBlue;
            ButtonMaterials.BorderColor = Color.PaleVioletRed;
            ButtonMaterials.BorderRadius = 10;
            ButtonMaterials.BorderSize = 0;
            ButtonMaterials.FlatAppearance.BorderSize = 0;
            ButtonMaterials.FlatStyle = FlatStyle.Flat;
            ButtonMaterials.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonMaterials.ForeColor = Color.Black;
            ButtonMaterials.Location = new Point(304, 184);
            ButtonMaterials.Name = "ButtonMaterials";
            ButtonMaterials.Size = new Size(188, 50);
            ButtonMaterials.TabIndex = 2;
            ButtonMaterials.Text = "Материалы";
            ButtonMaterials.TextColor = Color.Black;
            ButtonMaterials.UseVisualStyleBackColor = false;
            ButtonMaterials.Click += ButtonMaterials_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonMaterials);
            Controls.Add(Lessons);
            Controls.Add(Students);
            Name = "FormMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.RJControls.RJButton Students;
        private CustomControls.RJControls.RJButton Lessons;
        private CustomControls.RJControls.RJButton ButtonMaterials;
    }
}
