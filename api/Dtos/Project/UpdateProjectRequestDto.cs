using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Project
{
    public class UpdateProjectRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name must contain atleast 1 character")]
        [MaxLength(60, ErrorMessage = "Name cant be longer than 60 characters")]
        public string name { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Code must contain atleast 1 character")]
        [MaxLength(50, ErrorMessage = "Code cant be longer than 50 characters")]
        public string code { get; set; } = string.Empty;
        public int projectManagerId { get; set; }
    }
}