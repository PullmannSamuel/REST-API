using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using api.Controllers;
using api.Interfaces;
using api.Data;
using api.Helpers;
using api.Dtos.Company;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api.Testing
{
    public class CompanyControllerTesting
    {
        private readonly Mock<ICompanyRepository> companyRepoMock;
        private readonly Mock<IEmployeeRepository> employeeRepoMock;
        private readonly CompanyController companyController;
        private readonly ApplicationDBContext context;
        public CompanyControllerTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;
            
            companyRepoMock = new Mock<ICompanyRepository>();
            employeeRepoMock = new Mock<IEmployeeRepository>();
            context = new ApplicationDBContext(options);

            companyController = new CompanyController(context, 
                companyRepoMock.Object, 
                employeeRepoMock.Object);
        }   

        [Fact]
        public async Task GetAll_ReturnsOk_WithCompanyList()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company { id = 1, name = "Company 1", code = "001", directorId = 1 },
                new Company { id = 2, name = "Company 2", code = "002", directorId = 2 }
            };
            companyRepoMock.Setup(repo => repo.GetAllAsync(It.IsAny<QueryObject>())).ReturnsAsync(companies);

            // Act
            var result = await companyController.GetAll(new QueryObject());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<CompanyDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenCompanyDoesNotExist()
        {
            // Arrange
            companyRepoMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Company?)null);

            // Act
            var result = await companyController.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithCompanyDto()
        {
            // Arrange
            var company = new Company { id = 1, name = "Test Company", code = "001", directorId = 1 };
            companyRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(company);

            // Act
            var result = await companyController.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CompanyDto>(okResult.Value);
            Assert.Equal("Test Company", returnValue.name);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            companyController.ModelState.AddModelError("name", "The Name field is required.");
            var companyDto = new CreateCompanyRequestDto 
            {
                code = "testCode",
                directorId = 1
            };
            employeeRepoMock.Setup(repo => repo.EmployeeExists(1)).ReturnsAsync(false);

            // Act
            var result = await companyController.Create(companyDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenDirectorDoesNotExist()
        {
            // Arrange
            var companyDto = new CreateCompanyRequestDto { directorId = 99 };
            employeeRepoMock.Setup(repo => repo.EmployeeExists(99)).ReturnsAsync(false);

            // Act
            var result = await companyController.Create(companyDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid director ID.", badRequestResult.Value);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction_WhenCompanyIsCreated()
        {
            // Arrange
            var companyDto = new CreateCompanyRequestDto { name = "New Company", code = "003", directorId = 1 };
            var company = new Company { id = 1, name = "New Company", code = "003", directorId = 1 };
            
            employeeRepoMock.Setup(repo => repo.EmployeeExists(1)).ReturnsAsync(true);
            companyRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Company>())).ReturnsAsync(company);

            // Act
            var result = await companyController.Create(companyDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<CompanyDto>(createdAtActionResult.Value);
            Assert.Equal("New Company", returnValue.name);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenCompanyDoesNotExist()
        {
            // Arrange
            var companyDto = new UpdateCompanyRequestDto { name = "Updated Company", code = "004", directorId = 1 };
            employeeRepoMock.Setup(repo => repo.EmployeeExists(1)).ReturnsAsync(true);
            companyRepoMock.Setup(repo => repo.UpdateAsync(1, companyDto)).ReturnsAsync((Company?)null);

            // Act
            var result = await companyController.Update(1, companyDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenCompanyDoesNotExist()
        {
            // Arrange
            companyRepoMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync((Company?)null);

            // Act
            var result = await companyController.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenCompanyIsDeleted()
        {
            // Arrange
            var company = new Company { id = 1, name = "Company to Delete", code = "005", directorId = 1 };
            companyRepoMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(company);

            // Act
            var result = await companyController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

    }
}