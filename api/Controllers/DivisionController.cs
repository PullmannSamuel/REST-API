using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Division;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/division")]
    [ApiController]
    public class DivisionController : ControllerBase
    {

        private readonly IDivisionRepository divisionRepo;
        private readonly ICompanyRepository companyRepo;
        private readonly IEmployeeRepository employeeRepo;

        public DivisionController(IDivisionRepository divisionRepo, 
            ICompanyRepository companyRepo, IEmployeeRepository employeeRepo)
        {
            this.divisionRepo = divisionRepo;
            this.companyRepo = companyRepo;
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var divisions = await divisionRepo.GetAllAsync(query);

            var divisionsDto = divisions.Select(d => d.ToDivisionDto());

            return Ok(divisionsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var division = await divisionRepo.GetByIdAsync(id);

            if (division == null) {
                return NotFound();
            }

            return Ok(division.ToDivisionDto());
        }

        [HttpPost("{companyId}")]
        public async Task<IActionResult> Create([FromRoute] int companyId, [FromBody] CreateDivisionDto divisionDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await companyRepo.CompanyExists(companyId)) {
                return BadRequest($"Company with id {companyId} doesnt exist!");
            }

            var employeeExists = await employeeRepo.EmployeeExists(divisionDto.headOfDivisionId);
            if (!employeeExists)
            {
                return BadRequest("Invalid head of division ID.");
            }

            var divisionModel = divisionDto.ToDivisionFromCreate(companyId);
            await divisionRepo.CreateAsync(divisionModel);

            return CreatedAtAction(nameof(GetById), new { id = divisionModel.id }, divisionModel.ToDivisionDto());
        }

        [HttpPut("{companyId}/divisions/{divisionId}")]
        public async Task<IActionResult> Update([FromRoute] int companyId, [FromRoute] int divisionId, [FromBody] UpdateDivisionRequestDto divisionDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await companyRepo.CompanyExists(companyId)) {
                return BadRequest($"Company with id {companyId} doesnt exist!");
            }

            var employeeExists = await employeeRepo.EmployeeExists(divisionDto.headOfDivisionId);
            if (!employeeExists)
            {
                return BadRequest("Invalid head of division ID.");
            }

            var divisionModel = await divisionRepo.UpdateAsync(companyId, divisionId, divisionDto);

            if (divisionModel == null) {
                return NotFound();
            }

            return Ok(divisionModel.ToDivisionDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var divisionModel = await divisionRepo.DeleteAsync(id);

            if (divisionModel == null) {
                return NotFound();
            }

            return NoContent();
        }
    }
}