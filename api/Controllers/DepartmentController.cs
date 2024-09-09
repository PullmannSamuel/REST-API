using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Department;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepo;
        private readonly IProjectRepository projectRepo;
        public DepartmentController(IDepartmentRepository departmentRepo, IProjectRepository projectRepo)
        {
            this.departmentRepo = departmentRepo;
            this.projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await departmentRepo.GetAllAsync();

            var departmentsDto = departments.Select(o => o.ToDepartmentDto());

            return Ok(departmentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var department = await departmentRepo.GetByIdAsync(id);

            if (department == null) {
                return NotFound();
            }

            return Ok(department.ToDepartmentDto());
        }

        [HttpPost("{projectId}")]
        public async Task<IActionResult> Create([FromRoute] int projectId, [FromBody] CreateDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await projectRepo.ProjectExists(projectId)) {
                return BadRequest($"Project with id {projectId} doesnt exist!");
            }

            var departmentModel = departmentDto.ToDepartmentFromCreate(projectId);
            await departmentRepo.CreateAsync(departmentModel);

            return CreatedAtAction(nameof(GetById), new { id = departmentModel.id }, departmentModel.ToDepartmentDto());
        }

        [HttpPut("{projectId}/departments/{departmentId}")]
        public async Task<IActionResult> Update([FromRoute] int projectId, [FromRoute] int departmentId, [FromBody] UpdateDepartmentRequestDto departmentDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await projectRepo.ProjectExists(projectId)) {
                return BadRequest($"Project with id {projectId} doesnt exist!");
            }

            var departmentModel = await departmentRepo.UpdateAsync(projectId, departmentId, departmentDto);

            if (departmentModel == null) {
                return NotFound();
            }

            return Ok(departmentModel.ToDepartmentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var department = await departmentRepo.DeleteAsync(id);

            if (department == null) {
                return NotFound();
            } 

            return NoContent();
        }
    }
}