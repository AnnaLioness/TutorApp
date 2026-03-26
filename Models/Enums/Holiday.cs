using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public enum Holiday
    {
        [Description("Новый год")]
        [HolidayDate(1, 1)]
        NewYear = 1,

        [Description("Рождество")]
        [HolidayDate(12, 25)]
        Christmas = 2,

        [Description("Хеллоуин")]
        [HolidayDate(10, 31)]
        Halloween = 3,

        [Description("День святого Валентина")]
        [HolidayDate(2, 14)]
        ValentinesDay = 4,
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class HolidayDate : Attribute
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public HolidayDate(int month, int day) { Month = month; Day = day; }
    }
}
