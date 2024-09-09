using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Project
{
    public class ProjectDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int projectManagerId { get; set; }
        public string? leaderName { get; set; }
        public List<int> departmentsId { get; set; } = new List<int>();
        public int? divisionId { get; set; }
    }
}