using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CustomControls.RJControls
{
    public class RJDataGridView : DataGridView
    {
        // Fields
        private Color headerBackColor = Color.MediumSlateBlue;
        private Color headerForeColor = Color.White;
        private Font headerFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        private Color gridColor = Color.LightGray;
        private Color rowsForeColor = Color.Black;
        private Font rowsFont = new Font("Segoe UI", 9F);

        // Constructor
        public RJDataGridView()
        {
            this.DoubleBuffered = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.BorderStyle = BorderStyle.None;
            this.BackgroundColor = Color.White;
            this.EnableHeadersVisualStyles = false;

            // Apply default styles
            UpdateHeaderStyle();
            UpdateRowsStyle();
            this.GridColor = gridColor;
        }

        // Properties
        [Category("RJ Code Advance")]
        public Color HeaderBackColor
        {
            get { return headerBackColor; }
            set
            {
                headerBackColor = value;
                UpdateHeaderStyle();
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color HeaderForeColor
        {
            get { return headerForeColor; }
            set
            {
                headerForeColor = value;
                UpdateHeaderStyle();
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value;
                UpdateHeaderStyle();
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color GridColorCustom
        {
            get { return gridColor; }
            set
            {
                gridColor = value;
                this.GridColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color RowsForeColor
        {
            get { return rowsForeColor; }
            set
            {
                rowsForeColor = value;
                UpdateRowsStyle();
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Font RowsFont
        {
            get { return rowsFont; }
            set
            {
                rowsFont = value;
                UpdateRowsStyle();
                this.Invalidate();
            }
        }

        // Private methods
        private void UpdateHeaderStyle()
        {
            this.ColumnHeadersDefaultCellStyle.BackColor = headerBackColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = headerForeColor;
            this.ColumnHeadersDefaultCellStyle.Font = headerFont;
            this.ColumnHeadersHeight = 30;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void UpdateRowsStyle()
        {
            this.RowsDefaultCellStyle.ForeColor = rowsForeColor;
            this.RowsDefaultCellStyle.Font = rowsFont;
            this.RowsDefaultCellStyle.BackColor = Color.White;
            this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 120, 200);
            this.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            this.AlternatingRowsDefaultCellStyle.ForeColor = rowsForeColor;
            this.AlternatingRowsDefaultCellStyle.Font = rowsFont;
        }

        // Override
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw bottom border for header if needed
            if (this.ColumnHeadersVisible)
            {
                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.DrawLine(pen, 0, this.ColumnHeadersHeight, this.Width, this.ColumnHeadersHeight);
                }
            }
        }
    }
}