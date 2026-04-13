using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CustomControls.RJControls
{
    public class RJDataGridView : DataGridView
    {
        // Fields
        private Color headerBackColor = Color.White;
        private Color headerForeColor = Color.FromArgb(100, 149, 237);
        private Font headerFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        private Color gridColor = Color.RoyalBlue;

        // Colors for rows
        private Color rowsBackColor = Color.FromArgb(100, 149, 237);
        private Color rowsForeColor = Color.White;
        private Font rowsFont = new Font("Segoe UI", 9F);

        // Selection colors
        private Color selectionBackColor = Color.White;
        private Color selectionForeColor = Color.FromArgb(100, 149, 237);

        // Alternate row color
        private Color alternateRowsBackColor = Color.FromArgb(100, 149, 237);

        // Constructor
        public RJDataGridView()
        {
            this.DoubleBuffered = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.BorderStyle = BorderStyle.None;
            this.BackgroundColor = Color.FromArgb(100, 149, 237);
            this.EnableHeadersVisualStyles = false;

            // Настройки сетки - статичная RoyalBlue
            this.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.GridColor = Color.RoyalBlue;

            // Подписываемся на события
            this.RowPrePaint += RJDataGridView_RowPrePaint;

            // Apply default styles
            UpdateHeaderStyle();
            UpdateRowsStyle();
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
        public Color RowsBackColor
        {
            get { return rowsBackColor; }
            set
            {
                rowsBackColor = value;
                UpdateRowsStyle();
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
        public Color AlternateRowsBackColor
        {
            get { return alternateRowsBackColor; }
            set
            {
                alternateRowsBackColor = value;
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

        [Category("RJ Code Advance")]
        public Color SelectionBackColor
        {
            get { return selectionBackColor; }
            set
            {
                selectionBackColor = value;
                UpdateRowsStyle();
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color SelectionForeColor
        {
            get { return selectionForeColor; }
            set
            {
                selectionForeColor = value;
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
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersHeight = 35;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Header border
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBackColor;
        }

        private void UpdateRowsStyle()
        {
            // Default row style (for odd rows)
            this.RowsDefaultCellStyle.BackColor = rowsBackColor;
            this.RowsDefaultCellStyle.ForeColor = rowsForeColor;
            this.RowsDefaultCellStyle.Font = rowsFont;
            this.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.RowsDefaultCellStyle.SelectionBackColor = selectionBackColor;
            this.RowsDefaultCellStyle.SelectionForeColor = selectionForeColor;

            // Alternate row style (for even rows)
            this.AlternatingRowsDefaultCellStyle.BackColor = alternateRowsBackColor;
            this.AlternatingRowsDefaultCellStyle.ForeColor = rowsForeColor;
            this.AlternatingRowsDefaultCellStyle.Font = rowsFont;
            this.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.AlternatingRowsDefaultCellStyle.SelectionBackColor = selectionBackColor;
            this.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectionForeColor;
        }

        private void RJDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Обеспечиваем правильное отображение при выборе
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.Rows[e.RowIndex];

                if (row.Selected)
                {
                    row.DefaultCellStyle.BackColor = selectionBackColor;
                    row.DefaultCellStyle.ForeColor = selectionForeColor;
                }
                else
                {
                    if (e.RowIndex % 2 == 0)
                    {
                        row.DefaultCellStyle.BackColor = rowsBackColor;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = alternateRowsBackColor;
                    }
                    row.DefaultCellStyle.ForeColor = rowsForeColor;
                }
            }
        }

        // Переопределяем для обновления при изменении выбора
        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
            this.Invalidate();
        }

        // Переопределяем для кастомной отрисовки
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем нижнюю границу для заголовка
            if (this.ColumnHeadersVisible)
            {
                using (Pen pen = new Pen(Color.RoyalBlue, 2))
                {
                    e.Graphics.DrawLine(pen, 0, this.ColumnHeadersHeight, this.Width, this.ColumnHeadersHeight);
                }
            }
        }
    }
}