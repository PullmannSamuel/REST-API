using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int projectManagerId { get; set; }
        public Employee? projectManager { get; set; }
        public string? leaderName => $"{projectManager?.firstName} {projectManager?.lastName}";
        public List<int> departmentsId { get; set; } = new List<int>();
        public int? divisionId { get; set; }
    }
}