using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Firma
    {
        public int id { get; set; }
        public string nazov { get; set; } = string.Empty;
        public string kod { get; set; } = string.Empty;
        public int riaditelId { get; set; }
        public Zamestnanec? riaditel { get; set; }
        public string? menoVeduceho => $"{riaditel?.meno} {riaditel?.priezvisko}";
        public List<int> divizieId { get; private set; } = new List<int>();
        
    }
}