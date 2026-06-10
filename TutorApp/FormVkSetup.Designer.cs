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
            lblTitle.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(39, 81);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(351, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔐 Настройка ВКонтакте";
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGroupId.ForeColor = Color.White;
            lblGroupId.Location = new Point(12, 136);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(249, 23);
            lblGroupId.TabIndex = 1;
            lblGroupId.Text = "ID группы (со знаком минус):";
            // 
            // txtGroupId
            // 
            txtGroupId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtGroupId.Location = new Point(12, 166);
            txtGroupId.Name = "txtGroupId";
            txtGroupId.PlaceholderText = "-123456789";
            txtGroupId.Size = new Size(400, 30);
            txtGroupId.TabIndex = 2;
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblToken.ForeColor = Color.White;
            lblToken.Location = new Point(12, 216);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(222, 23);
            lblToken.TabIndex = 3;
            lblToken.Text = "Сервисный токен доступа:";
            // 
            // txtAccessToken
            // 
            txtAccessToken.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtAccessToken.Location = new Point(12, 246);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.PlaceholderText = "vk1.a...";
            txtAccessToken.Size = new Size(400, 30);
            txtAccessToken.TabIndex = 4;
            txtAccessToken.UseSystemPasswordChar = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(12, 371);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(172, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "ℹ️ Статус: ожидание...";
            // 
            // ButtonTest
            // 
            ButtonTest.BackColor = Color.White;
            ButtonTest.BackgroundColor = Color.White;
            ButtonTest.BorderColor = Color.PaleVioletRed;
            ButtonTest.BorderRadius = 10;
            ButtonTest.BorderSize = 0;
            ButtonTest.FlatAppearance.BorderSize = 0;
            ButtonTest.FlatStyle = FlatStyle.Flat;
            ButtonTest.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ButtonTest.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonTest.Location = new Point(12, 308);
            ButtonTest.Name = "ButtonTest";
            ButtonTest.Size = new Size(140, 43);
            ButtonTest.TabIndex = 23;
            ButtonTest.Text = "🔍 ТЕСТ";
            ButtonTest.TextColor = Color.FromArgb(70, 119, 207);
            ButtonTest.UseVisualStyleBackColor = false;
            ButtonTest.Click += ButtonTest_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.BackColor = Color.White;
            ButtonSave.BackgroundColor = Color.White;
            ButtonSave.BorderColor = Color.PaleVioletRed;
            ButtonSave.BorderRadius = 10;
            ButtonSave.BorderSize = 0;
            ButtonSave.FlatAppearance.BorderSize = 0;
            ButtonSave.FlatStyle = FlatStyle.Flat;
            ButtonSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ButtonSave.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonSave.Location = new Point(189, 308);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(188, 43);
            ButtonSave.TabIndex = 24;
            ButtonSave.Text = "💾 СОХРАНИТЬ";
            ButtonSave.TextColor = Color.FromArgb(70, 119, 207);
            ButtonSave.UseVisualStyleBackColor = false;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonInstruction
            // 
            ButtonInstruction.BackColor = Color.FromArgb(130, 179, 255);
            ButtonInstruction.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonInstruction.BorderColor = Color.White;
            ButtonInstruction.BorderRadius = 10;
            ButtonInstruction.BorderSize = 1;
            ButtonInstruction.FlatAppearance.BorderSize = 0;
            ButtonInstruction.FlatStyle = FlatStyle.Flat;
            ButtonInstruction.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonInstruction.ForeColor = Color.White;
            ButtonInstruction.Location = new Point(12, 405);
            ButtonInstruction.Name = "ButtonInstruction";
            ButtonInstruction.Size = new Size(349, 39);
            ButtonInstruction.TabIndex = 25;
            ButtonInstruction.Text = "📖 КАК ПОЛУЧИТЬ ID И ТОКЕН?";
            ButtonInstruction.TextColor = Color.White;
            ButtonInstruction.UseVisualStyleBackColor = false;
            ButtonInstruction.Click += ButtonInstruction_Click;
            // 
            // FormVkSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(464, 464);
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
            Text = "Настройка ВКонтакте";
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