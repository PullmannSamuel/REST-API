using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Division
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int headOfDivisionId { get; set; }
        public Employee? headOfDivision { get; set; }
        public string? leaderName => $"{headOfDivision?.firstName} {headOfDivision?.lastName}";
        public List<int> projectsId { get; set; } = new List<int>();
        public int companyId { get; set; }
    }
}