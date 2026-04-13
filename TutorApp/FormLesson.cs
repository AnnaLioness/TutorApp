using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TutorApp
{
    public partial class FormLesson : Form
    {
        private readonly LessonService _lessonService;
        private readonly DictionaryService _dictionaryService;
        private readonly StudentService _studentService;
        private LessonModel? _currentLesson;
        private List<TypeModel> _types;
        private List<StudentModel> _students;
        private List<SubjectModel> _subjects;
        private bool _isEditMode => _currentLesson != null;
        public FormLesson(LessonService lessonService, DictionaryService dictionaryService, StudentService studentService)
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

            _studentService = studentService;
            _lessonService = lessonService;
            _dictionaryService = dictionaryService;
            SetupComboBoxes();
            dateTimePickerDate.Format = DateTimePickerFormat.Short;

            // Настройка пикера времени (будут стрелочки)
            dateTimePickerTime.Format = DateTimePickerFormat.Time;
            dateTimePickerTime.ShowUpDown = true;
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
        public async Task SetupComboBoxes()
        {
            var subjects = await _dictionaryService.GetAllSubjects();
            comboBoxSubject.DataSource = subjects;
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "Id";
            /* var types = await _dictionaryService.GetAllTypes();
             comboBoxType.DataSource = types;
             comboBoxType.DisplayMember = "TypeName";
             comboBoxType.ValueMember = "Id";*/
            var students = await _studentService.GetAllStudents();
            comboBoxStudent.DataSource = students;
            comboBoxStudent.DisplayMember = "FullName";
            comboBoxStudent.ValueMember = "Id";
            comboBoxType.Enabled = false;
        }
        private void SelectTypeAndStudentInComboBox(int typeId, int studentId)
        {
            if (comboBoxType.Enabled && _types.Any())
            {
                var type = _types.FirstOrDefault(l => l.Id == typeId);
                if (type != null)
                {
                    comboBoxType.SelectedItem = type;
                    comboBoxSubject.SelectedValue = type.SubjectId;
                    comboBoxType.Enabled = true;
                }
                else if (comboBoxType.Items.Count > 0)
                {
                    comboBoxType.SelectedIndex = 0;
                }
            }
            if (comboBoxStudent.Enabled && _students.Any())
            {
                var student = _students.FirstOrDefault(l => l.Id == studentId);
                if (student != null)
                {
                    comboBoxStudent.SelectedItem = student;
                }
                else if (comboBoxStudent.Items.Count > 0)
                {
                    comboBoxStudent.SelectedIndex = 0;
                }
            }
        }
        private void ButtonAddType_Click(object sender, EventArgs e)
        {
            try
            {
                var typeForm = Program.ServiceProvider.GetRequiredService<FormTypes>();
                typeForm.Show(); // Открываем модально

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void rjButton1_Click(object sender, EventArgs e)
        {
            var type = comboBoxType.SelectedValue;
            var student = comboBoxStudent.SelectedValue;

            // Проверка выбора уровня
            if (!comboBoxType.Enabled || comboBoxType.SelectedItem == null && !comboBoxStudent.Enabled || comboBoxStudent.SelectedItem == null)
            {
                MessageBox.Show("Нет доступных типов занятий или учеников для выбора. Сначала добавьте учеников или типы занятий.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_isEditMode)
            {
                // Режим редактирования
                var (success, message) = await _lessonService.UpdateLesson(
                    _currentLesson!.Id,
                    DateOnly.FromDateTime(dateTimePickerDate.Value),
                    TimeOnly.FromDateTime(dateTimePickerTime.Value),
                    (int)numericPrice.Value,
                    (int)type,
                    textBox1.Text.Trim(),
                    Models.Enums.LessonStatus.Запланирован
                );

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Режим добавления
                var (success, message, lesson) = await _lessonService.CreateLesson(
                   DateOnly.FromDateTime(dateTimePickerDate.Value),
                    TimeOnly.FromDateTime(dateTimePickerTime.Value),
                    (int)numericPrice.Value,
                    (int)student,
                    (int)type,
                    textBox1.Text.Trim()
                );

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public async void SetLesson(LessonModel? lesson, List<SubjectModel> subjects,List<TypeModel> types, List<StudentModel> students)
        {
            _currentLesson = lesson;
            _subjects = subjects ?? new List<SubjectModel>();
            _types = types ?? new List<TypeModel>();
            _students = students ?? new List<StudentModel>();

            // Заполняем комбобокс уровнями
            SetupComboBoxes();

            if (_isEditMode)
            {

                dateTimePickerDate.Value = _currentLesson.Date.ToDateTime(TimeOnly.MinValue);
                dateTimePickerTime.Value = DateTime.Today.Add(_currentLesson.Time.ToTimeSpan());
                numericPrice.Value = _currentLesson.Price;
                //SelectTypeAndStudentInComboBox(_currentLesson.TypeId, _currentLesson.StudentId);
                if (lesson.Type != null)
                {
                    var subject = _subjects.FirstOrDefault(s => s.Id == lesson.Type.SubjectId);
                    if (subject != null)
                    {
                        comboBoxSubject.SelectedItem = subject;

                    }
                }
                comboBoxSubject.SelectedIndexChanged += async (s, e) =>
                {
                    await LoadTypesForSelectedSubject();
                    if (comboBoxType.Items.Count > 0 && lesson.Type != null)
                    {
                        var typeToSelect = comboBoxType.Items.Cast<TypeModel>()
                            .FirstOrDefault(t => t.Id == lesson.TypeId);
                        if (typeToSelect != null)
                            comboBoxType.SelectedItem = typeToSelect;
                        comboBoxType.Enabled = true;
                    }
                };
            }
            else
            {
                // Режим добавления - очищаем поля
                dateTimePickerDate.Value = DateTime.Now;
                numericPrice.Value = 100; // Значение по умолчанию
                dateTimePickerTime.Value = DateTime.Today.AddHours(10);

                // Выбираем первый уровень, если есть
                if (comboBoxType.Items.Count > 0 && comboBoxStudent.Items.Count > 0)
                {
                    comboBoxType.SelectedIndex = 0;
                    comboBoxStudent.SelectedIndex = 0;
                }
            }
        }

        private async void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubject.SelectedItem != null)
            {
                await LoadTypesForSelectedSubject();
                comboBoxType.Enabled = true;
            }
        }
        private async Task LoadTypesForSelectedSubject()
        {
            if (comboBoxSubject.SelectedItem == null)
                return;

            var selectedSubject = (SubjectModel)comboBoxSubject.SelectedItem;

            // Загружаем типы для выбранного предмета
            var types = await _dictionaryService.GetTypesBySubject(selectedSubject.Id);

            comboBoxType.DataSource = types;
            comboBoxType.DisplayMember = "TypeName";
            comboBoxType.ValueMember = "Id";
        }
    }
}
