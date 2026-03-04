using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class StudentModel : IId
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public int LevelId { get; set; }
        public LevelModel? Level { get; set; }
        public List<LessonModel> Lessons { get; set; }

    }
}
