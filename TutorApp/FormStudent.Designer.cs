namespace TutorApp
{
    partial class FormStudent
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
            textBoxName = new TextBox();
            label1 = new Label();
            numericUpDownAge = new NumericUpDown();
            label2 = new Label();
            textBoxPhone = new TextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            rjButton1 = new CustomControls.RJControls.RJButton();
            ButtonAddLevel = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAge).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(83, 42);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(520, 27);
            textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 1;
            label1.Text = "ФИО:";
            // 
            // numericUpDownAge
            // 
            numericUpDownAge.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            numericUpDownAge.Location = new Point(112, 101);
            numericUpDownAge.Name = "numericUpDownAge";
            numericUpDownAge.Size = new Size(150, 27);
            numericUpDownAge.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 3;
            label2.Text = "Возраст:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(201, 160);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(125, 27);
            textBoxPhone.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(183, 28);
            label3.TabIndex = 5;
            label3.Text = "Номер телефона:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(116, 214);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 214);
            label4.Name = "label4";
            label4.Size = new Size(98, 28);
            label4.TabIndex = 7;
            label4.Text = "Уровень:";
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
            rjButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(12, 269);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(188, 50);
            rjButton1.TabIndex = 8;
            rjButton1.Text = "Сохранить";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
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
            ButtonAddLevel.Location = new Point(431, 272);
            ButtonAddLevel.Name = "ButtonAddLevel";
            ButtonAddLevel.Size = new Size(357, 50);
            ButtonAddLevel.TabIndex = 9;
            ButtonAddLevel.Text = "Нет нужного уровня для ученика?Добавь свой";
            ButtonAddLevel.TextColor = Color.Black;
            ButtonAddLevel.UseVisualStyleBackColor = false;
            ButtonAddLevel.Click += ButtonAddLevel_Click;
            // 
            // FormStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 344);
            Controls.Add(ButtonAddLevel);
            Controls.Add(rjButton1);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(textBoxPhone);
            Controls.Add(label2);
            Controls.Add(numericUpDownAge);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Name = "FormStudent";
            Text = "FormStudent";
            ((System.ComponentModel.ISupportInitialize)numericUpDownAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label label1;
        private NumericUpDown numericUpDownAge;
        private Label label2;
        private TextBox textBoxPhone;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJButton ButtonAddLevel;
    }
}