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
            textBoxTitle.Location = new Point(128, 86);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(325, 27);
            textBoxTitle.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(334, 12);
            label1.Name = "label1";
            label1.Size = new Size(225, 54);
            label1.TabIndex = 6;
            label1.Text = "Материал";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(10, 82);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 7;
            label2.Text = "Название:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(128, 134);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(325, 34);
            textBoxDescription.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(10, 134);
            label3.Name = "label3";
            label3.Size = new Size(114, 28);
            label3.TabIndex = 9;
            label3.Text = "Описание:";
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(119, 189);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(325, 28);
            comboBoxSubject.TabIndex = 10;
            comboBoxSubject.SelectedIndexChanged += comboBoxSubject_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(10, 189);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 11;
            label4.Text = "Предмет:";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(165, 236);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(325, 28);
            comboBoxType.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(10, 236);
            label5.Name = "label5";
            label5.Size = new Size(149, 28);
            label5.TabIndex = 13;
            label5.Text = "Направление:";
            // 
            // comboBoxAgeGrop
            // 
            comboBoxAgeGrop.FormattingEnabled = true;
            comboBoxAgeGrop.Location = new Point(214, 335);
            comboBoxAgeGrop.Name = "comboBoxAgeGrop";
            comboBoxAgeGrop.Size = new Size(323, 28);
            comboBoxAgeGrop.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(8, 331);
            label6.Name = "label6";
            label6.Size = new Size(200, 28);
            label6.TabIndex = 15;
            label6.Text = "Возрастная группа:";
            // 
            // comboBoxSeason
            // 
            comboBoxSeason.FormattingEnabled = true;
            comboBoxSeason.Location = new Point(88, 377);
            comboBoxSeason.Name = "comboBoxSeason";
            comboBoxSeason.Size = new Size(322, 28);
            comboBoxSeason.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(8, 373);
            label7.Name = "label7";
            label7.Size = new Size(74, 28);
            label7.TabIndex = 17;
            label7.Text = "Сезон:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(10, 420);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(200, 24);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Праздничный материал";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.Location = new Point(216, 414);
            label8.Name = "label8";
            label8.Size = new Size(114, 28);
            label8.TabIndex = 19;
            label8.Text = "Праздник:";
            // 
            // comboBoxHoliday
            // 
            comboBoxHoliday.FormattingEnabled = true;
            comboBoxHoliday.Location = new Point(336, 416);
            comboBoxHoliday.Name = "comboBoxHoliday";
            comboBoxHoliday.Size = new Size(178, 28);
            comboBoxHoliday.TabIndex = 20;
            // 
            // ButtonLoad
            // 
            ButtonLoad.BackColor = Color.LightSkyBlue;
            ButtonLoad.BackgroundColor = Color.LightSkyBlue;
            ButtonLoad.BorderColor = Color.PaleVioletRed;
            ButtonLoad.BorderRadius = 10;
            ButtonLoad.BorderSize = 0;
            ButtonLoad.FlatAppearance.BorderSize = 0;
            ButtonLoad.FlatStyle = FlatStyle.Flat;
            ButtonLoad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonLoad.ForeColor = Color.Black;
            ButtonLoad.Location = new Point(8, 461);
            ButtonLoad.Name = "ButtonLoad";
            ButtonLoad.Size = new Size(188, 50);
            ButtonLoad.TabIndex = 21;
            ButtonLoad.Text = "Загрузить файл";
            ButtonLoad.TextColor = Color.Black;
            ButtonLoad.UseVisualStyleBackColor = false;
            ButtonLoad.Click += ButtonLoad_Click;
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
            ButtonSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonSave.ForeColor = Color.Black;
            ButtonSave.Location = new Point(8, 527);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(188, 50);
            ButtonSave.TabIndex = 22;
            ButtonSave.Text = "Сохранить";
            ButtonSave.TextColor = Color.Black;
            ButtonSave.UseVisualStyleBackColor = false;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonAddLevel
            // 
            ButtonAddLevel.BackColor = Color.DeepSkyBlue;
            ButtonAddLevel.BackgroundColor = Color.DeepSkyBlue;
            ButtonAddLevel.BorderColor = Color.PaleVioletRed;
            ButtonAddLevel.BorderRadius = 10;
            ButtonAddLevel.BorderSize = 0;
            ButtonAddLevel.FlatAppearance.BorderSize = 0;
            ButtonAddLevel.FlatStyle = FlatStyle.Flat;
            ButtonAddLevel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAddLevel.ForeColor = Color.Black;
            ButtonAddLevel.Location = new Point(236, 527);
            ButtonAddLevel.Name = "ButtonAddLevel";
            ButtonAddLevel.Size = new Size(278, 50);
            ButtonAddLevel.TabIndex = 23;
            ButtonAddLevel.Text = "Добавить новый уровень материала";
            ButtonAddLevel.TextColor = Color.Black;
            ButtonAddLevel.UseVisualStyleBackColor = false;
            ButtonAddLevel.Click += ButtonAddLevel_Click;
            // 
            // ButtonAddType
            // 
            ButtonAddType.BackColor = Color.DeepSkyBlue;
            ButtonAddType.BackgroundColor = Color.DeepSkyBlue;
            ButtonAddType.BorderColor = Color.PaleVioletRed;
            ButtonAddType.BorderRadius = 10;
            ButtonAddType.BorderSize = 0;
            ButtonAddType.FlatAppearance.BorderSize = 0;
            ButtonAddType.FlatStyle = FlatStyle.Flat;
            ButtonAddType.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAddType.ForeColor = Color.Black;
            ButtonAddType.Location = new Point(566, 527);
            ButtonAddType.Name = "ButtonAddType";
            ButtonAddType.Size = new Size(316, 50);
            ButtonAddType.TabIndex = 24;
            ButtonAddType.Text = "Добавить новое направление отработки";
            ButtonAddType.TextColor = Color.Black;
            ButtonAddType.UseVisualStyleBackColor = false;
            ButtonAddType.Click += ButtonAddType_Click;
            // 
            // comboBoxLevel
            // 
            comboBoxLevel.FormattingEnabled = true;
            comboBoxLevel.Location = new Point(227, 284);
            comboBoxLevel.Name = "comboBoxLevel";
            comboBoxLevel.Size = new Size(263, 28);
            comboBoxLevel.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.Location = new Point(10, 284);
            label9.Name = "label9";
            label9.Size = new Size(211, 28);
            label9.TabIndex = 26;
            label9.Text = "Уровень сложности:";
            // 
            // FormMaterial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 591);
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
            Name = "FormMaterial";
            Text = "FormMaterial";
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