namespace TutorApp
{
    partial class FormMaterial
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
            textBoxTitle = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxDescription = new TextBox();
            label3 = new Label();
            comboBoxSubject = new ComboBox();
            label4 = new Label();
            comboBoxType = new ComboBox();
            label5 = new Label();
            comboBoxAgeGrop = new ComboBox();
            label6 = new Label();
            comboBoxSeason = new ComboBox();
            label7 = new Label();
            checkBox1 = new CheckBox();
            label8 = new Label();
            comboBoxHoliday = new ComboBox();
            ButtonLoad = new CustomControls.RJControls.RJButton();
            ButtonSave = new CustomControls.RJControls.RJButton();
            ButtonAddLevel = new CustomControls.RJControls.RJButton();
            ButtonAddType = new CustomControls.RJControls.RJButton();
            comboBoxLevel = new ComboBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // textBoxTitle
            // 
            textBoxTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            textBoxTitle.Location = new Point(130, 141);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(325, 27);
            textBoxTitle.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(336, 67);
            label1.Name = "label1";
            label1.Size = new Size(209, 54);
            label1.TabIndex = 6;
            label1.Text = "Материал";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(130, 179, 255);
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 137);
            label2.Name = "label2";
            label2.Size = new Size(107, 28);
            label2.TabIndex = 7;
            label2.Text = "Название:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            textBoxDescription.Location = new Point(130, 189);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(325, 34);
            textBoxDescription.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(130, 179, 255);
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 189);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 9;
            label3.Text = "Описание:";
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(121, 244);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(325, 28);
            comboBoxSubject.TabIndex = 10;
            comboBoxSubject.SelectedIndexChanged += comboBoxSubject_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(130, 179, 255);
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 244);
            label4.Name = "label4";
            label4.Size = new Size(102, 28);
            label4.TabIndex = 11;
            label4.Text = "Предмет:";
            // 
            // comboBoxType
            // 
            comboBoxType.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(167, 291);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(325, 28);
            comboBoxType.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(130, 179, 255);
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 291);
            label5.Name = "label5";
            label5.Size = new Size(144, 28);
            label5.TabIndex = 13;
            label5.Text = "Направление:";
            // 
            // comboBoxAgeGrop
            // 
            comboBoxAgeGrop.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxAgeGrop.FormattingEnabled = true;
            comboBoxAgeGrop.Location = new Point(216, 390);
            comboBoxAgeGrop.Name = "comboBoxAgeGrop";
            comboBoxAgeGrop.Size = new Size(323, 28);
            comboBoxAgeGrop.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(130, 179, 255);
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(10, 386);
            label6.Name = "label6";
            label6.Size = new Size(193, 28);
            label6.TabIndex = 15;
            label6.Text = "Возрастная группа:";
            // 
            // comboBoxSeason
            // 
            comboBoxSeason.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxSeason.FormattingEnabled = true;
            comboBoxSeason.Location = new Point(90, 432);
            comboBoxSeason.Name = "comboBoxSeason";
            comboBoxSeason.Size = new Size(322, 28);
            comboBoxSeason.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(130, 179, 255);
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(10, 428);
            label7.Name = "label7";
            label7.Size = new Size(73, 28);
            label7.TabIndex = 17;
            label7.Text = "Сезон:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(130, 179, 255);
            checkBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(12, 475);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(202, 24);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Праздничный материал";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(130, 179, 255);
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(218, 469);
            label8.Name = "label8";
            label8.Size = new Size(111, 28);
            label8.TabIndex = 19;
            label8.Text = "Праздник:";
            // 
            // comboBoxHoliday
            // 
            comboBoxHoliday.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxHoliday.FormattingEnabled = true;
            comboBoxHoliday.Location = new Point(338, 471);
            comboBoxHoliday.Name = "comboBoxHoliday";
            comboBoxHoliday.Size = new Size(178, 28);
            comboBoxHoliday.TabIndex = 20;
            // 
            // ButtonLoad
            // 
            ButtonLoad.BackColor = Color.White;
            ButtonLoad.BackgroundColor = Color.White;
            ButtonLoad.BorderColor = Color.PaleVioletRed;
            ButtonLoad.BorderRadius = 10;
            ButtonLoad.BorderSize = 0;
            ButtonLoad.FlatAppearance.BorderSize = 0;
            ButtonLoad.FlatStyle = FlatStyle.Flat;
            ButtonLoad.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ButtonLoad.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonLoad.Location = new Point(10, 516);
            ButtonLoad.Name = "ButtonLoad";
            ButtonLoad.Size = new Size(188, 50);
            ButtonLoad.TabIndex = 21;
            ButtonLoad.Text = "Загрузить файл";
            ButtonLoad.TextColor = Color.FromArgb(70, 119, 207);
            ButtonLoad.UseVisualStyleBackColor = false;
            ButtonLoad.Click += ButtonLoad_Click;
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
            ButtonSave.Location = new Point(10, 582);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(188, 50);
            ButtonSave.TabIndex = 22;
            ButtonSave.Text = "Сохранить";
            ButtonSave.TextColor = Color.FromArgb(70, 119, 207);
            ButtonSave.UseVisualStyleBackColor = false;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonAddLevel
            // 
            ButtonAddLevel.BackColor = Color.FromArgb(130, 179, 255);
            ButtonAddLevel.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonAddLevel.BorderColor = Color.White;
            ButtonAddLevel.BorderRadius = 10;
            ButtonAddLevel.BorderSize = 1;
            ButtonAddLevel.FlatAppearance.BorderSize = 0;
            ButtonAddLevel.FlatStyle = FlatStyle.Flat;
            ButtonAddLevel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAddLevel.ForeColor = Color.White;
            ButtonAddLevel.Location = new Point(238, 582);
            ButtonAddLevel.Name = "ButtonAddLevel";
            ButtonAddLevel.Size = new Size(278, 50);
            ButtonAddLevel.TabIndex = 23;
            ButtonAddLevel.Text = "Добавить новый уровень материала";
            ButtonAddLevel.TextColor = Color.White;
            ButtonAddLevel.UseVisualStyleBackColor = false;
            ButtonAddLevel.Click += ButtonAddLevel_Click;
            // 
            // ButtonAddType
            // 
            ButtonAddType.BackColor = Color.FromArgb(130, 179, 255);
            ButtonAddType.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonAddType.BorderColor = Color.White;
            ButtonAddType.BorderRadius = 10;
            ButtonAddType.BorderSize = 1;
            ButtonAddType.FlatAppearance.BorderSize = 0;
            ButtonAddType.FlatStyle = FlatStyle.Flat;
            ButtonAddType.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAddType.ForeColor = Color.White;
            ButtonAddType.Location = new Point(568, 582);
            ButtonAddType.Name = "ButtonAddType";
            ButtonAddType.Size = new Size(316, 50);
            ButtonAddType.TabIndex = 24;
            ButtonAddType.Text = "Добавить новое направление отработки";
            ButtonAddType.TextColor = Color.White;
            ButtonAddType.UseVisualStyleBackColor = false;
            ButtonAddType.Click += ButtonAddType_Click;
            // 
            // comboBoxLevel
            // 
            comboBoxLevel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxLevel.FormattingEnabled = true;
            comboBoxLevel.Location = new Point(229, 339);
            comboBoxLevel.Name = "comboBoxLevel";
            comboBoxLevel.Size = new Size(263, 28);
            comboBoxLevel.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(130, 179, 255);
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(12, 339);
            label9.Name = "label9";
            label9.Size = new Size(205, 28);
            label9.TabIndex = 26;
            label9.Text = "Уровень сложности:";
            // 
            // FormMaterial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(897, 644);
            Controls.Add(label9);
            Controls.Add(comboBoxLevel);
            Controls.Add(ButtonAddType);
            Controls.Add(ButtonAddLevel);
            Controls.Add(ButtonSave);
            Controls.Add(ButtonLoad);
            Controls.Add(comboBoxHoliday);
            Controls.Add(label8);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(comboBoxSeason);
            Controls.Add(label6);
            Controls.Add(comboBoxAgeGrop);
            Controls.Add(label5);
            Controls.Add(comboBoxType);
            Controls.Add(label4);
            Controls.Add(comboBoxSubject);
            Controls.Add(label3);
            Controls.Add(textBoxDescription);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxTitle);
            ForeColor = Color.White;
            Name = "FormMaterial";
            Text = "Материал";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTitle;
        private Label label1;
        private Label label2;
        private TextBox textBoxDescription;
        private Label label3;
        private ComboBox comboBoxSubject;
        private Label label4;
        private ComboBox comboBoxType;
        private Label label5;
        private ComboBox comboBoxAgeGrop;
        private Label label6;
        private ComboBox comboBoxSeason;
        private Label label7;
        private CheckBox checkBox1;
        private Label label8;
        private ComboBox comboBoxHoliday;
        private CustomControls.RJControls.RJButton ButtonLoad;
        private CustomControls.RJControls.RJButton ButtonSave;
        private CustomControls.RJControls.RJButton ButtonAddLevel;
        private CustomControls.RJControls.RJButton ButtonAddType;
        private ComboBox comboBoxLevel;
        private Label label9;
    }
}