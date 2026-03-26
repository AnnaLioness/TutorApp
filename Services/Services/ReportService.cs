using Models.DTOs;
using Models.Enums;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ReportService
    {
        private readonly LessonRepository _lessonRepository;
        private readonly StudentRepository _studentRepository;
        private readonly TypeRepository _typeRepository;

        public ReportService(
            LessonRepository lessonRepository,
            StudentRepository studentRepository,
            TypeRepository typeRepository)
        {
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
            _typeRepository = typeRepository;
        }

        /// <summary>
        /// Получить отчёт по прибыли за период
        /// </summary>
        public async Task<ProfitReportModel> GetProfitReport(ReportPeriodType periodType, DateTime selectedDate)
        {
            // Определяем границы текущего периода (как DateTime для удобства)
            var (currentStart, currentEnd) = GetPeriodBounds(periodType, selectedDate);

            // Определяем границы предыдущего периода
            var previousStart = GetPreviousPeriodStart(periodType, currentStart);
            var previousEnd = currentStart.AddDays(-1);

            var report = new ProfitReportModel
            {
                PeriodStart = currentStart,
                PeriodEnd = currentEnd,
                PreviousPeriodStart = previousStart,
                PreviousPeriodEnd = previousEnd
            };

            // Получаем проведённые уроки за текущий период
            var currentLessons = await _lessonRepository.GetCompletedLessonsByDateRange(
                DateOnly.FromDateTime(currentStart),
                DateOnly.FromDateTime(currentEnd));

            report.CurrentPeriodProfit = currentLessons.Sum(l => l.Price);
            report.CurrentPeriodLessonsCount = currentLessons.Count;

            // Получаем проведённые уроки за предыдущий период
            var previousLessons = await _lessonRepository.GetCompletedLessonsByDateRange(
                DateOnly.FromDateTime(previousStart),
                DateOnly.FromDateTime(previousEnd));

            report.PreviousPeriodProfit = previousLessons.Sum(l => l.Price);
            report.PreviousPeriodLessonsCount = previousLessons.Count;

            // Проверяем, есть ли данные за предыдущий период
            report.HasPreviousPeriodData = previousLessons.Any();

            if (report.HasPreviousPeriodData && report.PreviousPeriodProfit > 0)
            {
                report.ProfitChangePercent = (report.CurrentPeriodProfit - report.PreviousPeriodProfit)
                    / report.PreviousPeriodProfit * 100;
                report.ProfitChangeAbsolute = report.CurrentPeriodProfit - report.PreviousPeriodProfit;

                if (report.PreviousPeriodLessonsCount > 0)
                {
                    report.LessonsChangePercent = (int)((report.CurrentPeriodLessonsCount - report.PreviousPeriodLessonsCount)
                        / (double)report.PreviousPeriodLessonsCount * 100);
                }
            }
            else if (report.HasPreviousPeriodData && report.PreviousPeriodProfit == 0 && report.CurrentPeriodProfit > 0)
            {
                report.ProfitChangePercent = 100;
                report.ProfitChangeAbsolute = report.CurrentPeriodProfit;
            }

            // Активные ученики
            var activeStudentIds = currentLessons.Select(l => l.StudentId).Distinct();
            report.ActiveStudents = activeStudentIds.Count();
            report.TotalStudents = await _studentRepository.GetCountAsync();

            if (report.TotalStudents > 0)
            {
                report.ActiveStudentsPercent = (int)((double)report.ActiveStudents / report.TotalStudents * 100);
            }

            // Средний чек
            report.AverageLessonPrice = currentLessons.Any()
    ? (decimal)currentLessons.Average(l => l.Price)
    : 0;

            // Топ-типы уроков
            var topTypes = currentLessons
                .GroupBy(l => l.TypeId)
                .Select(g => new TopLessonTypeStat
                {
                    TypeId = g.Key,
                    TypeName = GetTypeName(g.Key).Result,
                    TotalAmount = g.Sum(l => l.Price),
                    LessonsCount = g.Count(),
                    PercentageOfTotal = report.CurrentPeriodProfit > 0
                        ? (int)(g.Sum(l => l.Price) / report.CurrentPeriodProfit * 100)
                        : 0
                })
                .OrderByDescending(t => t.TotalAmount)
                .Take(5)
                .ToList();

            report.TopLessonTypes = topTypes;

            // Динамика для графика
            report.ProfitDynamics = await GetProfitDynamics(periodType, currentStart, currentEnd);

            return report;
        }

        /// <summary>
        /// Получить динамику прибыли внутри периода (для графика)
        /// </summary>
        private async Task<List<PeriodProfitItem>> GetProfitDynamics(ReportPeriodType periodType, DateTime start, DateTime end)
        {
            var dynamics = new List<PeriodProfitItem>();

            var lessons = await _lessonRepository.GetCompletedLessonsByDateRange(
                DateOnly.FromDateTime(start),
                DateOnly.FromDateTime(end));

            switch (periodType)
            {
                case ReportPeriodType.Week:
                    // Неделя: по дням
                    for (var date = start; date <= end; date = date.AddDays(1))
                    {
                        var targetDate = DateOnly.FromDateTime(date);
                        var dayLessons = lessons.Where(l => l.Date == targetDate).ToList();
                        dynamics.Add(new PeriodProfitItem
                        {
                            Label = date.ToString("dd.MM"),
                            Profit = dayLessons.Sum(l => l.Price),
                            LessonsCount = dayLessons.Count,
                            StartDate = date,
                            EndDate = date
                        });
                    }
                    break;

                case ReportPeriodType.Month:
                    // Месяц: по дням
                    for (var date = start; date <= end; date = date.AddDays(1))
                    {
                        var targetDate = DateOnly.FromDateTime(date);
                        var dayLessons = lessons.Where(l => l.Date == targetDate).ToList();
                        dynamics.Add(new PeriodProfitItem
                        {
                            Label = date.ToString("dd.MM"),
                            Profit = dayLessons.Sum(l => l.Price),
                            LessonsCount = dayLessons.Count,
                            StartDate = date,
                            EndDate = date
                        });
                    }
                    break;

                case ReportPeriodType.Year:
                    // Год: по месяцам
                    for (int month = 1; month <= 12; month++)
                    {
                        var monthLessons = lessons.Where(l => l.Date.Month == month).ToList();
                        var monthStart = new DateTime(start.Year, month, 1);
                        dynamics.Add(new PeriodProfitItem
                        {
                            Label = monthStart.ToString("MMM"),
                            Profit = monthLessons.Sum(l => l.Price),
                            LessonsCount = monthLessons.Count,
                            StartDate = monthStart,
                            EndDate = monthStart.AddMonths(1).AddDays(-1)
                        });
                    }
                    break;
            }

            return dynamics;
        }

        /// <summary>
        /// Получить название типа по ID
        /// </summary>
        private async Task<string> GetTypeName(int typeId)
        {
            var type = await _typeRepository.GetByIdAsync(typeId);
            return type?.TypeName ?? $"[Тип {typeId}]";
        }

        /// <summary>
        /// Получить границы периода
        /// </summary>
        private (DateTime start, DateTime end) GetPeriodBounds(ReportPeriodType periodType, DateTime selectedDate)
        {
            switch (periodType)
            {
                case ReportPeriodType.Week:
                    // Неделя: понедельник - воскресенье
                    var startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + (int)DayOfWeek.Monday);
                    if (selectedDate.DayOfWeek == DayOfWeek.Sunday)
                        startOfWeek = selectedDate.AddDays(-6);
                    return (startOfWeek, startOfWeek.AddDays(6));

                case ReportPeriodType.Month:
                    var startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                    var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                    return (startOfMonth, endOfMonth);

                case ReportPeriodType.Year:
                    var startOfYear = new DateTime(selectedDate.Year, 1, 1);
                    var endOfYear = new DateTime(selectedDate.Year, 12, 31);
                    return (startOfYear, endOfYear);

                default:
                    throw new ArgumentException("Неизвестный тип периода");
            }
        }

        /// <summary>
        /// Получить начало предыдущего периода
        /// </summary>
        private DateTime GetPreviousPeriodStart(ReportPeriodType periodType, DateTime currentStart)
        {
            return periodType switch
            {
                ReportPeriodType.Week => currentStart.AddDays(-7),
                ReportPeriodType.Month => currentStart.AddMonths(-1),
                ReportPeriodType.Year => currentStart.AddYears(-1),
                _ => currentStart
            };
        }
    }
}
