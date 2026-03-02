using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class LessonModel : IId
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public int Price { get; set; }
        public string Comment { get; set; }
        public LessonStatus Status { get; set; }
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        public int TypeId { get; set; }
        public TypeModel Type { get; set; }
    }
}
