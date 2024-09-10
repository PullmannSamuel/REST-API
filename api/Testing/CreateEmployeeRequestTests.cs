using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using Xunit;
using Xunit.Abstractions;

namespace api.Testing
{
    public class CreateEmployeeRequestTests
    {
        [Fact]
        public void InvalidCreateRequest()
        {
            // Arrange
            var invalidEmployeeRequest = new CreateEmployeeRequest
            {
                firstName = "",
                lastName = "",
                phoneNumber = "invalidPhone",
                email = "invalidEmail"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(invalidEmployeeRequest);
            var isValid = Validator.TryValidateObject(invalidEmployeeRequest, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Equal(4, validationResults.Count);
            
            Assert.Contains(validationResults, v => v.ErrorMessage == "The firstName field is required.");
            Assert.Contains(validationResults, v => v.ErrorMessage == "The lastName field is required.");
            Assert.Contains(validationResults, v => v.ErrorMessage == "The phoneNumber field is not a valid phone number.");
            Assert.Contains(validationResults, v => v.ErrorMessage == "The email field is not a valid e-mail address.");
        }

        [Fact]
        public void ValidCreateRequest()
        {
            // Arrange
            var invalidEmployeeRequest = new CreateEmployeeRequest
            {
                firstName = "Jozef",
                lastName = "Mrkva",
                phoneNumber = "+421 987 654 321",
                email = "jozef.mrkva@test.com"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(invalidEmployeeRequest);
            var isValid = Validator.TryValidateObject(invalidEmployeeRequest, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void TooLongNamesRequest()
        {
            // Arrange
            var invalidEmployeeRequest = new CreateEmployeeRequest
            {
                firstName = "thisnameistooloooooooooooooooooooooooooooooooooooooooooooong",
                lastName = "thisnameistooloooooooooooooooooooooooooooooooooooooooooooong",
                phoneNumber = "+421 987 654 321",
                email = "valid.email@test.com"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(invalidEmployeeRequest);
            var isValid = Validator.TryValidateObject(invalidEmployeeRequest, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Equal(2, validationResults.Count);
            
            Assert.Contains(validationResults, v => v.ErrorMessage == "First name cant be longer than 20 characters");
            Assert.Contains(validationResults, v => v.ErrorMessage == "Last name cant be longer than 30 characters");
        }
    }
}