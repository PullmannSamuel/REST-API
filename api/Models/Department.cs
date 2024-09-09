using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int headOfDepartmentId { get; set; }
        public Employee? headOfDepartment { get; set; }
        public string? leaderName => $"{headOfDepartment?.firstName} {headOfDepartment?.lastName}";
        public int? projectId { get; set; }
    }
}