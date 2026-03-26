using Microsoft.VisualBasic.FileIO;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class MaterialModel : IId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int TypeId { get; set; }
        public TypeModel Type { get; set; }
        public int LevelId { get; set; }
        public LevelModel Level { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public Season Season { get; set; }
        public bool IsHoliday { get; set; }
        public Holiday? Holiday { get; set; }
    }
}
