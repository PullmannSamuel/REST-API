using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Zamestnanec
    {
        public int id { get; set; }
        public string? titul { get; set; } = string.Empty;
        public string meno { get; set; } = string.Empty;
        public string priezvisko { get; set; } = string.Empty;
        public string telefon { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}