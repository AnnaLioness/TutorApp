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
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            SuspendLayout();
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
            ButtonAddType.Location = new Point(316, 366);
            ButtonAddType.Name = "ButtonAddType";
            ButtonAddType.Size = new Size(316, 50);
            ButtonAddType.TabIndex = 12;
            ButtonAddType.Text = "Добавить новое направление отработки";
            ButtonAddType.TextColor = Color.Black;
            ButtonAddType.UseVisualStyleBackColor = false;
            ButtonAddType.Click += ButtonAddType_Click;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(158, 95);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(250, 27);
            dateTimePickerDate.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(2, 93);
            label1.Name = "label1";
            label1.Size = new Size(64, 28);
            label1.TabIndex = 14;
            label1.Text = "Дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(2, 175);
            label2.Name = "label2";
            label2.Size = new Size(67, 28);
            label2.TabIndex = 16;
            label2.Text = "Цена:";
            // 
            // numericPrice
            // 
            numericPrice.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numericPrice.Location = new Point(158, 180);
            numericPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericPrice.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(150, 27);
            numericPrice.TabIndex = 17;
            numericPrice.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.FormattingEnabled = true;
            comboBoxStudent.Location = new Point(157, 224);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(151, 28);
            comboBoxStudent.TabIndex = 18;
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(264, 264);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(151, 28);
            comboBoxType.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(2, 220);
            label3.Name = "label3";
            label3.Size = new Size(89, 28);
            label3.TabIndex = 20;
            label3.Text = "Ученик:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(2, 264);
            label4.Name = "label4";
            label4.Size = new Size(256, 28);
            label4.TabIndex = 21;
            label4.Text = "Направление отработки:";
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.DeepSkyBlue;
            rjButton1.BackgroundColor = Color.DeepSkyBlue;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 10;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(2, 363);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(223, 50);
            rjButton1.TabIndex = 22;
            rjButton1.Text = "Сохранить";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(2, 133);
            label5.Name = "label5";
            label5.Size = new Size(80, 28);
            label5.TabIndex = 23;
            label5.Text = "Время:";
            // 
            // dateTimePickerTime
            // 
            dateTimePickerTime.Location = new Point(157, 135);
            dateTimePickerTime.Name = "dateTimePickerTime";
            dateTimePickerTime.Size = new Size(250, 27);
            dateTimePickerTime.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(2, 310);
            label6.Name = "label6";
            label6.Size = new Size(155, 28);
            label6.TabIndex = 25;
            label6.Text = "Комментарий:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(157, 311);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(250, 34);
            textBox1.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(94, 9);
            label7.Name = "label7";
            label7.Size = new Size(491, 54);
            label7.TabIndex = 27;
            label7.Text = "Информация об уроке";
            // 
            // FormLesson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 433);
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
            Text = "FormLesson";
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
    }
}