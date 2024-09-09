using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Company
{
    public class CompanyDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int directorId { get; set; }
        public string? leaderName { get; set; }
        public List<int> divisionsId { get; set; } = new List<int>();

    }
}