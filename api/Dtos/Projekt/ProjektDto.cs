using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Projekt
{
    public class ProjektDto
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int veduciProjektuId { get; set; }
        public string? menoVeduceho { get; set; }
        public List<int> oddeleniaId { get; set; } = new List<int>();
        public int? diviziaId { get; set; }
    }
}