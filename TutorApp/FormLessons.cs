using Microsoft.Extensions.DependencyInjection;
using Models.Enums;
using Models.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorApp
{
    public partial class FormLessons : Form
    {
        private readonly LessonService _lessonService;
        private readonly StudentService _studentService;
        private readonly DictionaryService _dictionaryService;
        private List<LessonModel> _lessons = new();
        private List<StudentModel> _students = new();
        private List<TypeModel> _types = new();
        private List<SubjectModel> _subjects = new();
        private bool _isDeleting = false;
        private readonly Dictionary<DayOfWeek, string> _russianDays = new()
        {
            { DayOfWeek.Monday, "Понедельник" },
            { DayOfWeek.Tuesday, "Вторник" },
            { DayOfWeek.Wednesday, "Среда" },
            { DayOfWeek.Thursday, "Четверг" },
            { DayOfWeek.Friday, "Пятница" },
            { DayOfWeek.Saturday, "Суббота" },
            { DayOfWeek.Sunday, "Воскресенье" }
        };

        public FormLessons(LessonService lessonService,
            StudentService studentService,
            DictionaryService dictionaryService)
        {
            InitializeComponent();
            _lessonService = lessonService;
            _studentService = studentService;
            _dictionaryService = dictionaryService;

            SetupDataGridView();
            LoadDataAsync();
        }
        private void SetupDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            // ID (скрытый)
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Дата
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Дата",

            });

            // День недели
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DayOfWeek",
                HeaderText = "День недели",

            });

            // Время
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Time",
                HeaderText = "Время",

            });

            // Ученик
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentName",
                HeaderText = "Ученик",

            });

            // Тип занятия
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TypeName",
                HeaderText = "Направление отработки",

            });

            // Предмет
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubjectName",
                HeaderText = "Предмет",

            });

            // Цена
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Цена",

            });

            // Статус
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Статус",

            });

            // Комментарий
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Comment",
                HeaderText = "Комментарий",

            });

            // Кнопка "Провести"
            dataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "CompleteButton",
                HeaderText = "",
                Text = "✅ Провести",
                UseColumnTextForButtonValue = true,

            });

            // Кнопка "Отменить"
            dataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "CancelButton",
                HeaderText = "",
                Text = "❌ Отменить",
                UseColumnTextForButtonValue = true,

            });

            // Кнопка "Удалить"
            dataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "",
                Text = "🗑️ Удалить",
                UseColumnTextForButtonValue = true,

            });

            dataGridView.CellClick += DataGridView_CellClick;
        }
        private async void LoadDataAsync()
        {
            try
            {
                var lessonsTask = _lessonService.GetAllLessons();
                var studentsTask = _studentService.GetAllStudents();
                var typesTask = _dictionaryService.GetAllTypes();
                var subjectsTask = _dictionaryService.GetAllSubjects();

                await Task.WhenAll(lessonsTask, studentsTask, typesTask, subjectsTask);

                _lessons = lessonsTask.Result.ToList();
                _students = studentsTask.Result.ToList();
                _types = typesTask.Result.ToList();
                _subjects = subjectsTask.Result.ToList();

                DisplayLessons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisplayLessons();
            }
        }
        private void DisplayLessons()
        {
            try
            {
                dataGridView.Rows.Clear();

                foreach (var lesson in _lessons.OrderBy(l => l.Date).ThenBy(l => l.Time))
                {
                    string studentName = _students.FirstOrDefault(s => s.Id == lesson.StudentId)?.FullName ?? $"[Ученик {lesson.StudentId}]";

                    var type = _types.FirstOrDefault(t => t.Id == lesson.TypeId);
                    string typeName = type?.TypeName ?? $"[Тип {lesson.TypeId}]";

                    string subjectName = "Неизвестно";
                    if (type != null)
                    {
                        var subject = _subjects.FirstOrDefault(s => s.Id == type.SubjectId);
                        subjectName = subject?.SubjectName ?? $"[Предмет {type.SubjectId}]";
                    }

                    string dayOfWeek = _russianDays.GetValueOrDefault(lesson.Date.DayOfWeek, lesson.Date.DayOfWeek.ToString());

                    string statusText = lesson.Status switch
                    {
                        LessonStatus.Запланирован => "📅 Запланирован",
                        LessonStatus.Проведён => "✅ Проведён",
                        LessonStatus.Отменён => "❌ Отменён",
                        _ => lesson.Status.ToString()
                    };

                    int rowIndex = dataGridView.Rows.Add(
                        lesson.Id,
                        lesson.Date.ToString("dd.MM.yyyy"),
                        dayOfWeek,
                        lesson.Time.ToString("hh\\:mm"),
                        studentName,
                        typeName,
                        subjectName,
                        lesson.Price,
                        statusText,
                        lesson.Comment ?? "",
                        "✅ Провести",
                        "❌ Отменить",
                        "🗑️ Удалить"
                    );

                    // Цвет фона для статуса
                    if (lesson.Status == LessonStatus.Проведён)
                        dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (lesson.Status == LessonStatus.Отменён)
                        dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;

                    dataGridView.Rows[rowIndex].Tag = lesson;
                }

                dataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isDeleting) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= dataGridView.Rows.Count) return;

            var lesson = dataGridView.Rows[e.RowIndex].Tag as LessonModel;
            if (lesson == null) return;

            var columnName = dataGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "CompleteButton")
                await CompleteLesson(lesson);
            else if (columnName == "CancelButton")
                await CancelLesson(lesson);
            else if (columnName == "DeleteButton")
            {
                _isDeleting = true;
                await DeleteLesson(lesson);
                _ = Task.Delay(500).ContinueWith(_ => _isDeleting = false,
                    TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        private async Task CompleteLesson(LessonModel lesson)
        {
            if (lesson.Status != LessonStatus.Запланирован)
            {
                MessageBox.Show("Можно провести только запланированный урок", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Отметить урок как проведённый?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var (success, message) = await _lessonService.CompleteLesson(lesson.Id);

            if (success)
                LoadDataAsync();
            else
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task CancelLesson(LessonModel lesson)
        {
            if (lesson.Status != LessonStatus.Запланирован)
            {
                MessageBox.Show("Можно отменить только запланированный урок", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Отменить урок?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var (success, message) = await _lessonService.CancelLesson(lesson.Id);

            if (success)
                LoadDataAsync();
            else
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task DeleteLesson(LessonModel lesson)
        {
            var result = MessageBox.Show($"Удалить урок?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            // Здесь должен быть метод удаления в сервисе
            _lessons.Remove(lesson);
            DisplayLessons();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем форму через DI
                var lessonForm = Program.ServiceProvider.GetRequiredService<FormLesson>();

                // Передаем null для режима добавления
                //studentForm.SetStudent(null, _levels);

                // Показываем форму и ждем результат
                if (lessonForm.ShowDialog() == DialogResult.OK)
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

        private async void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите урок для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {

                int id = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;

                var lesson = await _lessonService.GetLessonById(id);

                if (lesson == null)
                {
                    MessageBox.Show("Не удалось найти данные ученика",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем форму через DI
                var lessonForm = Program.ServiceProvider.GetRequiredService<FormLesson>();

                // Передаем ученика для редактирования
                lessonForm.SetLesson(lesson, _types, _students);

                // Показываем форму и ждем результат
                if (lessonForm.ShowDialog() == DialogResult.OK)
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
    }
}
