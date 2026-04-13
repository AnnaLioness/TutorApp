namespace TutorApp
{
    partial class FormStudents
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
            label1 = new Label();
            ButtonAdd = new CustomControls.RJControls.RJButton();
            dataGridView = new CustomControls.RJControls.RJDataGridView();
            ButtonUpdate = new CustomControls.RJControls.RJButton();
            ButtonRef = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(381, 64);
            label1.Name = "label1";
            label1.Size = new Size(184, 54);
            label1.TabIndex = 0;
            label1.Text = "Ученики";
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
            ButtonAdd.Location = new Point(12, 137);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(225, 43);
            ButtonAdd.TabIndex = 1;
            ButtonAdd.Text = "Добавить ученика";
            ButtonAdd.TextColor = Color.FromArgb(70, 119, 207);
            ButtonAdd.UseVisualStyleBackColor = false;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AlternateRowsBackColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.FromArgb(130, 179, 255);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.RoyalBlue;
            dataGridView.GridColorCustom = Color.RoyalBlue;
            dataGridView.HeaderBackColor = Color.White;
            dataGridView.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView.HeaderForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.Location = new Point(12, 205);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowsBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowsFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridView.RowsForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.SelectionBackColor = Color.White;
            dataGridView.SelectionForeColor = Color.FromArgb(70, 119, 207);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(950, 307);
            dataGridView.TabIndex = 2;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.BackColor = Color.White;
            ButtonUpdate.BackgroundColor = Color.White;
            ButtonUpdate.BorderColor = Color.PaleVioletRed;
            ButtonUpdate.BorderRadius = 10;
            ButtonUpdate.BorderSize = 0;
            ButtonUpdate.FlatAppearance.BorderSize = 0;
            ButtonUpdate.FlatStyle = FlatStyle.Flat;
            ButtonUpdate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonUpdate.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonUpdate.Location = new Point(257, 137);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(188, 43);
            ButtonUpdate.TabIndex = 3;
            ButtonUpdate.Text = "Редактировать";
            ButtonUpdate.TextColor = Color.FromArgb(70, 119, 207);
            ButtonUpdate.UseVisualStyleBackColor = false;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // ButtonRef
            // 
            ButtonRef.BackColor = Color.FromArgb(130, 179, 255);
            ButtonRef.BackgroundColor = Color.FromArgb(130, 179, 255);
            ButtonRef.BorderColor = Color.White;
            ButtonRef.BorderRadius = 10;
            ButtonRef.BorderSize = 1;
            ButtonRef.FlatAppearance.BorderSize = 0;
            ButtonRef.FlatStyle = FlatStyle.Flat;
            ButtonRef.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonRef.ForeColor = Color.White;
            ButtonRef.Location = new Point(774, 137);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(188, 43);
            ButtonRef.TabIndex = 4;
            ButtonRef.Text = "Обновить";
            ButtonRef.TextColor = Color.White;
            ButtonRef.UseVisualStyleBackColor = false;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // FormStudents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(974, 524);
            Controls.Add(ButtonRef);
            Controls.Add(ButtonUpdate);
            Controls.Add(dataGridView);
            Controls.Add(ButtonAdd);
            Controls.Add(label1);
            Name = "FormStudents";
            Text = "Ученики";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CustomControls.RJControls.RJButton ButtonAdd;
        private CustomControls.RJControls.RJDataGridView dataGridView;
        private CustomControls.RJControls.RJButton ButtonUpdate;
        private CustomControls.RJControls.RJButton ButtonRef;
    }
}