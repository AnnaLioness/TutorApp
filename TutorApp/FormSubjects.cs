using Models.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorApp
{
    public partial class FormSubjects : Form
    {
        private readonly DictionaryService _dictionaryService;
        private List<SubjectModel> _subjects = new();
        public FormSubjects(DictionaryService dictionaryService)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            // Создаем свою панель-шапку
            Panel titleBar = new Panel();
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;
            titleBar.BackColor = Color.RoyalBlue; // Ваш цвет

            // Добавляем кнопку закрытия
            System.Windows.Forms.Button closeBtn = new System.Windows.Forms.Button();
            closeBtn.Text = "X";
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.ForeColor = Color.White;
            closeBtn.Size = new Size(40, 40);
            closeBtn.Dock = DockStyle.Right;
            closeBtn.Click += (s, e) => this.Close();

            // Добавляем заголовок
            Label titleLabel = new Label();
            titleLabel.Text = this.Text;
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(10, 10);
            titleLabel.AutoSize = true;

            // Добавляем возможность перетаскивать окно
            bool dragging = false;
            Point startPoint = Point.Empty;

            titleBar.MouseDown += (s, e) =>
            {
                dragging = true;
                startPoint = new Point(e.X, e.Y);
            };

            titleBar.MouseMove += (s, e) =>
            {
                if (dragging)
                {
                    Point p = PointToScreen(e.Location);
                    this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };

            titleBar.MouseUp += (s, e) => dragging = false;

            titleBar.Controls.Add(closeBtn);
            titleBar.Controls.Add(titleLabel);
            this.Controls.Add(titleBar);

            _dictionaryService = dictionaryService;

            // Настраиваем DataGridView
            SetupDataGridView();

            // Загружаем уровни
            LoadSubjectsAsync();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем рамку вокруг формы
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                using (Pen pen = new Pen(Color.RoyalBlue, 5))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
        private void SetupDataGridView()
        {
            // Настраиваем колонки вручную, так как AutoGenerateColumns может быть включено
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            // Колонка ID (скрытая)
            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };
            dataGridView.Columns.Add(idColumn);

            // Колонка Название уровня
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "SubjectName",
                DataPropertyName = "SubjectName",
                HeaderText = "Название предмета",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView.Columns.Add(nameColumn);
        }
        private async Task LoadSubjectsAsync()
        {
            _subjects = (await _dictionaryService.GetAllSubjects()).ToList();
            dataGridView.DataSource = _subjects.Select(p => new
            {
                p.SubjectName
            }).ToList();
            ClearInputFields();
        }
        private void ClearInputFields()
        {
            textBox1.Clear();
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            string subjectName = textBox1.Text.Trim();

            await _dictionaryService.CreateSubject(subjectName);
            LoadSubjectsAsync();
        }

        private async void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _subjects.Count) return;
            var id = _subjects[index].Id;

            string newSubjectName = textBox1.Text.Trim();


            await _dictionaryService.UpdateSubject(id, newSubjectName);
            LoadSubjectsAsync();
        }

        private async void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _subjects.Count) return;

            var id = _subjects[index].Id;

            var result = MessageBox.Show("Удалить выбранный предмет?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _dictionaryService.DeleteSubject(id);
                await LoadSubjectsAsync();

            }

        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _subjects.Count) return;

            var selected = _subjects[index];
            textBox1.Text = selected.SubjectName;
        }
    }
}
