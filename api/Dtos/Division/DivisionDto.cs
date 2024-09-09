using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;


namespace api.Dtos.Division
{
    public class DivisionDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int headOfDivisionId { get; set; }
        public string? leaderName { get; set; }
        public List<int> projectsId { get; set; } = new List<int>();
        public int? companyId { get; set; }

    }
}