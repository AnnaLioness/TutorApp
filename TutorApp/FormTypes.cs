using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorApp
{
    public partial class FormTypes : Form
    {
        private readonly DictionaryService _dictionaryService;
        private List<TypeModel> _types = new();
        public FormTypes(DictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
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
            System.Windows.Forms.Label titleLabel = new System.Windows.Forms.Label();
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

            SetupDataGridView();

            // Загружаем уровни
            //LoadTypesAsync();
            SetupComboBox();
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
        public async Task SetupComboBox()
        {
            var subjects = await _dictionaryService.GetAllSubjects();
            comboBox1.DataSource = subjects;
            comboBox1.DisplayMember = "SubjectName";
            comboBox1.ValueMember = "Id";
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
            var subidColumn = new DataGridViewTextBoxColumn
            {
                Name = "SubjectId",
                DataPropertyName = "SubjectId",
                Visible = false
            };
            dataGridView.Columns.Add(subidColumn);

            // Колонка Название уровня
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "TypeName",
                DataPropertyName = "TypeName",
                HeaderText = "Название направления отработки",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView.Columns.Add(nameColumn);
        }

        private async void ButtonAddSubj_Click(object sender, EventArgs e)
        {
            try
            {
                var subjectsForm = Program.ServiceProvider.GetRequiredService<FormSubjects>();
                subjectsForm.ShowDialog(); // Открываем модально

                SetupComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы уровней: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            var selectedSubj = comboBox1.SelectedValue;
            // Проверка 
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите название типа занятия", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!comboBox1.Enabled || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Нет доступных предметов для выбора. Сначала добавьте предметы в справочник.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _dictionaryService.CreateType(textBox1.Text.Trim(), (int)selectedSubj);
            await LoadTypesForSelectedSubject();
        }

        private async void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _types.Count) return;
            var id = _types[index].Id;
            var selectedSubj = comboBox1.SelectedValue;
            string newTypeName = textBox1.Text.Trim();
            // Проверка 
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите название типа занятия", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!comboBox1.Enabled || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Нет доступных предметов для выбора. Сначала добавьте предметы в справочник.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _dictionaryService.UpdateType(id, newTypeName, (int)selectedSubj);
            await LoadTypesForSelectedSubject();
        }

        private async void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _types.Count) return;

            var id = _types[index].Id;

            var result = MessageBox.Show("Удалить выбранный тип занятия?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _dictionaryService.DeleteType(id);
                await LoadTypesForSelectedSubject();

            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                await LoadTypesForSelectedSubject();
            }
        }
        private async Task LoadTypesForSelectedSubject()
        {
            if (comboBox1.SelectedItem == null)
                return;

            var selectedSubject = (SubjectModel)comboBox1.SelectedItem;

            // Загружаем типы для выбранного предмета
            _types = (await _dictionaryService.GetTypesBySubject(selectedSubject.Id)).ToList();

            dataGridView.DataSource = _types;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _types.Count) return;

            var selected = _types[index];
            textBox1.Text = selected.TypeName;
        }
    }
}
