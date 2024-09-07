using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Zamestnanec
{
    public class CreateZamestnanecRequest
    {
        public string? titul { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Meno musi mat aspon 1 znak")]
        [MaxLength(20, ErrorMessage = "Meno nesmie prekracovat 20 znakov")]
        public string meno { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Priezvisko musi mat aspon 1 znak")]
        [MaxLength(30, ErrorMessage = "Priezvisko nesmie prekracovat 30 znakov")]
        public string priezvisko { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Telefonne cislo musi mat aspon 10 znakok")]
        [MaxLength(20, ErrorMessage = "Telefonne cislo nesmie prekracovat 20 znakov")]
        public string telefon { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Email musi mat aspon 1 znak")]
        [MaxLength(50, ErrorMessage = "Email nesmie prekracovat 50 znakov")]
        public string email { get; set; } = string.Empty;
    }
}