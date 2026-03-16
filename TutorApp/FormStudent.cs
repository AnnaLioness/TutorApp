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
    public partial class FormStudent : Form
    {
        private readonly StudentService _studentService;
        private readonly DictionaryService _dictionaryService;
        private StudentModel? _currentStudent;
        private List<LevelModel> _levels;
        private bool _isEditMode => _currentStudent != null;
        public FormStudent(StudentService studentService, DictionaryService dictionaryService)
        {
            InitializeComponent();
            _studentService = studentService;
            _dictionaryService = dictionaryService;
            _levels = new List<LevelModel>();

            // Настраиваем комбобокс
            SetupComboBox();
        }

        public async Task SetupComboBox()
        {
            var levels = await _dictionaryService.GetAllLevels();
            comboBox1.DataSource = levels;
            comboBox1.DisplayMember = "LevelName";
            comboBox1.ValueMember = "Id";
        }

        /// <summary>
        /// Заполнение комбобокса уровнями
        /// </summary>

        private void SelectLevelInComboBox(int levelId)
        {
            if (comboBox1.Enabled && _levels.Any())
            {
                var level = _levels.FirstOrDefault(l => l.Id == levelId);
                if (level != null)
                {
                    comboBox1.SelectedItem = level;
                }
                else if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Валидация полей формы
        /// </summary>
        private bool ValidateForm()
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите ФИО ученика", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return false;
            }

            // Проверка возраста
            if (numericUpDownAge.Value < 3 || numericUpDownAge.Value > 100)
            {
                MessageBox.Show("Возраст должен быть от 3 до 100 лет", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownAge.Focus();
                return false;
            }

            // Проверка выбора уровня
            if (!comboBox1.Enabled || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Нет доступных уровней для выбора. Сначала добавьте уровни в справочник.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик кнопки сохранения
        /// </summary>

        private void ButtonAddLevel_Click(object sender, EventArgs e)
        {
            try
            {
                var levelsForm = Program.ServiceProvider.GetRequiredService<FormLevels>();
                levelsForm.ShowDialog(); // Открываем модально

                // После закрытия формы уровней обновляем список учеников,
                // чтобы подгрузить актуальные названия уровней
                SetupComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы уровней: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void rjButton1_Click(object sender, EventArgs e)
        {
            var level = comboBox1.SelectedValue;

            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите ФИО ученика", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (textBoxPhone.Text.Length != 6 || textBoxPhone.Text.Length != 11)
            {
                MessageBox.Show("Неверный формат номера", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Проверка возраста
            if (numericUpDownAge.Value < 3 || numericUpDownAge.Value > 100)
            {
                MessageBox.Show("Возраст должен быть от 3 до 100 лет", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Проверка выбора уровня
            if (!comboBox1.Enabled || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Нет доступных уровней для выбора. Сначала добавьте уровни в справочник.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // await _studentService.CreateStudent(textBoxName.Text, (int)numericUpDownAge.Value,textBoxPhone.Text, (int)level);
            if (_isEditMode)
            {
                // Режим редактирования
                var (success, message) = await _studentService.UpdateStudent(
                    _currentStudent!.Id,
                    textBoxName.Text.Trim(),
                    (int)numericUpDownAge.Value,
                    textBoxPhone.Text.Trim(),
                    (int)level
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
                var (success, message, student) = await _studentService.CreateStudent(
                    textBoxName.Text.Trim(),
                    (int)numericUpDownAge.Value,
                    textBoxPhone.Text.Trim(),
                    (int)level
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
        public async void SetStudent(StudentModel? student, List<LevelModel> levels)
        {
            _currentStudent = student;
            _levels = levels ?? new List<LevelModel>();

            // Заполняем комбобокс уровнями
            SetupComboBox();

            if (_isEditMode)
            {
                // Режим редактирования - заполняем поля
                textBoxName.Text = _currentStudent.FullName;
                numericUpDownAge.Value = _currentStudent.Age;
                textBoxPhone.Text = _currentStudent.Phone;

                // Выбираем уровень студента в комбобоксе
                SelectLevelInComboBox(_currentStudent.LevelId);
            }
            else
            {
                // Режим добавления - очищаем поля
                textBoxName.Clear();
                numericUpDownAge.Value = 10; // Значение по умолчанию
                textBoxPhone.Clear();

                // Выбираем первый уровень, если есть
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
        }
    }
}
