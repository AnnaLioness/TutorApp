using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PublicationModel : IId
    {
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsPublicted { get; set; }
        public int MaterialId { get; set; }
        public MaterialModel Material { get; set; }
    }
}
