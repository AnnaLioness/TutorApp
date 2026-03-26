using Models.DTOs;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TutorApp.helpers
{
    public static class PdfReportHelper
    {
        /// <summary>
        /// Создать PDF отчёт по прибыли
        /// </summary>
        public static void CreateProfitReport(ProfitReportModel report, string periodType, string outputPath)
        {
            using (var document = new PdfDocument())
            {
                var page = document.AddPage();
                page.Width = XUnit.FromMillimeter(210);
                page.Height = XUnit.FromMillimeter(297);

                using (var gfx = XGraphics.FromPdfPage(page))
                {
                    var titleFont = new XFont("Arial", 18, XFontStyleEx.Bold);
                    var headerFont = new XFont("Arial", 14, XFontStyleEx.Bold);
                    var normalFont = new XFont("Arial", 11, XFontStyleEx.Regular);
                    var smallFont = new XFont("Arial", 9, XFontStyleEx.Regular);

                    double y = 30;

                    // Заголовок
                    gfx.DrawString("ОТЧЁТ ПО ПРИБЫЛИ", titleFont, XBrushes.Black,
                        new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);
                    y += 35;

                    // Период
                    string periodText = periodType switch
                    {
                        "Week" => $"Неделя: {report.PeriodStart:dd.MM.yyyy} - {report.PeriodEnd:dd.MM.yyyy}",
                        "Month" => $"Месяц: {report.PeriodStart:MMMM yyyy}",
                        "Year" => $"Год: {report.PeriodStart:yyyy}",
                        _ => $"Период: {report.PeriodStart:dd.MM.yyyy} - {report.PeriodEnd:dd.MM.yyyy}"
                    };
                    gfx.DrawString(periodText, headerFont, XBrushes.DarkBlue,
                        new XRect(0, y, page.Width, 25), XStringFormats.TopCenter);
                    y += 35;

                    // Дата формирования
                    gfx.DrawString($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}", smallFont, XBrushes.Gray,
                        new XRect(20, y, page.Width - 40, 20), XStringFormats.TopLeft);
                    y += 20;

                    // Линия
                    gfx.DrawLine(XPens.Black, 20, y, page.Width - 20, y);
                    y += 15;

                    // Прибыль
                    y = DrawProfitSection(gfx, report, headerFont, normalFont, page.Width, y);

                    // Уроки
                    y = DrawLessonsSection(gfx, report, headerFont, normalFont, page.Width, y);

                    // Ученики
                    y = DrawStudentsSection(gfx, report, headerFont, normalFont, page.Width, y);

                    // Средний чек
                    y = DrawAverageCheckSection(gfx, report, headerFont, normalFont, page.Width, y);

                    // Топ-типы уроков
                    y = DrawTopLessonTypesSection(gfx, report, headerFont, normalFont, page.Width, y);

                    // График динамики
                    if (report.ProfitDynamics.Any())
                    {
                        y = DrawProfitChart(gfx, report, headerFont, normalFont, smallFont, page.Width, y);
                    }

                    // Нижний колонтитул
                    DrawFooter(gfx, smallFont, page.Height);
                }

                document.Save(outputPath);
            }
        }

        private static double DrawProfitSection(XGraphics gfx, ProfitReportModel report,
            XFont headerFont, XFont normalFont, double pageWidth, double startY)
        {
            double y = startY;

            gfx.DrawString("ПРИБЫЛЬ", headerFont, XBrushes.DarkGreen,
                new XRect(20, y, pageWidth - 40, 25), XStringFormats.TopLeft);
            y += 25;

            gfx.DrawString($"Прибыль за период: {report.CurrentPeriodProfit:N0} ₽", normalFont, XBrushes.Black,
                new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
            y += 20;

            if (report.HasPreviousPeriodData)
            {
                string changeSymbol = report.ProfitChangePercent >= 0 ? "▲" : "▼";
                gfx.DrawString($"Изменение: {changeSymbol} {Math.Abs(report.ProfitChangePercent):F1}% ({Math.Abs(report.ProfitChangeAbsolute):N0} ₽)",
                    normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                y += 20;

                gfx.DrawString($"Прибыль за предыдущий период: {report.PreviousPeriodProfit:N0} ₽",
                    normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                y += 20;
            }
            else
            {
                gfx.DrawString("Нет данных для сравнения с предыдущим периодом", normalFont, XBrushes.Gray,
                    new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                y += 20;
            }

            y += 10;
            return y;
        }

        private static double DrawLessonsSection(XGraphics gfx, ProfitReportModel report,
            XFont headerFont, XFont normalFont, double pageWidth, double startY)
        {
            double y = startY;

            gfx.DrawString("УРОКИ", headerFont, XBrushes.DarkGreen,
                new XRect(20, y, pageWidth - 40, 25), XStringFormats.TopLeft);
            y += 25;

            gfx.DrawString($"Проведено уроков: {report.CurrentPeriodLessonsCount}", normalFont, XBrushes.Black,
                new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
            y += 20;

            if (report.HasPreviousPeriodData)
            {
                string lessonChangeSymbol = report.LessonsChangePercent >= 0 ? "▲" : "▼";
                gfx.DrawString($"Изменение: {lessonChangeSymbol} {Math.Abs(report.LessonsChangePercent)}%",
                    normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                y += 20;

                gfx.DrawString($"Уроков в предыдущем периоде: {report.PreviousPeriodLessonsCount}",
                    normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                y += 20;
            }

            y += 10;
            return y;
        }

        private static double DrawStudentsSection(XGraphics gfx, ProfitReportModel report,
            XFont headerFont, XFont normalFont, double pageWidth, double startY)
        {
            double y = startY;

            gfx.DrawString("УЧЕНИКИ", headerFont, XBrushes.DarkGreen,
                new XRect(20, y, pageWidth - 40, 25), XStringFormats.TopLeft);
            y += 25;

            gfx.DrawString($"Всего учеников: {report.TotalStudents}", normalFont, XBrushes.Black,
                new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
            y += 20;

            gfx.DrawString($"Активных учеников: {report.ActiveStudents} ({report.ActiveStudentsPercent}%)",
                normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
            y += 30;

            return y;
        }

        private static double DrawAverageCheckSection(XGraphics gfx, ProfitReportModel report,
            XFont headerFont, XFont normalFont, double pageWidth, double startY)
        {
            double y = startY;

            gfx.DrawString("СРЕДНИЙ ЧЕК", headerFont, XBrushes.DarkGreen,
                new XRect(20, y, pageWidth - 40, 25), XStringFormats.TopLeft);
            y += 25;

            gfx.DrawString($"{report.AverageLessonPrice:N0} ₽", normalFont, XBrushes.Black,
                new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
            y += 30;

            return y;
        }

        private static double DrawTopLessonTypesSection(XGraphics gfx, ProfitReportModel report,
            XFont headerFont, XFont normalFont, double pageWidth, double startY)
        {
            double y = startY;

            gfx.DrawString("ПОПУЛЯРНЫЕ НАПРАВЛЕНИЯ", headerFont, XBrushes.DarkGreen,
                new XRect(20, y, pageWidth - 40, 25), XStringFormats.TopLeft);
            y += 25;

            if (!report.TopLessonTypes.Any())
            {
                gfx.DrawString("Нет данных", normalFont, XBrushes.Gray,
                    new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                y += 25;
            }
            else
            {
                foreach (var type in report.TopLessonTypes)
                {
                    gfx.DrawString($"{type.TypeName}", normalFont, XBrushes.DarkBlue,
                        new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                    y += 18;

                    gfx.DrawString($"   Сумма: {type.TotalAmount:N0} ₽ ({type.PercentageOfTotal}% от общей прибыли)",
                        normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                    y += 18;

                    gfx.DrawString($"   Количество уроков: {type.LessonsCount}",
                        normalFont, XBrushes.Black, new XRect(40, y, pageWidth - 60, 20), XStringFormats.TopLeft);
                    y += 22;
                }
            }

            y += 10;
            return y;
        }

        private static double DrawProfitChart(XGraphics gfx, ProfitReportModel report,
            XFont headerFont, XFont normalFont, XFont smallFont, double pageWidth, double startY)
        {
            if (!report.ProfitDynamics.Any())
                return startY;

            const double chartWidth = 450;
            const double chartHeight = 150;
            const double marginLeft = 50;
            double y = startY + 15;

            gfx.DrawString("ДИНАМИКА ПРИБЫЛИ", headerFont, XBrushes.DarkGreen,
                new XRect(marginLeft, y, chartWidth, 25), XStringFormats.TopLeft);
            y += 30;

            var dynamics = report.ProfitDynamics;
            decimal maxProfit = dynamics.Max(d => d.Profit);
            if (maxProfit == 0)
            {
                gfx.DrawString("Нет данных для отображения", normalFont, XBrushes.Gray,
                    new XRect(marginLeft, y, chartWidth, 20), XStringFormats.TopLeft);
                return y + 30;
            }

            double xStart = marginLeft;
            double xEnd = marginLeft + chartWidth;
            double yStart = y;
            double yEnd = y + chartHeight;

            // Оси
            gfx.DrawLine(XPens.Black, xStart, yEnd, xEnd, yEnd);
            gfx.DrawLine(XPens.Black, xStart, yStart, xStart, yEnd);

            // Подписи оси Y
            for (int i = 0; i <= 4; i++)
            {
                decimal profitLevel = maxProfit * i / 4;
                double yPos = yEnd - (i / 4.0) * chartHeight;
                gfx.DrawString($"{profitLevel:N0} ₽", smallFont, XBrushes.Black,
                    new XRect(xStart - 45, yPos - 8, 40, 15), XStringFormats.TopRight);
                gfx.DrawLine(XPens.LightGray, xStart, yPos, xEnd, yPos);
            }

            // График
            double step = dynamics.Count > 1 ? chartWidth / (dynamics.Count - 1) : chartWidth;
            XPoint[] points = new XPoint[dynamics.Count];

            for (int i = 0; i < dynamics.Count; i++)
            {
                double x = xStart + i * step;
                double yPos = yEnd - (double)(dynamics[i].Profit / maxProfit) * chartHeight;
                points[i] = new XPoint(x, yPos);

                gfx.DrawEllipse(XPens.DarkBlue, XBrushes.LightBlue, x - 3, yPos - 3, 6, 6);

                if (dynamics.Count <= 15 || i % Math.Max(1, dynamics.Count / 10) == 0 || i == dynamics.Count - 1)
                {
                    string label = dynamics[i].Label;
                    gfx.DrawString(label, smallFont, XBrushes.Black,
                        new XRect(x - 15, yEnd + 3, 30, 12), XStringFormats.TopCenter);
                }
            }

            if (dynamics.Count > 1)
            {
                gfx.DrawLines(XPens.DarkBlue, points);
            }

            return y + chartHeight + 35;
        }

        private static void DrawFooter(XGraphics gfx, XFont smallFont, double pageHeight)
        {
            gfx.DrawLine(XPens.LightGray, 20, pageHeight - 40, 550, pageHeight - 40);
            gfx.DrawString($"Сформировано автоматически в системе TutorApp", smallFont, XBrushes.Gray,
                new XRect(20, pageHeight - 35, 530, 15), XStringFormats.TopCenter);
        }

        /// <summary>
        /// Открыть PDF файл в стандартной программе просмотра
        /// </summary>
        public static void OpenPdf(string filePath)
        {
            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }
    }
}
