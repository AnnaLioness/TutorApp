using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class VkSettings
    {
        public long GroupId { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public bool IsConfigured { get; set; } = false;
    }
}
