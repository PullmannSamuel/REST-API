using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Firma
{
    public class FirmaDto
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int riaditelId { get; set; }
        public string? menoVeduceho { get; set; }
        public List<int> divizieId { get; set; } = new List<int>();

    }
}