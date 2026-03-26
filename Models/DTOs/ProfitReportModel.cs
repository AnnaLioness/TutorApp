using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProfitReportModel
    {
        // Основные показатели
        public decimal CurrentPeriodProfit { get; set; }
        public decimal PreviousPeriodProfit { get; set; }
        public decimal ProfitChangePercent { get; set; }
        public decimal ProfitChangeAbsolute { get; set; }

        // Количество уроков
        public int CurrentPeriodLessonsCount { get; set; }
        public int PreviousPeriodLessonsCount { get; set; }
        public int LessonsChangePercent { get; set; }

        // Активные ученики
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int ActiveStudentsPercent { get; set; }

        // Даты периодов
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime PreviousPeriodStart { get; set; }
        public DateTime PreviousPeriodEnd { get; set; }
        public bool HasPreviousPeriodData { get; set; }

        // Дополнительные показатели
        public decimal AverageLessonPrice { get; set; }
        public List<TopLessonTypeStat> TopLessonTypes { get; set; } = new();

        // Для графика динамики
        public List<PeriodProfitItem> ProfitDynamics { get; set; } = new();
    }
    public class PeriodProfitItem
    {
        public string Label { get; set; } = string.Empty;      // "01.01", "Янв", "Неделя 1"
        public decimal Profit { get; set; }
        public int LessonsCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
