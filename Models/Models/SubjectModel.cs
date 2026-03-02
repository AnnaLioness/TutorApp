using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class SubjectModel : IId
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }
    }
}
