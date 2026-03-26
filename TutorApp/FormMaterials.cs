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

namespace TutorApp
{
    public partial class FormMaterials : Form
    {
        private readonly MaterialService _materialService;
        private readonly DictionaryService _dictionaryService;
        private List<MaterialModel> _materials = new();
        private List<TypeModel> _types = new();
        private List<LevelModel> _levels = new();
        private List<SubjectModel> _subjects = new();
        public FormMaterials(MaterialService materialService, DictionaryService dictionaryService)
        {
            InitializeComponent();
            _materialService = materialService;
            _dictionaryService = dictionaryService;
            SetupDataGridView();
            LoadDataAsync();
        }

        private void SetupDataGridView()
        {
            // Отключаем автоматическую генерацию колонок
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            // ID (скрытая)
            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };
            dataGridView.Columns.Add(idColumn);

            // Название материала
            var titleColumn = new DataGridViewTextBoxColumn
            {
                Name = "Title",
                DataPropertyName = "Title",
                HeaderText = "Название"
            };
            dataGridView.Columns.Add(titleColumn);

            var descriptionColumn = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                DataPropertyName = "Description",
                HeaderText = "Описание"
            };
            dataGridView.Columns.Add(descriptionColumn);

            var subjColumn = new DataGridViewTextBoxColumn
            {
                Name = "SubjName",
                HeaderText = "Предмет"
            };
            dataGridView.Columns.Add(subjColumn);

            // Тип материала
            var typeColumn = new DataGridViewTextBoxColumn
            {
                Name = "TypeName",
                HeaderText = "Направление"
            };
            dataGridView.Columns.Add(typeColumn);

            // Уровень
            var levelColumn = new DataGridViewTextBoxColumn
            {
                Name = "LevelName",
                HeaderText = "Уровень сложности",

            };
            dataGridView.Columns.Add(levelColumn);

            // Возрастная группа
            var ageGroupColumn = new DataGridViewTextBoxColumn
            {
                Name = "AgeGroup",
                HeaderText = "Возраст",

            };
            dataGridView.Columns.Add(ageGroupColumn);

            // Сезон
            var seasonColumn = new DataGridViewTextBoxColumn
            {
                Name = "Season",
                HeaderText = "Сезон",
                Width = 80
            };
            dataGridView.Columns.Add(seasonColumn);

            // Праздничный флаг
            var holidayColumn = new DataGridViewTextBoxColumn
            {
                Name = "HolidayInfo",
                HeaderText = "Праздник",

            };
            dataGridView.Columns.Add(holidayColumn);

            // Кнопка удаления
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "",
                Text = "🗑️ Удалить",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };
            dataGridView.Columns.Add(deleteButtonColumn);

            dataGridView.CellClick += dataGridView_CellClick;
        }
        private async void LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var materialsTask = _materialService.GetAllMaterials();
                var typesTask = _dictionaryService.GetAllTypes();
                var levelsTask = _dictionaryService.GetAllLevels();
                var subjectsTask = _dictionaryService.GetAllSubjects();  // ← добавить

                await Task.WhenAll(materialsTask, typesTask, levelsTask, subjectsTask);

                _materials = materialsTask.Result.ToList();
                _types = typesTask.Result.ToList();
                _levels = levelsTask.Result.ToList();
                _subjects = subjectsTask.Result.ToList();  // ← добавить

                DisplayMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisplayMaterials();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void DisplayMaterials()
        {
            try
            {
                dataGridView.Rows.Clear();

                foreach (var material in _materials.OrderBy(m => m.Title))
                {
                    // Получаем тип материала
                    var type = _types.FirstOrDefault(t => t.Id == material.TypeId);
                    string typeName = type?.TypeName ?? $"[Тип {material.TypeId}]";

                    // Получаем предмет (через тип)
                    string subjectName = "Не указан";
                    if (type != null)
                    {
                        var subject = _subjects.FirstOrDefault(s => s.Id == type.SubjectId);
                        subjectName = subject?.SubjectName ?? $"[Предмет {type.SubjectId}]";
                    }

                    string levelName = GetLevelName(material.LevelId);
                    string ageGroupText = GetAgeGroupText(material.AgeGroup);
                    string seasonText = GetSeasonText(material.Season);
                    string holidayInfo = GetHolidayInfo(material);

                    int rowIndex = dataGridView.Rows.Add(
                        material.Id,
                        material.Title,
                        material.Description ?? "",      // Описание
                        subjectName,                      // Предмет
                        typeName,                         // Направление
                        levelName,                        // Уровень сложности
                        ageGroupText,                     // Возраст
                        seasonText,                       // Сезон
                        holidayInfo,                      // Праздник
                        "🗑️ Удалить"                     // Кнопка
                    );

                    dataGridView.Rows[rowIndex].Tag = material;
                }

                dataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetTypeName(int typeId)
        {
            var type = _types.FirstOrDefault(t => t.Id == typeId);
            return type?.TypeName ?? $"[Тип {typeId}]";
        }

        private string GetLevelName(int levelId)
        {
            var level = _levels.FirstOrDefault(l => l.Id == levelId);
            return level?.LevelName ?? $"[Уровень {levelId}]";
        }

        private string GetAgeGroupText(AgeGroup ageGroup)
        {
            return EnumHelper.GetDescription(ageGroup);
        }

        private string GetSeasonText(Season season)
        {
            return EnumHelper.GetDescription(season);
        }

        private string GetHolidayInfo(MaterialModel material)
        {
            if (!material.IsHoliday || !material.Holiday.HasValue)
                return "—";

            return material.Holiday.Value switch
            {
                Holiday.NewYear => "🎄 Новый год",
                Holiday.Christmas => "🎄 Рождество",
                Holiday.Halloween => "🎃 Хеллоуин",
                Holiday.ValentinesDay => "💝 День св. Валентина",
                _ => material.Holiday.Value.ToString()
            };
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var materialForm = Program.ServiceProvider.GetRequiredService<FormMaterial>();
                materialForm.SetMaterial(null,_subjects, _types, _levels);

                if (materialForm.ShowDialog() == DialogResult.OK)
                {
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
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите материал для редактирования",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int id = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
                var material = await _materialService.GetMaterialById(id);

                if (material == null)
                {
                    MessageBox.Show("Не удалось найти данные материала",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var materialForm = Program.ServiceProvider.GetRequiredService<FormMaterial>();
                materialForm.SetMaterial(material,_subjects, _types, _levels);

                if (materialForm.ShowDialog() == DialogResult.OK)
                {
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

            var material = dataGridView.Rows[e.RowIndex].Tag as MaterialModel;
            if (material != null)
            {
                _isDeleting = true;
                await DeleteMaterial(material);
                _ = Task.Delay(500).ContinueWith(_ =>
                {
                    _isDeleting = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        private async Task DeleteMaterial(MaterialModel material)
        {
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить материал \"{material.Title}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                var (success, message) = await _materialService.DeleteMaterial(material.Id);

                if (success)
                {
                    _materials.Remove(material);
                    DisplayMaterials();

                    MessageBox.Show("Материал успешно удален", "Успех",
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
