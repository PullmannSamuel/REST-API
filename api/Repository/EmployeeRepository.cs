using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Employee;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Employee> CreateAsync(Employee employeeModel)
        {
            await context.employees.AddAsync(employeeModel);
            await context.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employeeModel = await context.employees.FirstOrDefaultAsync(z => z.id == id);

            if (employeeModel == null) {
                return null;
            }

            context.employees.Remove(employeeModel);
            await context.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await context.employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await context.employees.FirstOrDefaultAsync(z => z.id == id);
        }

        public async Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employeeDto)
        {
            var employeeModel = await context.employees
                .FirstOrDefaultAsync(z => z.id == id);
            
            if (employeeModel == null) {
                return null;
            }

            // Update employee details
            employeeModel.title = employeeDto.title;
            employeeModel.firstName = employeeDto.firstName;
            employeeModel.lastName = employeeDto.lastName;
            employeeModel.phoneNumber = employeeDto.phoneNumber;
            employeeModel.email = employeeDto.email;

            await context.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<bool> EmployeeExists(int id)
        {
            return await context.employees.AnyAsync(z => z.id == id);
        }
    }
}