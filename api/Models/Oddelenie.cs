using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Oddelenie
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int veduciOddeleniaId { get; set; }
        public Zamestnanec? veduciOddelenia { get; set; }
        public string? menoVeduceho => $"{veduciOddelenia?.meno} {veduciOddelenia?.priezvisko}";
        public int? projektId { get; set; }
    }
}