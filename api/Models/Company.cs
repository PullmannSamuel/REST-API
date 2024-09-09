using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int directorId { get; set; }
        public Employee? director { get; set; }
        public string? leaderName => $"{director?.firstName} {director?.lastName}";
        public List<int> divisionsId { get; private set; } = new List<int>();
        
    }
}