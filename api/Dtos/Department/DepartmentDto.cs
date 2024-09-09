using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Department
{
    public class DepartmentDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public int headOfDepartmentId { get; set; }
        public string? leaderName { get; set; }
        public int? projectId { get; set; }
    }
}