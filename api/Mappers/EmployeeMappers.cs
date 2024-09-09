using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this Employee employeeModel)
        {
            return new EmployeeDto
            {
                id = employeeModel.id,
                title = employeeModel.title,
                firstName = employeeModel.firstName,
                lastName = employeeModel.lastName,
                phoneNumber = employeeModel.phoneNumber,
                email = employeeModel.email
            };
        }

        public static Employee ToEmployeeFromCreateDto(this CreateEmployeeRequest employeeDto)
        {
            return new Employee
            {
                title = employeeDto.title,
                firstName = employeeDto.firstName,
                lastName = employeeDto.lastName,
                phoneNumber = employeeDto.phoneNumber,
                email = employeeDto.email
            };
        }
    }
}