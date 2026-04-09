namespace TutorApp
{
    partial class FormPublications
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            lblSelectMaterial = new Label();
            cmbMaterial = new ComboBox();
            DataGridViewPublications = new CustomControls.RJControls.RJDataGridView();
            ButtonPublishNow = new CustomControls.RJControls.RJButton();
            ButtonRef = new CustomControls.RJControls.RJButton();
            textBoxPictures = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewPublications).BeginInit();
            SuspendLayout();
            // 
            // lblSelectMaterial
            // 
            lblSelectMaterial.AutoSize = true;
            lblSelectMaterial.Font = new Font("Segoe UI", 10F);
            lblSelectMaterial.Location = new Point(12, 404);
            lblSelectMaterial.Name = "lblSelectMaterial";
            lblSelectMaterial.Size = new Size(171, 23);
            lblSelectMaterial.TabIndex = 1;
            lblSelectMaterial.Text = "Выберите материал:";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.Font = new Font("Segoe UI", 10F);
            cmbMaterial.Location = new Point(182, 401);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(300, 31);
            cmbMaterial.TabIndex = 2;
            // 
            // DataGridViewPublications
            // 
            DataGridViewPublications.AllowUserToAddRows = false;
            DataGridViewPublications.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            DataGridViewPublications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            DataGridViewPublications.BackgroundColor = Color.White;
            DataGridViewPublications.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.DeepSkyBlue;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DataGridViewPublications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DataGridViewPublications.ColumnHeadersHeight = 30;
            DataGridViewPublications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewPublications.EnableHeadersVisualStyles = false;
            DataGridViewPublications.GridColor = Color.LightGray;
            DataGridViewPublications.GridColorCustom = Color.LightGray;
            DataGridViewPublications.HeaderBackColor = Color.DeepSkyBlue;
            DataGridViewPublications.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            DataGridViewPublications.HeaderForeColor = Color.White;
            DataGridViewPublications.Location = new Point(12, 12);
            DataGridViewPublications.Name = "DataGridViewPublications";
            DataGridViewPublications.ReadOnly = true;
            DataGridViewPublications.RowHeadersVisible = false;
            DataGridViewPublications.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(100, 120, 200);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            DataGridViewPublications.RowsDefaultCellStyle = dataGridViewCellStyle6;
            DataGridViewPublications.RowsFont = new Font("Segoe UI", 9F);
            DataGridViewPublications.RowsForeColor = Color.Black;
            DataGridViewPublications.Size = new Size(600, 301);
            DataGridViewPublications.TabIndex = 6;
            // 
            // ButtonPublishNow
            // 
            ButtonPublishNow.BackColor = Color.DeepSkyBlue;
            ButtonPublishNow.BackgroundColor = Color.DeepSkyBlue;
            ButtonPublishNow.BorderColor = Color.PaleVioletRed;
            ButtonPublishNow.BorderRadius = 10;
            ButtonPublishNow.BorderSize = 0;
            ButtonPublishNow.FlatAppearance.BorderSize = 0;
            ButtonPublishNow.FlatStyle = FlatStyle.Flat;
            ButtonPublishNow.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ButtonPublishNow.ForeColor = Color.Black;
            ButtonPublishNow.Location = new Point(12, 454);
            ButtonPublishNow.Name = "ButtonPublishNow";
            ButtonPublishNow.Size = new Size(279, 45);
            ButtonPublishNow.TabIndex = 12;
            ButtonPublishNow.Text = "🚀 Опубликовать сейчас";
            ButtonPublishNow.TextColor = Color.Black;
            ButtonPublishNow.UseVisualStyleBackColor = false;
            ButtonPublishNow.Click += ButtonPublishNow_Click;
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
            ButtonRef.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ButtonRef.ForeColor = Color.Black;
            ButtonRef.Location = new Point(539, 454);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(73, 45);
            ButtonRef.TabIndex = 13;
            ButtonRef.Text = "🔄";
            ButtonRef.TextColor = Color.Black;
            ButtonRef.UseVisualStyleBackColor = false;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // textBoxPictures
            // 
            textBoxPictures.Location = new Point(12, 355);
            textBoxPictures.Multiline = true;
            textBoxPictures.Name = "textBoxPictures";
            textBoxPictures.Size = new Size(600, 34);
            textBoxPictures.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 326);
            label1.Name = "label1";
            label1.Size = new Size(432, 20);
            label1.TabIndex = 15;
            label1.Text = "Добавьте прямые ссылки на картинки(до 10) через запятую:";
            // 
            // FormPublications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 511);
            Controls.Add(label1);
            Controls.Add(textBoxPictures);
            Controls.Add(ButtonRef);
            Controls.Add(ButtonPublishNow);
            Controls.Add(DataGridViewPublications);
            Controls.Add(cmbMaterial);
            Controls.Add(lblSelectMaterial);
            Name = "FormPublications";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление публикациями";
            ((System.ComponentModel.ISupportInitialize)DataGridViewPublications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblSelectMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Button btnPublishNow;
        private System.Windows.Forms.Button btnRefresh;
        private CustomControls.RJControls.RJDataGridView DataGridViewPublications;
        private CustomControls.RJControls.RJButton ButtonPublishNow;
        private CustomControls.RJControls.RJButton ButtonRef;
        private TextBox textBoxPictures;
        private Label label1;
    }
}