using CustomControls.RJControls;
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
using TutorApp.helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TutorApp
{
    public partial class FormMaterial : Form
    {
        private readonly MaterialService _materialService;
        private readonly DictionaryService _dictionaryService;

        private MaterialModel _currentMaterial;
        private List<SubjectModel> _subjects;
        private List<TypeModel> _allTypes;
        private List<LevelModel> _levels;

        private string _selectedFilePath = null;
        public FormMaterial(MaterialService materialService, DictionaryService dictionaryService)
        {
            InitializeComponent();
            _materialService = materialService;
            _dictionaryService = dictionaryService;
            SetupComboboxes();
        }
        private async void SetupComboboxes()
        {
            var subjects = await _dictionaryService.GetAllSubjects();
            comboBoxSubject.DataSource = subjects;
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "Id";

            var levels = await _dictionaryService.GetAllLevels();
            comboBoxLevel.DataSource = levels;
            comboBoxLevel.DisplayMember = "LevelName";
            comboBoxLevel.ValueMember = "Id";

            var ageGroups = EnumHelper.GetEnumItems<AgeGroup>();
            comboBoxAgeGrop.DisplayMember = "Description";
            comboBoxAgeGrop.ValueMember = "Value";
            comboBoxAgeGrop.DataSource = ageGroups;

            var seasons = EnumHelper.GetEnumItems<Season>();
            comboBoxSeason.DisplayMember = "Description";
            comboBoxSeason.ValueMember = "Value";
            comboBoxSeason.DataSource = seasons;

            // Заполняем праздники
            var holidays = EnumHelper.GetEnumItems<Holiday>();
            comboBoxHoliday.DisplayMember = "Description";
            comboBoxHoliday.ValueMember = "Value";
            comboBoxHoliday.DataSource = holidays;

            // По умолчанию ComboBox праздников неактивен
            comboBoxType.Enabled = false;
            comboBoxHoliday.Enabled = false;
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл материала";
                openFileDialog.Filter = "Все файлы (*.*)|*.*|PDF файлы (*.pdf)|*.pdf|Word файлы (*.docx)|*.docx|Текстовые файлы (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath = openFileDialog.FileName;

                    // Показываем имя выбранного файла
                    MessageBox.Show($"Файл выбран: {Path.GetFileName(_selectedFilePath)}",
                        "Файл загружен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Введите название материала", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxLevel.SelectedItem == null)
            {
                MessageBox.Show("Выберите уровень", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxSubject.SelectedItem == null)
            {
                MessageBox.Show("Выберите предмет", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxType.SelectedItem == null || comboBoxType.Enabled == false)
            {
                MessageBox.Show("Выберите направление", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_selectedFilePath))
            {
                MessageBox.Show("Файл не выбран", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // Заполняем модель
                _currentMaterial.Title = textBoxTitle.Text.Trim();
                _currentMaterial.Description = textBoxDescription.Text?.Trim() ?? "";
                _currentMaterial.TypeId = (int)comboBoxType.SelectedValue;
                _currentMaterial.FilePath = _selectedFilePath ?? "";

                // Получаем выбранную возрастную группу
                var selectedAgeGroup = (EnumItem<AgeGroup>)comboBoxAgeGrop.SelectedItem;
                _currentMaterial.AgeGroup = selectedAgeGroup.Value;

                // Получаем выбранный сезон
                var selectedSeason = (EnumItem<Season>)comboBoxSeason.SelectedItem;
                _currentMaterial.Season = selectedSeason.Value;

                // Праздничные поля
                _currentMaterial.IsHoliday = checkBox1.Checked;
                if (checkBox1.Checked && comboBoxHoliday.SelectedItem != null)
                {
                    var selectedHoliday = (EnumItem<Holiday>)comboBoxHoliday.SelectedItem;
                    _currentMaterial.Holiday = selectedHoliday.Value;
                }
                else
                {
                    _currentMaterial.Holiday = null;
                }

                bool success;
                string message;

                if (_currentMaterial.Id == 0)
                {
                    // Добавление
                    (success, message,_) = await _materialService.CreateMaterial(textBoxTitle.Text, textBoxDescription.Text, _selectedFilePath, (int)comboBoxType.SelectedValue,
                        (int)comboBoxLevel.SelectedValue, selectedAgeGroup.Value, selectedSeason.Value, checkBox1.Checked,checkBox1.Checked && comboBoxHoliday.SelectedItem != null
            ? ((EnumItem<Holiday>)comboBoxHoliday.SelectedItem).Value
            : (Holiday?)null);
                }
                else
                {
                    // Редактирование
                    (success, message) = await _materialService.UpdateMaterial(_currentMaterial.Id, textBoxTitle.Text, textBoxDescription.Text, _selectedFilePath, (int)comboBoxType.SelectedValue,
                        (int)comboBoxLevel.SelectedValue, selectedAgeGroup.Value, selectedSeason.Value, checkBox1.Checked, checkBox1.Checked && comboBoxHoliday.SelectedItem != null
            ? ((EnumItem<Holiday>)comboBoxHoliday.SelectedItem).Value
            : (Holiday?)null);
                }

                if (success)
                {
                    MessageBox.Show("Материал успешно сохранен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ButtonAddLevel_Click(object sender, EventArgs e)
        {
            try
            {
                var levelsForm = Program.ServiceProvider.GetRequiredService<FormLevels>();
                levelsForm.ShowDialog(); // Открываем модально

                // После закрытия формы уровней обновляем список учеников,
                // чтобы подгрузить актуальные названия уровней
                SetupComboboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы уровней: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxHoliday.Enabled = checkBox1.Checked;
        }
        public void SetMaterial(MaterialModel material, List<SubjectModel> subjects, List<TypeModel> types, List<LevelModel> levels)
        {
            _subjects = subjects;
            _allTypes = types;
            _levels = levels;
            _currentMaterial = material;

            // Обновляем ComboBox предметов
            comboBoxSubject.DataSource = null;
            comboBoxSubject.DataSource = _subjects;
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "Id";

            if (material != null)
            {
                // Режим редактирования
                textBoxTitle.Text = material.Title;
                textBoxDescription.Text = material.Description;
                _selectedFilePath = material.FilePath;

                // Выбираем предмет и загружаем типы
                if (material.Type != null)
                {
                    var subject = _subjects.FirstOrDefault(s => s.Id == material.Type.SubjectId);
                    if (subject != null)
                    {
                        comboBoxSubject.SelectedItem = subject;
                        
                    }
                }

                // После выбора предмета нужно дождаться загрузки типов и выбрать нужный
                // Делаем через небольшую задержку или после загрузки
                comboBoxSubject.SelectedIndexChanged += async (s, e) =>
                {
                    await LoadTypesForSelectedSubject();
                    if (comboBoxType.Items.Count > 0 && material.Type != null)
                    {
                        var typeToSelect = comboBoxType.Items.Cast<TypeModel>()
                            .FirstOrDefault(t => t.Id == material.TypeId);
                        if (typeToSelect != null)
                            comboBoxType.SelectedItem = typeToSelect;
                        comboBoxType.Enabled = true;
                    }
                };

                // Выбираем возрастную группу
                var ageGroupItem = ((List<EnumItem<AgeGroup>>)comboBoxAgeGrop.DataSource)
                    .FirstOrDefault(ag => ag.Value == material.AgeGroup);
                if (ageGroupItem != null)
                    comboBoxAgeGrop.SelectedItem = ageGroupItem;

                

                // Выбираем сезон
                var seasonItem = ((List<EnumItem<Season>>)comboBoxSeason.DataSource)
                    .FirstOrDefault(s => s.Value == material.Season);
                if (seasonItem != null)
                    comboBoxSeason.SelectedItem = seasonItem;

                var levelt = _levels.FirstOrDefault(s => s.Id == material.LevelId);
                if (levelt != null)
                {
                    comboBoxLevel.SelectedItem = levelt;

                }

                // Праздничный материал
                checkBox1.Checked = material.IsHoliday;
                if (material.Holiday.HasValue)
                {
                    var holidayItem = ((List<EnumItem<Holiday>>)comboBoxHoliday.DataSource)
                        .FirstOrDefault(h => h.Value == material.Holiday.Value);
                    if (holidayItem != null)
                        comboBoxHoliday.SelectedItem = holidayItem;
                }
            }
            else
            {
                // Режим добавления
                _currentMaterial = new MaterialModel();
                comboBoxAgeGrop.SelectedIndex = 0;
                comboBoxSeason.SelectedIndex = 0;
                checkBox1.Checked = false;
            }
        }
    }
}
