using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Oddelenie
{
    public class OddelenieDto
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int veduciOddeleniaId { get; set; }
        public string? menoVeduceho { get; set; }
        public int? projektId { get; set; }
    }
}