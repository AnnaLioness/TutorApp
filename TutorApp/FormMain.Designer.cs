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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Students);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.RJControls.RJButton Students;
    }
}
