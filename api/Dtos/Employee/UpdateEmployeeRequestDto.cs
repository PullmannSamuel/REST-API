using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Employee
{
    public class UpdateEmployeeRequestDto
    {
        public string? title { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "First name must contain atleast 1 character")]
        [MaxLength(20, ErrorMessage = "First name cant be longer than 20 characters")]
        public string firstName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Last name must contain atleast 1 character")]
        [MaxLength(30, ErrorMessage = "Last name cant be longer than 30 characters")]
        public string lastName { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Phonenumber must contain atleast 1 character")]
        [MaxLength(20, ErrorMessage = "Phonenumber cant be longer than 20 characters")]
        public string phoneNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Email must contain atleast 1 character")]
        [MaxLength(50, ErrorMessage = "Email cant be longer than 20 characters")]
        public string email { get; set; } = string.Empty;
    }
}