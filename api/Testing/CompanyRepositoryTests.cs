using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Company;
using api.Helpers;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace api.Testing
{
    public class CompanyRepositoryTests
    {
        private readonly ApplicationDBContext context;
        private readonly ICompanyRepository companyRepo;
        public CompanyRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "CompanyTestDB")
                .Options;

            context = new ApplicationDBContext(options);
            companyRepo = new CompanyRepository(context);
            context.Database.EnsureCreated();

            // Populate in-memory database with test data
            var employee1 = new Employee 
            {
                id = 1,
                title = "", 
                firstName = "Happy", 
                lastName = "Tester",
                email = "happy.tester@example.com", 
                phoneNumber = "+421 999 999 999"
            };
            var employee2 = new Employee 
            {
                id = 2,
                title = "", 
                firstName = "Sad", 
                lastName = "Tester",
                email = "Sad.tester@example.com", 
                phoneNumber = "+421 888 888 888"
            };

            if (!context.employees.Any()) {
                context.employees.Add(employee1);
                context.employees.Add(employee2);
                context.SaveChanges();
            }
            if (!context.companies.Any()) {
                context.companies.Add(new Company
                {
                    id = 1,
                    name = "TestCompany",
                    code = "TEST01",
                    directorId = 1,
                    director = employee1
                });
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task CreateAsync_AddsCompany()
        {
            // Arrange
            var newCompany = new Company { id = 2, name = "NewCompany", code = "NEW01", directorId = 2 };

            // Act
            var result = await companyRepo.CreateAsync(newCompany);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NewCompany", result.name);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCorrectCompany()
        {
            // Arrange
            var employee3 = new Employee 
            {
                id = 3,
                title = "", 
                firstName = "Mad", 
                lastName = "Tester",
                email = "mad.tester@example.com", 
                phoneNumber = "+421 777 777 777"
            };
            context.employees.Add(employee3);

            context.companies.Add(new Company
            {
                id = 3,
                name = "TestCompany3",
                code = "TEST03",
                directorId = 3,
                director = employee3
            });
            await context.SaveChangesAsync();

            // Act
            var result = await companyRepo.GetByIdAsync(3);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.id);
            Assert.Equal("TestCompany3", result.name);
        }

        [Fact]
        public async Task DeleteAsync_RemovesCompany()
        {
            // Arrange
            context.companies.Add(new Company
            {
                id = 4,
                name = "TestCompany4",
                code = "TEST04",
                directorId = 3,
            });
            await context.SaveChangesAsync();

            // Act
            var result = await companyRepo.DeleteAsync(4);

            // Assert
            Assert.NotNull(result);
            var companyInDb = await context.companies.FirstOrDefaultAsync(c => c.id == 4);
            Assert.Null(companyInDb);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesCompany()
        {
            // Arrange
            var updateDto = new UpdateCompanyRequestDto { name = "UpdatedCompany", code = "UPD01", directorId = 1 };
            

            // Act
            var result = await companyRepo.UpdateAsync(1, updateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("UpdatedCompany", result.name);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCompanies()
        {
            var companiesCountBeforeAdd = context.companies.Count();
            // Arange
            var query = new QueryObject();
            var employee3 = new Employee 
            {
                id = 4,
                title = "", 
                firstName = "Mad", 
                lastName = "Max",
                email = "mad.max@example.com", 
                phoneNumber = "+421 555 555 555"
            };
            context.employees.Add(employee3);

            context.companies.Add(new Company
            {
                id = 5,
                name = "TestCompany5",
                code = "TEST05",
                directorId = 4,
                director = employee3
            });
            await context.SaveChangesAsync();
            

            // Act
            var result = await companyRepo.GetAllAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<Company>>(result);
            Assert.Equal(companiesCountBeforeAdd + 1, result.Count());

        }
        

    }
}