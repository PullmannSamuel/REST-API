using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.Dtos.Company;
using api.Dtos.Division;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace api.Testing
{
    public class DivisionRepositoryTests
    {
        private readonly ApplicationDBContext context;
        private readonly IDivisionRepository divisionRepo;
        public DivisionRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "DivisionTestDB")
                .Options;

            context = new ApplicationDBContext(options);
            divisionRepo = new DivisionRepository(context);
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
        public async Task Create_AddsDivisionIdToCompany()
        {
            // Arrange
            var company = new Company
            {
                id = 2,
                name = "TestCompany2",
                code = "TEST02",
                directorId = 1
            };
            context.companies.Add(company);
            await context.SaveChangesAsync();
            var division = new Division
            {
                id = 3,
                name = "test",
                companyId = 2
            };

            // Act
            await divisionRepo.CreateAsync(division);

            // Assert
            Assert.Single(company.divisionsId);
            Assert.Equal(division.id, company.divisionsId[0]);
        }

        [Fact]
        public async Task Update_CorrectsDivisionIdsOfCompanies()
        {
            // Arrange
            var employee = new Employee();
            var company3 = new Company
            {
                id = 3,
                name = "TestCompany3",
                code = "TEST03",
                directorId = employee.id,
                director = employee
            };
            var company4 = new Company
            {
                id = 4,
                name = "TestCompany4",
                code = "TEST04",
                directorId = employee.id,
                director = employee
            };
            context.companies.Add(company3);
            context.companies.Add(company4);
            await context.SaveChangesAsync();

            var division = new Division
            {
                id = 4,
                name = "test",
                companyId = 3,
                headOfDivisionId = employee.id,
                headOfDivision = employee
            };

            await divisionRepo.CreateAsync(division);

            var divisionDto = new UpdateDivisionRequestDto
            {
                name = "test",
            };

            // Act
            await divisionRepo.UpdateAsync(company4.id, division.id, divisionDto);

            // Assert
            Assert.Empty(company3.divisionsId);
            Assert.Equal(division.id, company4.divisionsId[0]);
        }

        [Fact]
        public async Task Delete_RemovesDivisionIdFromCompany()
        {
            // Arrange
            var company = new Company
            {
                id = 5,
                name = "TestCompany5",
                code = "TEST05",
                directorId = 1

            };
            context.companies.Add(company);
            await context.SaveChangesAsync();

            var division = new Division
            {
                id = 5,
                name = "test",
                companyId = 5,
            };

            await divisionRepo.CreateAsync(division);

            // Act
            await divisionRepo.DeleteAsync(division.id);

            // Assert
            Assert.Empty(company.divisionsId);
        }
    }
}