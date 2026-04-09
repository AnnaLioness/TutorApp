namespace TutorApp
{
    partial class FormVkSetup
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
            lblTitle = new Label();
            lblGroupId = new Label();
            txtGroupId = new TextBox();
            lblToken = new Label();
            txtAccessToken = new TextBox();
            lblStatus = new Label();
            ButtonTest = new CustomControls.RJControls.RJButton();
            ButtonSave = new CustomControls.RJControls.RJButton();
            ButtonInstruction = new CustomControls.RJControls.RJButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(349, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔐 Настройка ВКонтакте";
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.Font = new Font("Segoe UI", 10F);
            lblGroupId.Location = new Point(12, 80);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(241, 23);
            lblGroupId.TabIndex = 1;
            lblGroupId.Text = "ID группы (со знаком минус):";
            // 
            // txtGroupId
            // 
            txtGroupId.Font = new Font("Segoe UI", 10F);
            txtGroupId.Location = new Point(12, 110);
            txtGroupId.Name = "txtGroupId";
            txtGroupId.PlaceholderText = "-123456789";
            txtGroupId.Size = new Size(400, 30);
            txtGroupId.TabIndex = 2;
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Font = new Font("Segoe UI", 10F);
            lblToken.Location = new Point(12, 160);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(218, 23);
            lblToken.TabIndex = 3;
            lblToken.Text = "Сервисный токен доступа:";
            // 
            // txtAccessToken
            // 
            txtAccessToken.Font = new Font("Segoe UI", 10F);
            txtAccessToken.Location = new Point(12, 190);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.PlaceholderText = "vk1.a...";
            txtAccessToken.Size = new Size(400, 30);
            txtAccessToken.TabIndex = 4;
            txtAccessToken.UseSystemPasswordChar = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(12, 315);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(164, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "ℹ️ Статус: ожидание...";
            // 
            // ButtonTest
            // 
            ButtonTest.BackColor = Color.DeepSkyBlue;
            ButtonTest.BackgroundColor = Color.DeepSkyBlue;
            ButtonTest.BorderColor = Color.PaleVioletRed;
            ButtonTest.BorderRadius = 10;
            ButtonTest.BorderSize = 0;
            ButtonTest.FlatAppearance.BorderSize = 0;
            ButtonTest.FlatStyle = FlatStyle.Flat;
            ButtonTest.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ButtonTest.ForeColor = Color.Black;
            ButtonTest.Location = new Point(12, 252);
            ButtonTest.Name = "ButtonTest";
            ButtonTest.Size = new Size(140, 43);
            ButtonTest.TabIndex = 23;
            ButtonTest.Text = "🔍 ТЕСТ";
            ButtonTest.TextColor = Color.Black;
            ButtonTest.UseVisualStyleBackColor = false;
            ButtonTest.Click += ButtonTest_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.BackColor = Color.DeepSkyBlue;
            ButtonSave.BackgroundColor = Color.DeepSkyBlue;
            ButtonSave.BorderColor = Color.PaleVioletRed;
            ButtonSave.BorderRadius = 10;
            ButtonSave.BorderSize = 0;
            ButtonSave.FlatAppearance.BorderSize = 0;
            ButtonSave.FlatStyle = FlatStyle.Flat;
            ButtonSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ButtonSave.ForeColor = Color.Black;
            ButtonSave.Location = new Point(189, 252);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(188, 43);
            ButtonSave.TabIndex = 24;
            ButtonSave.Text = "💾 СОХРАНИТЬ";
            ButtonSave.TextColor = Color.Black;
            ButtonSave.UseVisualStyleBackColor = false;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonInstruction
            // 
            ButtonInstruction.BackColor = Color.DeepSkyBlue;
            ButtonInstruction.BackgroundColor = Color.DeepSkyBlue;
            ButtonInstruction.BorderColor = Color.PaleVioletRed;
            ButtonInstruction.BorderRadius = 10;
            ButtonInstruction.BorderSize = 0;
            ButtonInstruction.FlatAppearance.BorderSize = 0;
            ButtonInstruction.FlatStyle = FlatStyle.Flat;
            ButtonInstruction.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ButtonInstruction.ForeColor = Color.Black;
            ButtonInstruction.Location = new Point(12, 349);
            ButtonInstruction.Name = "ButtonInstruction";
            ButtonInstruction.Size = new Size(349, 39);
            ButtonInstruction.TabIndex = 25;
            ButtonInstruction.Text = "📖 КАК ПОЛУЧИТЬ ID И ТОКЕН?";
            ButtonInstruction.TextColor = Color.Black;
            ButtonInstruction.UseVisualStyleBackColor = false;
            ButtonInstruction.Click += ButtonInstruction_Click;
            // 
            // FormVkSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 422);
            Controls.Add(ButtonInstruction);
            Controls.Add(ButtonSave);
            Controls.Add(ButtonTest);
            Controls.Add(lblStatus);
            Controls.Add(txtAccessToken);
            Controls.Add(lblToken);
            Controls.Add(txtGroupId);
            Controls.Add(lblGroupId);
            Controls.Add(lblTitle);
            Name = "FormVkSetup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "🔍 ТЕСТ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Label lblStatus;
        private CustomControls.RJControls.RJButton ButtonTest;
        private CustomControls.RJControls.RJButton ButtonSave;
        private CustomControls.RJControls.RJButton ButtonInstruction;
    }
}