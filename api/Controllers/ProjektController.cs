using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Projekt;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/projekt")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly IProjektRepository projektRepo;
        private readonly IDiviziaRepository diviziaRepo;
        public ProjektController(IProjektRepository projektRepo, IDiviziaRepository diviziaRepo)
        {
            this.projektRepo = projektRepo;
            this.diviziaRepo = diviziaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projekty = await projektRepo.GetAllAsync();

            var projektyDto = projekty.Select(p => p.ToProjektDto());

            return Ok(projektRepo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var projekt = await projektRepo.GetByIdAsync(id);

            if (projekt == null) {
                return NotFound();
            }

            return Ok(projekt.ToProjektDto());
        }

        [HttpPost("{diviziaId}")]
        public async Task<IActionResult> Create([FromRoute] int diviziaId, [FromBody] CreateProjektDto projektDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await diviziaRepo.DiviziaExists(diviziaId)) {
                return BadRequest($"Divizia s id {diviziaId} neexistuje!");
            }

            var projektModel = projektDto.ToProjektFromCreate(diviziaId);
            await projektRepo.CreateAsync(projektModel);

            return CreatedAtAction(nameof(GetById), new { id = projektModel.id }, projektModel.ToProjektDto()); 
        }

        [HttpPut("{diviziaId}/projekty/{projektId}")]
        public async Task<IActionResult> Update([FromRoute] int diviziaId, [FromRoute] int projektId, UpdateProjektRequestDto projektDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await diviziaRepo.DiviziaExists(diviziaId)) {
                return BadRequest($"Divizia s id {diviziaId} neexistuje!");
            }

            var projektModel = await projektRepo.UpdateAsync(diviziaId, projektId, projektDto);

            if (projektModel == null) {
                return NotFound();
            }

            return Ok(projektModel.ToProjektDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var projektModel = await projektRepo.DeleteAsync(id);

            if (projektModel == null) {
                return NotFound();
            }

            return NoContent();
        }
    }
}