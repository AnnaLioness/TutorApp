using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblSelectMaterial = new Label();
            cmbMaterial = new ComboBox();
            DataGridViewPublications = new CustomControls.RJControls.RJDataGridView();
            ButtonPublishNow = new CustomControls.RJControls.RJButton();
            ButtonRef = new CustomControls.RJControls.RJButton();
            textBoxPictures = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewPublications).BeginInit();
            SuspendLayout();
            // 
            // lblSelectMaterial
            // 
            lblSelectMaterial.AutoSize = true;
            lblSelectMaterial.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblSelectMaterial.ForeColor = Color.White;
            lblSelectMaterial.Location = new Point(12, 523);
            lblSelectMaterial.Name = "lblSelectMaterial";
            lblSelectMaterial.Size = new Size(174, 23);
            lblSelectMaterial.TabIndex = 1;
            lblSelectMaterial.Text = "Выберите материал:";
            // 
            // cmbMaterial
            // 
            cmbMaterial.BackColor = Color.White;
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cmbMaterial.Location = new Point(192, 520);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(300, 31);
            cmbMaterial.TabIndex = 2;
            // 
            // DataGridViewPublications
            // 
            DataGridViewPublications.AllowUserToAddRows = false;
            DataGridViewPublications.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(70, 119, 207);
            DataGridViewPublications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewPublications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridViewPublications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewPublications.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewPublications.BackgroundColor = Color.FromArgb(130, 179, 255);
            DataGridViewPublications.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridViewPublications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridViewPublications.ColumnHeadersHeight = 30;
            DataGridViewPublications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewPublications.EnableHeadersVisualStyles = false;
            DataGridViewPublications.GridColor = Color.RoyalBlue;
            DataGridViewPublications.GridColorCustom = Color.RoyalBlue;
            DataGridViewPublications.HeaderBackColor = Color.White;
            DataGridViewPublications.HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            DataGridViewPublications.HeaderForeColor = Color.FromArgb(70, 119, 207);
            DataGridViewPublications.Location = new Point(12, 122);
            DataGridViewPublications.Name = "DataGridViewPublications";
            DataGridViewPublications.ReadOnly = true;
            DataGridViewPublications.RowHeadersVisible = false;
            DataGridViewPublications.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(70, 119, 207);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(100, 120, 200);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            DataGridViewPublications.RowsDefaultCellStyle = dataGridViewCellStyle3;
            DataGridViewPublications.RowsFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DataGridViewPublications.RowsForeColor = Color.FromArgb(70, 119, 207);
            DataGridViewPublications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewPublications.Size = new Size(600, 301);
            DataGridViewPublications.TabIndex = 6;
            // 
            // ButtonPublishNow
            // 
            ButtonPublishNow.BackColor = Color.White;
            ButtonPublishNow.BackgroundColor = Color.White;
            ButtonPublishNow.BorderColor = Color.PaleVioletRed;
            ButtonPublishNow.BorderRadius = 10;
            ButtonPublishNow.BorderSize = 0;
            ButtonPublishNow.FlatAppearance.BorderSize = 0;
            ButtonPublishNow.FlatStyle = FlatStyle.Flat;
            ButtonPublishNow.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonPublishNow.ForeColor = Color.FromArgb(70, 119, 207);
            ButtonPublishNow.Location = new Point(12, 573);
            ButtonPublishNow.Name = "ButtonPublishNow";
            ButtonPublishNow.Size = new Size(279, 45);
            ButtonPublishNow.TabIndex = 12;
            ButtonPublishNow.Text = "🚀 Опубликовать сейчас";
            ButtonPublishNow.TextColor = Color.FromArgb(70, 119, 207);
            ButtonPublishNow.UseVisualStyleBackColor = false;
            ButtonPublishNow.Click += ButtonPublishNow_Click;
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
            ButtonRef.Location = new Point(539, 573);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(73, 45);
            ButtonRef.TabIndex = 13;
            ButtonRef.Text = "🔄";
            ButtonRef.TextColor = Color.White;
            ButtonRef.UseVisualStyleBackColor = false;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // textBoxPictures
            // 
            textBoxPictures.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxPictures.Location = new Point(12, 474);
            textBoxPictures.Multiline = true;
            textBoxPictures.Name = "textBoxPictures";
            textBoxPictures.Size = new Size(600, 34);
            textBoxPictures.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 445);
            label1.Name = "label1";
            label1.Size = new Size(438, 20);
            label1.TabIndex = 15;
            label1.Text = "Добавьте прямые ссылки на картинки(до 10) через запятую:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(196, 65);
            label2.Name = "label2";
            label2.Size = new Size(257, 54);
            label2.TabIndex = 16;
            label2.Text = "Публикации";
            // 
            // FormPublications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(130, 179, 255);
            ClientSize = new Size(624, 628);
            Controls.Add(label2);
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
        private Label label2;
    }
}