namespace TutorApp
{
    partial class FormLessons
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
            ButtonAdd = new CustomControls.RJControls.RJButton();
            label1 = new Label();
            dataGridView = new CustomControls.RJControls.RJDataGridView();
            ButtonUpd = new CustomControls.RJControls.RJButton();
            ButtonRef = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // ButtonAdd
            // 
            ButtonAdd.BackColor = Color.White;
            ButtonAdd.BackgroundColor = Color.White;
            ButtonAdd.BorderColor = Color.PaleVioletRed;
            ButtonAdd.BorderRadius = 10;
            ButtonAdd.BorderSize = 0;
            ButtonAdd.FlatAppearance.BorderSize = 0;
            ButtonAdd.FlatStyle = FlatStyle.Flat;
            ButtonAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAdd.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonAdd.Location = new Point(11, 143);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(223, 50);
            ButtonAdd.TabIndex = 11;
            ButtonAdd.Text = "Добавить урок";
            ButtonAdd.TextColor = Color.FromArgb(70, 119, 207);
            ButtonAdd.UseVisualStyleBackColor = false;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(400, 76);
            label1.Name = "label1";
            label1.Size = new Size(139, 54);
            label1.TabIndex = 12;
            label1.Text = "Уроки";
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
            dataGridView.Location = new Point(11, 202);
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
            dataGridView.Size = new Size(941, 307);
            dataGridView.TabIndex = 2;
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
            ButtonUpd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonUpd.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonUpd.Location = new Point(240, 143);
            ButtonUpd.Name = "ButtonUpd";
            ButtonUpd.Size = new Size(223, 50);
            ButtonUpd.TabIndex = 14;
            ButtonUpd.Text = "Редактировать урок";
            ButtonUpd.TextColor = Color.FromArgb(70, 119, 207);
            ButtonUpd.UseVisualStyleBackColor = false;
            ButtonUpd.Click += ButtonUpd_Click;
            // 
            // ButtonRef
            // 
            ButtonRef.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonRef.BackColor = Color.FromArgb(130, 179, 255);
            ButtonRef.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonRef.BorderColor = Color.White;
            ButtonRef.BorderRadius = 10;
            ButtonRef.BorderSize = 1;
            ButtonRef.FlatAppearance.BorderSize = 0;
            ButtonRef.FlatStyle = FlatStyle.Flat;
            ButtonRef.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonRef.ForeColor = Color.White;
            ButtonRef.Location = new Point(763, 150);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(188, 43);
            ButtonRef.TabIndex = 15;
            ButtonRef.Text = "Обновить";
            ButtonRef.TextColor = Color.White;
            ButtonRef.UseVisualStyleBackColor = false;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // FormLessons
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(964, 558);
            Controls.Add(ButtonRef);
            Controls.Add(ButtonUpd);
            Controls.Add(dataGridView);
            Controls.Add(label1);
            Controls.Add(ButtonAdd);
            Name = "FormLessons";
            Text = "Уроки";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.RJControls.RJButton ButtonAdd;
        private Label label1;
        private CustomControls.RJControls.RJDataGridView dataGridView;
        private CustomControls.RJControls.RJButton ButtonUpd;
        private CustomControls.RJControls.RJButton ButtonRef;
    }
}