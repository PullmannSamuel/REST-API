using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Employee;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IEmployeeRepository employeeRepo;

        public EmployeeController(ApplicationDBContext context, IEmployeeRepository employeeRepo)
        {
            this.context = context;
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await employeeRepo.GetAllAsync();

            var employeesDto = employees.Select(z => z.ToEmployeeDto());

            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var employee = await employeeRepo.GetByIdAsync(id);

            if (employee == null) {
                return NotFound();
            }

            return Ok(employee.ToEmployeeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest employeeDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var employeeModel = employeeDto.ToEmployeeFromCreateDto();
            await employeeRepo.CreateAsync(employeeModel);

            return CreatedAtAction(nameof(GetById), new { id = employeeModel.id }, employeeModel.ToEmployeeDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeRequestDto updateDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var employeeModel = await employeeRepo.UpdateAsync(id, updateDto);

            if (employeeModel == null) {
                return NotFound();
            }

            return Ok(employeeModel.ToEmployeeDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var employeeModel = await employeeRepo.DeleteAsync(id);

            if (employeeModel == null) {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}