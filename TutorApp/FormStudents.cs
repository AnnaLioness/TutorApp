using Microsoft.Extensions.DependencyInjection;
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
    public partial class FormStudents : Form
    {
        private readonly StudentService _studentService;
        private readonly DictionaryService _dictionaryService;
        private List<StudentModel> _students = new();
        private List<LevelModel> _levels = new();
        public FormStudents(StudentService studentService, DictionaryService dictionaryService)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            // Создаем свою панель-шапку
            Panel titleBar = new Panel();
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;
            titleBar.BackColor = Color.RoyalBlue; // Ваш цвет

            // Добавляем кнопку закрытия
            Button closeBtn = new Button();
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

            titleBar.MouseDown += (s, e) => {
                dragging = true;
                startPoint = new Point(e.X, e.Y);
            };

            titleBar.MouseMove += (s, e) => {
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

            _studentService = studentService;
            _dictionaryService = dictionaryService;
            SetupDataGridView();

            // Загружаем данные при открытии формы
            LoadDataAsync();
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
            // Отключаем автоматическую генерацию колонок
            dataGridView.AutoGenerateColumns = false;

            // Очищаем колонки
            dataGridView.Columns.Clear();

            // Колонка ID (скрытая)
            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };
            dataGridView.Columns.Add(idColumn);

            // Колонка ФИО
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "ФИО",
                Width = 250,
            };
            dataGridView.Columns.Add(nameColumn);

            // Колонка Возраст
            var ageColumn = new DataGridViewTextBoxColumn
            {
                Name = "Age",
                DataPropertyName = "Age",
                HeaderText = "Возраст",
                Width = 80,
            };
            dataGridView.Columns.Add(ageColumn);

            // Колонка Телефон
            var phoneColumn = new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                DataPropertyName = "Phone",
                HeaderText = "Телефон",
                Width = 150
            };
            dataGridView.Columns.Add(phoneColumn);

            // Колонка Уровень (текст, не ID)
            var levelColumn = new DataGridViewTextBoxColumn
            {
                Name = "LevelName",
                HeaderText = "Уровень",
                Width = 150
            };
            dataGridView.Columns.Add(levelColumn);

            // Колонка с кнопкой удаления
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "",
                Text = "🗑️ Удалить",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat,

            };
            dataGridView.Columns.Add(deleteButtonColumn);

            // Обработчик клика по кнопкам
            dataGridView.CellClick += dataGridView_CellClick;
        }
        private async void LoadDataAsync()
        {
            try
            {
                // Загружаем учеников и уровни параллельно
                var studentsTask = _studentService.GetAllStudents();
                var levelsTask = _dictionaryService.GetAllLevels();

                await Task.WhenAll(studentsTask, levelsTask);

                _students = studentsTask.Result.ToList();
                _levels = levelsTask.Result.ToList();

                // Отображаем учеников
                DisplayStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Даже при ошибке показываем пустой список
                DisplayStudents();
            }
        }
        private void DisplayStudents()
        {
            try
            {
                // Очищаем строки
                dataGridView.Rows.Clear();

                foreach (var student in _students)
                {
                    // Получаем название уровня
                    string levelName = GetLevelName(student.LevelId);

                    // Добавляем строку
                    int rowIndex = dataGridView.Rows.Add(
                        student.Id,           // ID (скрытый)
                        student.FullName,      // ФИО
                        student.Age,           // Возраст
                        student.Phone,         // Телефон
                        levelName,             // Название уровня
                        "🗑️ Удалить"          // Текст кнопки
                    );

                    // Сохраняем ID студента в теге строки для удобства
                    dataGridView.Rows[rowIndex].Tag = student;
                }
                dataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetLevelName(int levelId)
        {
            try
            {
                // Пытаемся найти уровень по ID
                var level = _levels.FirstOrDefault(l => l.Id == levelId);

                if (level != null)
                    return level.LevelName;

                // Если уровень не найден, но есть ID
                if (levelId > 0)
                    return $"[Уровень {levelId}]";

                return "Не указан";
            }
            catch
            {
                // При любой ошибке возвращаем заглушку
                return "Ошибка";
            }
        }
        private void ConfigureDataGridView()
        {
            if (dataGridView.Columns.Count == 0)
                return;

            // Скрываем служебные колонки
            if (dataGridView.Columns.Contains("LevelId"))
                dataGridView.Columns["LevelId"].Visible = false;
            if (dataGridView.Columns.Contains("Id"))
                dataGridView.Columns["Id"].Visible = false;

            // Настраиваем видимые колонки
            if (dataGridView.Columns.Contains("FullName"))
            {
                dataGridView.Columns["FullName"].HeaderText = "ФИО";
                dataGridView.Columns["FullName"].Width = 250;
                dataGridView.Columns["FullName"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            if (dataGridView.Columns.Contains("Age"))
            {
                dataGridView.Columns["Age"].HeaderText = "Возраст";
                dataGridView.Columns["Age"].Width = 80;
                dataGridView.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataGridView.Columns.Contains("Phone"))
            {
                dataGridView.Columns["Phone"].HeaderText = "Телефон";
                dataGridView.Columns["Phone"].Width = 150;
            }

            if (dataGridView.Columns.Contains("LevelName"))
            {
                dataGridView.Columns["LevelName"].HeaderText = "Уровень";
                dataGridView.Columns["LevelName"].Width = 150;
                dataGridView.Columns["LevelName"].DefaultCellStyle.ForeColor = Color.Blue;
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем форму через DI
                var studentForm = Program.ServiceProvider.GetRequiredService<FormStudent>();

                // Передаем null для режима добавления
                //studentForm.SetStudent(null, _levels);

                // Показываем форму и ждем результат
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем данные после добавления
                    LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ученика для редактирования",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {

                int id = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;

                var stud = await _studentService.GetStudentById(id);

                if (stud == null)
                {
                    MessageBox.Show("Не удалось найти данные ученика",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем форму через DI
                var studentForm = Program.ServiceProvider.GetRequiredService<FormStudent>();

                // Передаем ученика для редактирования
                studentForm.SetStudent(stud, _levels);

                // Показываем форму и ждем результат
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем данные после редактирования
                    LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
        private bool _isDeleting = false;

        private async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isDeleting)
                return;
            // Проверяем индексы
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Проверяем, что это кнопка удаления
            if (dataGridView.Columns[e.ColumnIndex].Name != "DeleteButton")
                return;

            // Проверяем, что строка существует
            if (e.RowIndex >= dataGridView.Rows.Count)
                return;

            var student = dataGridView.Rows[e.RowIndex].Tag as StudentModel;
            if (student != null)
            {
                _isDeleting = true;
                await DeleteStudent(student);
                _ = Task.Delay(500).ContinueWith(_ =>
                {
                    _isDeleting = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        // Метод удаления студента
        private async Task DeleteStudent(StudentModel student)
        {
            // Подтверждение удаления
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить ученика {student.FullName}?\n\n" +
                "Все связанные уроки также будут удалены!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                var (success, message) = await _studentService.DeleteStudent(student.Id);

                if (success)
                {
                    // Удаляем из локального списка
                    _students.Remove(student);

                    // Обновляем отображение
                    DisplayStudents();

                    MessageBox.Show("Ученик успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
