using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Projekt
{
    public class CreateProjektDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Nazov musi obsahovat aspon 1 znak")]
        [MaxLength(60, ErrorMessage = "Nazov nesmie prekracovat 60 znakov")]
        public string nazov { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Kod musi obsahovat aspon 1 znak")]
        [MaxLength(50, ErrorMessage = "Kod nesmie prekracovat 50 znakov")]
        public string kod { get; set; } = string.Empty;
        public int veduciProjektuId { get; set; }
    }
}