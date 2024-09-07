using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Divizia
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int veduciDivizieId { get; set; }
        public Zamestnanec? veduciDivizie { get; set; }
        public string? menoVeduceho => $"{veduciDivizie?.meno} {veduciDivizie?.priezvisko}";
        public List<int> projektyId { get; set; } = new List<int>();
        public int firmaId { get; set; }
    }
}