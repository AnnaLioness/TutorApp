using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class TopLessonTypeStat
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int LessonsCount { get; set; }
        public int PercentageOfTotal { get; set; }
    }
}
