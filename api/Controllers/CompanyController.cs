using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Company;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly ICompanyRepository companyRepo;

        public CompanyController(ApplicationDBContext context, ICompanyRepository companyRepo)
        {
            this.context = context;
            this.companyRepo = companyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var companies = await companyRepo.GetAllAsync();

            var companiesDto = companies.Select(f => f.ToCompanyDto());

            return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var company = await companyRepo.GetByIdAsync(id);

            if (company == null) {
                return NotFound();
            }

            return Ok(company.ToCompanyDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDto companyDto) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var companyModel = companyDto.ToCompanyFromCreateDto();
            await companyRepo.CreateAsync(companyModel);
            
            return CreatedAtAction(nameof(GetById), new { id = companyModel.id }, companyModel.ToCompanyDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompanyRequestDto updateDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var companyModel = await companyRepo.UpdateAsync(id, updateDto);

            if (companyModel == null) {
                return NotFound();
            }

            return Ok(companyModel.ToCompanyDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var companyModel = await companyRepo.DeleteAsync(id);

            if (companyModel == null) {
                return NotFound();
            }
            
            return NoContent();
        }
    }   
}