namespace TutorApp
{
    partial class FormLevels
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
            textBox1 = new TextBox();
            label1 = new Label();
            ButtonSave = new CustomControls.RJControls.RJButton();
            ButtonUpd = new CustomControls.RJControls.RJButton();
            ButtonDel = new CustomControls.RJControls.RJButton();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.FromArgb(130, 179, 255);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 30;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.RoyalBlue;
            dataGridView.GridColorCustom = Color.RoyalBlue;
            dataGridView.HeaderBackColor = Color.White;
            dataGridView.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView.HeaderForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.Location = new Point(12, 115);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(100, 120, 200);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowsFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridView.RowsForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(328, 227);
            dataGridView.TabIndex = 0;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(478, 115);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(266, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(360, 114);
            label1.Name = "label1";
            label1.Size = new Size(107, 28);
            label1.TabIndex = 2;
            label1.Text = "Название:";
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
            ButtonSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            ButtonSave.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonSave.Location = new Point(360, 300);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(139, 41);
            ButtonSave.TabIndex = 3;
            ButtonSave.Text = "Сохранить";
            ButtonSave.TextColor = Color.FromArgb(70, 119, 207);
            ButtonSave.UseVisualStyleBackColor = false;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonUpd
            // 
            ButtonUpd.BackColor = Color.White;
            ButtonUpd.BackgroundColor = Color.White;
            ButtonUpd.BorderColor = Color.PaleVioletRed;
            ButtonUpd.BorderRadius = 10;
            ButtonUpd.BorderSize = 0;
            ButtonUpd.FlatAppearance.BorderSize = 0;
            ButtonUpd.FlatStyle = FlatStyle.Flat;
            ButtonUpd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            ButtonUpd.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonUpd.Location = new Point(505, 300);
            ButtonUpd.Name = "ButtonUpd";
            ButtonUpd.Size = new Size(146, 41);
            ButtonUpd.TabIndex = 4;
            ButtonUpd.Text = "Редактировать";
            ButtonUpd.TextColor = Color.FromArgb(70, 119, 207);
            ButtonUpd.UseVisualStyleBackColor = false;
            ButtonUpd.Click += ButtonUpd_Click;
            // 
            // ButtonDel
            // 
            ButtonDel.BackColor = Color.White;
            ButtonDel.BackgroundColor = Color.White;
            ButtonDel.BorderColor = Color.PaleVioletRed;
            ButtonDel.BorderRadius = 10;
            ButtonDel.BorderSize = 0;
            ButtonDel.FlatAppearance.BorderSize = 0;
            ButtonDel.FlatStyle = FlatStyle.Flat;
            ButtonDel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            ButtonDel.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonDel.Location = new Point(657, 300);
            ButtonDel.Name = "ButtonDel";
            ButtonDel.Size = new Size(139, 41);
            ButtonDel.TabIndex = 5;
            ButtonDel.Text = "Удалить";
            ButtonDel.TextColor = Color.FromArgb(70, 119, 207);
            ButtonDel.UseVisualStyleBackColor = false;
            ButtonDel.Click += ButtonDel_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.White;
            label7.Location = new Point(94, 38);
            label7.Name = "label7";
            label7.Size = new Size(623, 54);
            label7.TabIndex = 28;
            label7.Text = "Уровни учеников и материалов";
            // 
            // FormLevels
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(800, 354);
            Controls.Add(label7);
            Controls.Add(ButtonDel);
            Controls.Add(ButtonUpd);
            Controls.Add(ButtonSave);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView);
            Name = "FormLevels";
            Text = "Уровни владения и сложности";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.RJControls.RJDataGridView dataGridView;
        private TextBox textBox1;
        private Label label1;
        private CustomControls.RJControls.RJButton ButtonSave;
        private CustomControls.RJControls.RJButton ButtonUpd;
        private CustomControls.RJControls.RJButton ButtonDel;
        private Label label7;
    }
}