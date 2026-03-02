using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public enum AgeGroup
    {
        [Description("6-10 лет")]
        A = 0,
        [Description("11-14 лет")]
        B = 1,
        [Description("15-18 лет")]
        C = 2,
        [Description("19+ лет")]
        D = 3,
    }
}
