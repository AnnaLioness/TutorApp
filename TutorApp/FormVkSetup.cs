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
    public partial class FormVkSetup : Form
    {
        private readonly VkSettingsService _settingsService;
        private VkSettings _settings;
        public FormVkSetup(VkSettingsService settingsService)
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

            _settingsService = settingsService;
            _settings = _settingsService.Load();
            LoadSettings();
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

        private void LoadSettings()
        {
            if (_settings.IsConfigured)
            {
                txtGroupId.Text = _settings.GroupId.ToString();
                txtAccessToken.Text = _settings.AccessToken;
                lblStatus.Text = "✓ Настройки загружены. Можете проверить или изменить.";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "ℹ️ Введите ID группы и токен для настройки публикаций.";
                lblStatus.ForeColor = Color.Gray;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtGroupId.Text))
            {
                lblStatus.Text = "❌ Введите ID группы";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            if (!long.TryParse(txtGroupId.Text, out long groupId) || groupId >= 0)
            {
                lblStatus.Text = "❌ ID группы должен быть отрицательным числом (например, -123456789)";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAccessToken.Text) || txtAccessToken.Text.Length < 10)
            {
                lblStatus.Text = "❌ Введите корректный сервисный токен";
                lblStatus.ForeColor = Color.Red;
                return false;
            }

            return true;
        }
        private async void ButtonTest_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            ButtonTest.Enabled = false;
            ButtonSave.Enabled = false;
            lblStatus.Text = "⏳ Проверка подключения...";
            lblStatus.ForeColor = Color.Gray;

            try
            {
                long groupId = long.Parse(txtGroupId.Text);
                string token = txtAccessToken.Text;

                var vkHelper = new VkPostHelper(token, groupId);
                bool isConnected = await vkHelper.TestConnectionAsync();

                if (isConnected)
                {
                    lblStatus.Text = "✅ Подключение успешно! Токен работает, группа доступна.";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "❌ Ошибка подключения. Проверьте ID группы и токен.";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"❌ Ошибка: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                ButtonTest.Enabled = true;
                ButtonSave.Enabled = true;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            _settings.GroupId = long.Parse(txtGroupId.Text);
            _settings.AccessToken = txtAccessToken.Text;
            _settings.IsConfigured = true;

            _settingsService.Save(_settings);

            lblStatus.Text = "✅ Настройки сохранены!";
            lblStatus.ForeColor = Color.Green;

            // Небольшая задержка перед закрытием
            Task.Delay(500).ContinueWith(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }));
            });
        }

        private void ButtonInstruction_Click(object sender, EventArgs e)
        {
            // Ссылка на инструкцию (можно заменить на свою)
            string instructionUrl = "https://disk.yandex.ru/i/cY-xnQ0IGpK4WA";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = instructionUrl,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("Не удалось открыть браузер. Скопируйте ссылку вручную:\n" + instructionUrl,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
