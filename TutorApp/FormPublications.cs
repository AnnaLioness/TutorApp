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
    public partial class FormPublications : Form
    {
        private readonly PublicationService _publicationService;
        private readonly MaterialService _materialService;
        private readonly VkSettingsService _vkSettingsService;
        private List<PublicationModel> _publications;
        private List<MaterialModel> _materials;
        public FormPublications(PublicationService publicationService,
            MaterialService materialService,
            VkSettingsService vkSettingsService)
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

            _publicationService = publicationService;
            _materialService = materialService;
            _vkSettingsService = vkSettingsService;

            SetupDataGridView();
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
            DataGridViewPublications.AutoGenerateColumns = false;
            DataGridViewPublications.Columns.Clear();

            // ID (скрытая)
            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };
            DataGridViewPublications.Columns.Add(idColumn);

            // Дата публикации
            var dateColumn = new DataGridViewTextBoxColumn
            {
                Name = "PublicationDate",
                HeaderText = "Дата публикации",
                DataPropertyName = "PublicationDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" },
       
            };
            DataGridViewPublications.Columns.Add(dateColumn);

            // Материал
            var materialColumn = new DataGridViewTextBoxColumn
            {
                Name = "MaterialTitle",
                HeaderText = "Материал",
                DataPropertyName = "MaterialTitle",
             
            };
            DataGridViewPublications.Columns.Add(materialColumn);

            // Статус
            var statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Статус",
                DataPropertyName = "Status",
            
            };
            DataGridViewPublications.Columns.Add(statusColumn);

            DataGridViewPublications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewPublications.MultiSelect = false;
        }
        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ButtonRef.Enabled = false;
                ButtonPublishNow.Enabled = false;

                // Загружаем публикации и материалы параллельно
                var publicationsTask = _publicationService.GetAllPublications();
                var materialsTask = _materialService.GetAllMaterials();

                await Task.WhenAll(publicationsTask, materialsTask);

                _publications = publicationsTask.Result.ToList();
                _materials = materialsTask.Result.ToList();

                DisplayPublications();
                LoadMaterialsComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ButtonRef.Enabled = true;
                ButtonPublishNow.Enabled = true;
            }
        }
        private void DisplayPublications()
        {
            DataGridViewPublications.Rows.Clear();

            foreach (var pub in _publications.OrderByDescending(p => p.PublicationDate))
            {
                string materialTitle = pub.Material?.Title ?? $"[Материал {pub.MaterialId}]";
                string status = pub.IsPublicted ? "✅ Опубликовано" : "⏳ Запланировано";

                int rowIndex = DataGridViewPublications.Rows.Add(
                    pub.Id,
                    pub.PublicationDate,
                    materialTitle,
                    status
                );

                // Подсветка неопубликованных
                if (!pub.IsPublicted)
                {
                    DataGridViewPublications.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                DataGridViewPublications.Rows[rowIndex].Tag = pub;
            }

            DataGridViewPublications.ClearSelection();
        }

        private void LoadMaterialsComboBox()
        {
            cmbMaterial.Items.Clear();
            cmbMaterial.DisplayMember = "Title";
            cmbMaterial.ValueMember = "Id";

            foreach (var material in _materials.OrderBy(m => m.Title))
            {
                cmbMaterial.Items.Add(material);
            }

            if (cmbMaterial.Items.Count > 0)
                cmbMaterial.SelectedIndex = 0;
        }


        private async void ButtonPublishNow_Click(object sender, EventArgs e)
        {
            // 1. Проверка: выбран ли материал
            if (cmbMaterial.SelectedItem == null)
            {
                MessageBox.Show("Выберите материал для публикации.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMaterial = (MaterialModel)cmbMaterial.SelectedItem;

            // 2. Проверка: настроен ли доступ к VK
            var vkSettings = _vkSettingsService.Load();
            if (!vkSettings.IsConfigured)
            {
                MessageBox.Show("Сначала настройте доступ к ВКонтакте в меню Настройки → VK.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Проверка: существует ли файл материала на диске
            if (string.IsNullOrEmpty(selectedMaterial.FilePath) || !File.Exists(selectedMaterial.FilePath))
            {
                MessageBox.Show("Файл материала не найден по указанному пути.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Сбор путей к изображениям из текстового поля (каждый путь с новой строки или через запятую)
            List<string> imagePaths = new List<string>();
            if (!string.IsNullOrEmpty(textBoxPictures.Text))
            {
                var separators = new[] { ',', ';', ' ', '\n', '\r' };
                imagePaths = textBoxPictures.Text
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Where(path => File.Exists(path.Trim()))
                    .Select(path => path.Trim())
                    .ToList();

                if (imagePaths.Any())
                {
                    LogToFile($"Найдено {imagePaths.Count} изображений для публикации");
                }
                else if (!string.IsNullOrWhiteSpace(textBoxPictures.Text))
                {
                    var result = MessageBox.Show("Некоторые указанные файлы не найдены. Продолжить публикацию без них?",
                        "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                        return;
                }
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                ButtonPublishNow.Enabled = false;

                // Публикация
                var vkHelper = new VkPostHelper(vkSettings.AccessToken, vkSettings.GroupId);
                long postId = await vkHelper.PublishMaterialWithImagesAsync(selectedMaterial.FilePath, imagePaths);

                // Сохранение в БД
                var newPublication = new PublicationModel
                {
                    MaterialId = selectedMaterial.Id,
                    PublicationDate = DateTime.Now,
                    IsPublicted = true
                };

                await _publicationService.AddPublication(newPublication);

                // Обновляем таблицу
                await LoadDataAsync();

                string successMessage = $"✅ Пост успешно опубликован!\nID записи ВКонтакте: {postId}";
                if (imagePaths.Any())
                {
                    successMessage += $"\n📷 Загружено изображений: {imagePaths.Count}";
                }

                MessageBox.Show(successMessage, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поле с путями после успешной публикации
                textBoxPictures.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при публикации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ButtonPublishNow.Enabled = true;
            }
        }

        private async void ButtonRef_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private void LogToFile(string message)
        {
            try
            {
                string logPath = Path.Combine(Path.GetTempPath(), "TutorApp_VkLog.txt");
                File.AppendAllText(logPath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {message}{Environment.NewLine}");
            }
            catch { }
        }
    }
}
