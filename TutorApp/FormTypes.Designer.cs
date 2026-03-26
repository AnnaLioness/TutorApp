namespace TutorApp
{
    partial class FormTypes
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView = new CustomControls.RJControls.RJDataGridView();
            comboBox1 = new ComboBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            ButtonDel = new CustomControls.RJControls.RJButton();
            ButtonUpd = new CustomControls.RJControls.RJButton();
            ButtonSave = new CustomControls.RJControls.RJButton();
            ButtonAddSubj = new CustomControls.RJControls.RJButton();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 30;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.LightGray;
            dataGridView.GridColorCustom = Color.LightGray;
            dataGridView.HeaderBackColor = Color.DeepSkyBlue;
            dataGridView.HeaderFont = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridView.HeaderForeColor = Color.Black;
            dataGridView.Location = new Point(98, 81);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(100, 120, 200);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowsFont = new Font("Segoe UI", 9F);
            dataGridView.RowsForeColor = Color.Black;
            dataGridView.Size = new Size(328, 227);
            dataGridView.TabIndex = 1;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(564, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(291, 28);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label1.Location = new Point(443, 81);
            label1.Name = "label1";
            label1.Size = new Size(108, 28);
            label1.TabIndex = 8;
            label1.Text = "Предмет:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(564, 164);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(291, 27);
            textBox1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(436, 164);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 10;
            label2.Text = "Название:";
            // 
            // ButtonDel
            // 
            ButtonDel.BackColor = Color.DeepSkyBlue;
            ButtonDel.BackgroundColor = Color.DeepSkyBlue;
            ButtonDel.BorderColor = Color.PaleVioletRed;
            ButtonDel.BorderRadius = 10;
            ButtonDel.BorderSize = 0;
            ButtonDel.FlatAppearance.BorderSize = 0;
            ButtonDel.FlatStyle = FlatStyle.Flat;
            ButtonDel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonDel.ForeColor = Color.Black;
            ButtonDel.Location = new Point(738, 267);
            ButtonDel.Name = "ButtonDel";
            ButtonDel.Size = new Size(139, 41);
            ButtonDel.TabIndex = 13;
            ButtonDel.Text = "Удалить";
            ButtonDel.TextColor = Color.Black;
            ButtonDel.UseVisualStyleBackColor = false;
            ButtonDel.Click += ButtonDel_Click;
            // 
            // ButtonUpd
            // 
            ButtonUpd.BackColor = Color.DeepSkyBlue;
            ButtonUpd.BackgroundColor = Color.DeepSkyBlue;
            ButtonUpd.BorderColor = Color.PaleVioletRed;
            ButtonUpd.BorderRadius = 10;
            ButtonUpd.BorderSize = 0;
            ButtonUpd.FlatAppearance.BorderSize = 0;
            ButtonUpd.FlatStyle = FlatStyle.Flat;
            ButtonUpd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonUpd.ForeColor = Color.Black;
            ButtonUpd.Location = new Point(586, 267);
            ButtonUpd.Name = "ButtonUpd";
            ButtonUpd.Size = new Size(146, 41);
            ButtonUpd.TabIndex = 12;
            ButtonUpd.Text = "Редактировать";
            ButtonUpd.TextColor = Color.Black;
            ButtonUpd.UseVisualStyleBackColor = false;
            ButtonUpd.Click += ButtonUpd_Click;
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
            ButtonSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonSave.ForeColor = Color.Black;
            ButtonSave.Location = new Point(441, 267);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(139, 41);
            ButtonSave.TabIndex = 11;
            ButtonSave.Text = "Сохранить";
            ButtonSave.TextColor = Color.Black;
            ButtonSave.UseVisualStyleBackColor = false;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonAddSubj
            // 
            ButtonAddSubj.BackColor = Color.DeepSkyBlue;
            ButtonAddSubj.BackgroundColor = Color.DeepSkyBlue;
            ButtonAddSubj.BorderColor = Color.PaleVioletRed;
            ButtonAddSubj.BorderRadius = 10;
            ButtonAddSubj.BorderSize = 0;
            ButtonAddSubj.FlatAppearance.BorderSize = 0;
            ButtonAddSubj.FlatStyle = FlatStyle.Flat;
            ButtonAddSubj.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAddSubj.ForeColor = Color.Black;
            ButtonAddSubj.Location = new Point(618, 117);
            ButtonAddSubj.Name = "ButtonAddSubj";
            ButtonAddSubj.Size = new Size(237, 41);
            ButtonAddSubj.TabIndex = 14;
            ButtonAddSubj.Text = "Добавить новый предмет";
            ButtonAddSubj.TextColor = Color.Black;
            ButtonAddSubj.UseVisualStyleBackColor = false;
            ButtonAddSubj.Click += ButtonAddSubj_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(12, 9);
            label7.Name = "label7";
            label7.Size = new Size(1044, 54);
            label7.TabIndex = 28;
            label7.Text = "Информация о направлении отработки предмета";
            // 
            // FormTypes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 322);
            Controls.Add(label7);
            Controls.Add(ButtonAddSubj);
            Controls.Add(ButtonDel);
            Controls.Add(ButtonUpd);
            Controls.Add(ButtonSave);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView);
            Name = "FormTypes";
            Text = "Направления";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.RJControls.RJDataGridView dataGridView;
        private ComboBox comboBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private CustomControls.RJControls.RJButton ButtonDel;
        private CustomControls.RJControls.RJButton ButtonUpd;
        private CustomControls.RJControls.RJButton ButtonSave;
        private CustomControls.RJControls.RJButton ButtonAddSubj;
        private Label label7;
    }
}