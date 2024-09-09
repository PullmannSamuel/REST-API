using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Project;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository projectRepo;
        private readonly IDivisionRepository divisionRepo;
        public ProjectController(IProjectRepository projectRepo, IDivisionRepository divisionRepo)
        {
            this.projectRepo = projectRepo;
            this.divisionRepo = divisionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await projectRepo.GetAllAsync();

            var projectsDto = projects.Select(p => p.ToProjectDto());

            return Ok(projectsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var project = await projectRepo.GetByIdAsync(id);

            if (project == null) {
                return NotFound();
            }

            return Ok(project.ToProjectDto());
        }

        [HttpPost("{divisionId}")]
        public async Task<IActionResult> Create([FromRoute] int divisionId, [FromBody] CreateProjectDto projectDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await divisionRepo.DivisionExists(divisionId)) {
                return BadRequest($"Division with id {divisionId} doesnt exist!");
            }

            var projectModel = projectDto.ToProjectFromCreate(divisionId);
            await projectRepo.CreateAsync(projectModel);

            return CreatedAtAction(nameof(GetById), new { id = projectModel.id }, projectModel.ToProjectDto()); 
        }

        [HttpPut("{divisionId}/projects/{projectId}")]
        public async Task<IActionResult> Update([FromRoute] int divisionId, [FromRoute] int projectId, UpdateProjectRequestDto projectDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await divisionRepo.DivisionExists(divisionId)) {
                return BadRequest($"Division with id {divisionId} doesnt exist!");
            }

            var projectModel = await projectRepo.UpdateAsync(divisionId, projectId, projectDto);

            if (projectModel == null) {
                return NotFound();
            }

            return Ok(projectModel.ToProjectDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var projectModel = await projectRepo.DeleteAsync(id);

            if (projectModel == null) {
                return NotFound();
            }

            return NoContent();
        }
    }
}