using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Divizia;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/divizia")]
    [ApiController]
    public class DiviziaController : ControllerBase
    {

        private readonly IDiviziaRepository diviziaRepo;
        private readonly IFirmaRepository firmaRepo;

        public DiviziaController(IDiviziaRepository diviziaRepo, IFirmaRepository firmaRepo)
        {
            this.diviziaRepo = diviziaRepo;
            this.firmaRepo = firmaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var divizie = await diviziaRepo.GetAllAsync();

            var divizieDto = divizie.Select(d => d.ToDiviziaDto());

            return Ok(divizieDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var divizia = await diviziaRepo.GetByIdAsync(id);

            if (divizia == null) {
                return NotFound();
            }

            return Ok(divizia.ToDiviziaDto());
        }

        [HttpPost("{firmaId}")]
        public async Task<IActionResult> Create([FromRoute] int firmaId, [FromBody] CreateDiviziaDto diviziaDto)
        {
            if (!await firmaRepo.FirmaExists(firmaId)) {
                return BadRequest($"Firma s id {firmaId} neexistuje!");
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var diviziaModel = diviziaDto.ToDiviziaFromCreate(firmaId);
            await diviziaRepo.CreateAsync(diviziaModel);

            return CreatedAtAction(nameof(GetById), new { id = diviziaModel.id }, diviziaModel.ToDiviziaDto());
        }

        [HttpPut("{firmaId}/divizie/{diviziaId}")]
        public async Task<IActionResult> Update([FromRoute] int firmaId, [FromRoute] int diviziaId, [FromBody] UpdateDiviziaRequestDto diviziaDto)
        {
            if (!await firmaRepo.FirmaExists(firmaId)) {
                return BadRequest($"Firma s id {firmaId} neexistuje!");
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var diviziaModel = await diviziaRepo.UpdateAsync(firmaId, diviziaId, diviziaDto);

            if (diviziaModel == null) {
                return NotFound();
            }

            return Ok(diviziaModel.ToDiviziaDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var diviziaModel = await diviziaRepo.DeleteAsync(id);

            if (diviziaModel == null) {
                return NotFound();
            }

            return NoContent();
        }
    }
}