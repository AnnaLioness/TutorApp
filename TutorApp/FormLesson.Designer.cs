namespace TutorApp
{
    partial class FormLesson
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
            ButtonAddType = new CustomControls.RJControls.RJButton();
            dateTimePickerDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            numericPrice = new NumericUpDown();
            comboBoxStudent = new ComboBox();
            comboBoxType = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            rjButton1 = new CustomControls.RJControls.RJButton();
            label5 = new Label();
            dateTimePickerTime = new DateTimePicker();
            label6 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            comboBoxSubject = new ComboBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            SuspendLayout();
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
            ButtonAddType.Location = new Point(323, 452);
            ButtonAddType.Name = "ButtonAddType";
            ButtonAddType.Size = new Size(316, 50);
            ButtonAddType.TabIndex = 12;
            ButtonAddType.Text = "Добавить новое направление отработки";
            ButtonAddType.TextColor = Color.White;
            ButtonAddType.UseVisualStyleBackColor = false;
            ButtonAddType.Click += ButtonAddType_Click;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dateTimePickerDate.Location = new Point(161, 135);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(250, 27);
            dateTimePickerDate.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(5, 133);
            label1.Name = "label1";
            label1.Size = new Size(61, 28);
            label1.TabIndex = 14;
            label1.Text = "Дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(5, 215);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 16;
            label2.Text = "Цена:";
            // 
            // numericPrice
            // 
            numericPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            numericPrice.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numericPrice.Location = new Point(161, 220);
            numericPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericPrice.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(150, 27);
            numericPrice.TabIndex = 17;
            numericPrice.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxStudent.FormattingEnabled = true;
            comboBoxStudent.Location = new Point(160, 264);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(151, 28);
            comboBoxStudent.TabIndex = 18;
            // 
            // comboBoxType
            // 
            comboBoxType.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(271, 350);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(151, 28);
            comboBoxType.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(5, 260);
            label3.Name = "label3";
            label3.Size = new Size(88, 28);
            label3.TabIndex = 20;
            label3.Text = "Ученик:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(9, 350);
            label4.Name = "label4";
            label4.Size = new Size(249, 28);
            label4.TabIndex = 21;
            label4.Text = "Направление отработки:";
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.BackgroundColor = Color.White;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 10;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rjButton1.ForeColor = Color.FromArgb(70, 119, 207);
            rjButton1.Location = new Point(9, 449);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(223, 50);
            rjButton1.TabIndex = 22;
            rjButton1.Text = "Сохранить";
            rjButton1.TextColor = Color.FromArgb(70, 119, 207);
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(5, 173);
            label5.Name = "label5";
            label5.Size = new Size(78, 28);
            label5.TabIndex = 23;
            label5.Text = "Время:";
            // 
            // dateTimePickerTime
            // 
            dateTimePickerTime.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dateTimePickerTime.Location = new Point(160, 175);
            dateTimePickerTime.Name = "dateTimePickerTime";
            dateTimePickerTime.Size = new Size(250, 27);
            dateTimePickerTime.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(9, 396);
            label6.Name = "label6";
            label6.Size = new Size(149, 28);
            label6.TabIndex = 25;
            label6.Text = "Комментарий:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            textBox1.Location = new Point(164, 397);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(250, 34);
            textBox1.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.White;
            label7.Location = new Point(97, 49);
            label7.Name = "label7";
            label7.Size = new Size(454, 54);
            label7.TabIndex = 27;
            label7.Text = "Информация об уроке";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label8.Location = new Point(7, 263);
            label8.Name = "label8";
            label8.Size = new Size(0, 28);
            label8.TabIndex = 29;
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(131, 305);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(291, 28);
            comboBoxSubject.TabIndex = 28;
            comboBoxSubject.SelectedIndexChanged += comboBoxSubject_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(6, 305);
            label9.Name = "label9";
            label9.Size = new Size(102, 28);
            label9.TabIndex = 31;
            label9.Text = "Предмет:";
            // 
            // FormLesson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(647, 510);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(comboBoxSubject);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(dateTimePickerTime);
            Controls.Add(label5);
            Controls.Add(rjButton1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxType);
            Controls.Add(comboBoxStudent);
            Controls.Add(numericPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerDate);
            Controls.Add(ButtonAddType);
            Name = "FormLesson";
            Text = "Урок";
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.RJControls.RJButton ButtonAddType;
        private DateTimePicker dateTimePickerDate;
        private Label label1;
        private Label label2;
        private NumericUpDown numericPrice;
        private ComboBox comboBoxStudent;
        private ComboBox comboBoxType;
        private Label label3;
        private Label label4;
        private CustomControls.RJControls.RJButton rjButton1;
        private Label label5;
        private DateTimePicker dateTimePickerTime;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private Label label8;
        private ComboBox comboBoxSubject;
        private Label label9;
    }
}