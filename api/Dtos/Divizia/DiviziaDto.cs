using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;


namespace api.Dtos.Divizia
{
    public class DiviziaDto
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int veduciDivizieId { get; set; }
        public string? menoVeduceho { get; set; }
        public List<int> projektyId { get; set; } = new List<int>();
        public int? firmaId { get; set; }

    }
}