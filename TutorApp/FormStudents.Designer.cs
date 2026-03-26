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
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(381, 9);
            label1.Name = "label1";
            label1.Size = new Size(197, 54);
            label1.TabIndex = 0;
            label1.Text = "Ученики";
            // 
            // ButtonAdd
            // 
            ButtonAdd.BackColor = Color.DeepSkyBlue;
            ButtonAdd.BackgroundColor = Color.DeepSkyBlue;
            ButtonAdd.BorderColor = Color.PaleVioletRed;
            ButtonAdd.BorderRadius = 10;
            ButtonAdd.BorderSize = 0;
            ButtonAdd.FlatAppearance.BorderSize = 0;
            ButtonAdd.FlatStyle = FlatStyle.Flat;
            ButtonAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonAdd.ForeColor = Color.Black;
            ButtonAdd.Location = new Point(12, 82);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(225, 43);
            ButtonAdd.TabIndex = 1;
            ButtonAdd.Text = "Добавить ученика";
            ButtonAdd.TextColor = Color.Black;
            ButtonAdd.UseVisualStyleBackColor = false;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
            dataGridView.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView.HeaderForeColor = Color.Black;
            dataGridView.Location = new Point(-1, 131);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(100, 120, 200);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowsFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridView.RowsForeColor = Color.Black;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(974, 317);
            dataGridView.TabIndex = 2;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.BackColor = Color.DeepSkyBlue;
            ButtonUpdate.BackgroundColor = Color.DeepSkyBlue;
            ButtonUpdate.BorderColor = Color.PaleVioletRed;
            ButtonUpdate.BorderRadius = 10;
            ButtonUpdate.BorderSize = 0;
            ButtonUpdate.FlatAppearance.BorderSize = 0;
            ButtonUpdate.FlatStyle = FlatStyle.Flat;
            ButtonUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonUpdate.ForeColor = Color.Black;
            ButtonUpdate.Location = new Point(257, 82);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new Size(188, 43);
            ButtonUpdate.TabIndex = 3;
            ButtonUpdate.Text = "Редактировать";
            ButtonUpdate.TextColor = Color.Black;
            ButtonUpdate.UseVisualStyleBackColor = false;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // ButtonRef
            // 
            ButtonRef.BackColor = Color.DeepSkyBlue;
            ButtonRef.BackgroundColor = Color.DeepSkyBlue;
            ButtonRef.BorderColor = Color.PaleVioletRed;
            ButtonRef.BorderRadius = 10;
            ButtonRef.BorderSize = 0;
            ButtonRef.FlatAppearance.BorderSize = 0;
            ButtonRef.FlatStyle = FlatStyle.Flat;
            ButtonRef.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonRef.ForeColor = Color.Black;
            ButtonRef.Location = new Point(774, 82);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(188, 43);
            ButtonRef.TabIndex = 4;
            ButtonRef.Text = "Обновить";
            ButtonRef.TextColor = Color.Black;
            ButtonRef.UseVisualStyleBackColor = false;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // FormStudents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 450);
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