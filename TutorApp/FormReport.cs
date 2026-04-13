using Models.DTOs;
using Models.Enums;
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
    public partial class FormReport : Form
    {
        private readonly ReportService _reportService;
        private ProfitReportModel _lastReport;
        private ReportPeriodType _currentPeriodType = ReportPeriodType.Month;
        public FormReport(ReportService reportService)
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

            _reportService = reportService;

            // Подписываемся на события кнопок
            ButtonWeek.Click += (s, e) => LoadReport(ReportPeriodType.Week);
            ButtonMonth.Click += (s, e) => LoadReport(ReportPeriodType.Month);
            ButtonYear.Click += (s, e) => LoadReport(ReportPeriodType.Year);
            //ButtonExportPDF.Click += ButtonExportPDF_Click;

            // Загружаем отчёт по умолчанию (месяц)
            this.Shown += async (s, e) => await LoadReport(ReportPeriodType.Month);
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
        private async Task LoadReport(ReportPeriodType periodType)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ButtonWeek.Enabled = false;
                ButtonMonth.Enabled = false;
                ButtonYear.Enabled = false;
                ButtonExportPDF.Enabled = false;

                _currentPeriodType = periodType;

                // Подсвечиваем активную кнопку
                ResetButtonColors();
                switch (periodType)
                {
                    case ReportPeriodType.Week:
                        ButtonWeek.BackColor = Color.LightGreen;
                        lblDateRange.Text = $"Неделя: {GetWeekRange():dd.MM.yyyy} - {GetWeekRangeEnd():dd.MM.yyyy}";
                        break;
                    case ReportPeriodType.Month:
                        ButtonMonth.BackColor = Color.LightGreen;
                        lblDateRange.Text = $"Месяц: {DateTime.Today:MMMM yyyy}";
                        break;
                    case ReportPeriodType.Year:
                        ButtonYear.BackColor = Color.LightGreen;
                        lblDateRange.Text = $"Год: {DateTime.Today:yyyy}";
                        break;
                }

                _lastReport = await _reportService.GetProfitReport(periodType, DateTime.Today);

                if (!_lastReport.HasPreviousPeriodData && _lastReport.CurrentPeriodProfit == 0)
                {
                    lblWarning.Text = "⚠️ Нет данных за выбранный период. Проведите уроки для формирования отчёта.";
                    lblWarning.Visible = true;
                    ClearDisplay();
                    return;
                }
                else if (!_lastReport.HasPreviousPeriodData && _lastReport.CurrentPeriodProfit > 0)
                {
                    lblWarning.Text = "ℹ️ Нет данных за предыдущий период для сравнения. Показана только статистика за текущий период.";
                    lblWarning.Visible = true;
                }
                else
                {
                    lblWarning.Visible = false;
                }

                DisplayReport(_lastReport);
                ButtonExportPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчёта: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ButtonWeek.Enabled = true;
                ButtonMonth.Enabled = true;
                ButtonYear.Enabled = true;
            }
        }
        private DateTime GetWeekRange()
        {
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            if (today.DayOfWeek == DayOfWeek.Sunday)
                startOfWeek = today.AddDays(-6);
            return startOfWeek;
        }

        private DateTime GetWeekRangeEnd()
        {
            return GetWeekRange().AddDays(6);
        }

        private void ResetButtonColors()
        {
            ButtonWeek.BackColor = Color.White;
            ButtonMonth.BackColor = Color.White;
            ButtonYear.BackColor = Color.White;
        }

        private void DisplayReport(ProfitReportModel report)
        {
            // Заголовок окна
            string periodText = _currentPeriodType switch
            {
                ReportPeriodType.Week => "Неделя",
                ReportPeriodType.Month => "Месяц",
                ReportPeriodType.Year => "Год",
                _ => "Период"
            };
            string dateRange = $"{report.PeriodStart:dd.MM.yyyy} - {report.PeriodEnd:dd.MM.yyyy}";
            Text = $"Отчёт - {periodText} ({dateRange})";

            // Прибыль
            lblProfitCurrent.Text = $"💰 Прибыль за период: {report.CurrentPeriodProfit:N0} ₽";

            if (report.HasPreviousPeriodData)
            {
                string changeSymbol = report.ProfitChangePercent >= 0 ? "▲" : "▼";
                lblProfitChange.Text = $"📊 Изменение: {changeSymbol} {Math.Abs(report.ProfitChangePercent):F1}% " +
                                       $"({(report.ProfitChangeAbsolute >= 0 ? "+" : "")}{report.ProfitChangeAbsolute:N0} ₽) " +
                                       $"по сравнению с предыдущим периодом";
                lblProfitChange.ForeColor = report.ProfitChangePercent >= 0 ? Color.Green : Color.Red;
            }
            else
            {
                lblProfitChange.Text = "📊 Нет данных для сравнения с предыдущим периодом";
                lblProfitChange.ForeColor = Color.White;
            }

            // Количество уроков
            lblLessonsCount.Text = $"📚 Проведено уроков: {report.CurrentPeriodLessonsCount} " +
                                   $"{(report.HasPreviousPeriodData ? $"(изменение: {(report.LessonsChangePercent >= 0 ? "+" : "")}{report.LessonsChangePercent}%)" : "")}";

            // Активные ученики
            lblStudentsStats.Text = $"👥 Активные ученики: {report.ActiveStudents} из {report.TotalStudents} ({report.ActiveStudentsPercent}%)";

            // Средний чек
            lblAverageCheck.Text = $"💳 Средний чек: {report.AverageLessonPrice:N0} ₽";

            // Топ-типы уроков
            listTopTypes.Items.Clear();
            if (report.TopLessonTypes.Any())
            {
                foreach (var type in report.TopLessonTypes)
                {
                    listTopTypes.Items.Add($"{type.TypeName}");
                    listTopTypes.Items.Add($"   💰 {type.TotalAmount:N0} ₽ ({type.PercentageOfTotal}% от прибыли)");
                    listTopTypes.Items.Add($"   📚 {type.LessonsCount} уроков");
                    listTopTypes.Items.Add(""); // разделитель
                }
            }
            else
            {
                listTopTypes.Items.Add("Нет данных за период");
            }

            // Динамика (таблица)
            if (report.ProfitDynamics.Any())
            {
                var chartData = report.ProfitDynamics.Select(d => new
                {
                    Период = d.Label,
                    Прибыль = d.Profit,
                    Уроков = d.LessonsCount
                }).ToList();

                dgvChart.DataSource = null;
                dgvChart.DataSource = chartData;

                if (dgvChart.Columns.Count >= 2)
                {
                    dgvChart.Columns["Прибыль"].DefaultCellStyle.Format = "N0";
                    dgvChart.Columns["Прибыль"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvChart.Columns["Уроков"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else
            {
                dgvChart.DataSource = null;
            }
        }
        private void ClearDisplay()
        {
            lblProfitCurrent.Text = "💰 Прибыль за период: —";
            lblProfitChange.Text = "📊 Изменение: —";
            lblLessonsCount.Text = "📚 Проведено уроков: —";
            lblStudentsStats.Text = "👥 Активные ученики: —";
            lblAverageCheck.Text = "💳 Средний чек: —";
            listTopTypes.Items.Clear();
            dgvChart.DataSource = null;
        }


        private async void ButtonExportPDF_Click(object sender, EventArgs e)
        {
            if (_lastReport == null)
            {
                MessageBox.Show("Сначала сформируйте отчёт, нажав на кнопку периода (Неделя/Месяц/Год)",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Сохранить отчёт";
                    saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf";

                    // Формируем имя файла
                    string periodName = _currentPeriodType switch
                    {
                        ReportPeriodType.Week => "Неделя",
                        ReportPeriodType.Month => "Месяц",
                        ReportPeriodType.Year => "Год",
                        _ => "Отчёт"
                    };
                    saveDialog.FileName = $"Отчёт_по_прибыли_{periodName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        ButtonExportPDF.Enabled = false;

                        string periodTypeEn = _currentPeriodType.ToString();

                        await Task.Run(() =>
                            PdfReportHelper.CreateProfitReport(_lastReport, periodTypeEn, saveDialog.FileName));

                        var result = MessageBox.Show($"Отчёт сохранён:\n{saveDialog.FileName}\n\nОткрыть файл?",
                            "Экспорт завершён", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            PdfReportHelper.OpenPdf(saveDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте PDF: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ButtonExportPDF.Enabled = true;
            }
        }
    }
}
