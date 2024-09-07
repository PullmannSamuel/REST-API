using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Projekt
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int veduciProjektuId { get; set; }
        public Zamestnanec? veduciProjektu { get; set; }
        public string? menoVeduceho => $"{veduciProjektu?.meno} {veduciProjektu?.priezvisko}";
        public List<int> oddeleniaId { get; set; } = new List<int>();
        public int? diviziaId { get; set; }
        
    }
}