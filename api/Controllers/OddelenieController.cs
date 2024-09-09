using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Oddelenie;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/oddelenie")]
    [ApiController]
    public class OddelenieController : ControllerBase
    {
        private readonly IOddelenieRepository oddelenieRepo;
        private readonly IProjektRepository projektRepo;
        public OddelenieController(IOddelenieRepository oddelenieRepo, IProjektRepository projektRepo)
        {
            this.oddelenieRepo = oddelenieRepo;
            this.projektRepo = projektRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var oddelenia = await oddelenieRepo.GetAllAsync();

            var oddeleniaDto = oddelenia.Select(o => o.ToOddelenieDto());

            return Ok(oddelenieRepo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var oddelenie = await oddelenieRepo.GetByIdAsync(id);

            if (oddelenie == null) {
                return NotFound();
            }

            return Ok(oddelenie.ToOddelenieDto());
        }

        [HttpPost("{projektId}")]
        public async Task<IActionResult> Create([FromRoute] int projektId, [FromBody] CreateOddelenieDto oddelenieDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await projektRepo.ProjektExists(projektId)) {
                return BadRequest($"Projekt s id {projektId} neexistuje!");
            }

            var oddelenieModel = oddelenieDto.ToOddelenieFromCreate(projektId);
            await oddelenieRepo.CreateAsync(oddelenieModel);

            return CreatedAtAction(nameof(GetById), new { id = oddelenieModel.id }, oddelenieModel.ToOddelenieDto());
        }

        [HttpPut("{projektId}/oddelenia/{oddelenieId}")]
        public async Task<IActionResult> Update([FromRoute] int projektId, [FromRoute] int oddelenieId, [FromBody] UpdateOddelenieRequestDto oddelenieDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!await projektRepo.ProjektExists(projektId)) {
                return BadRequest($"Projekt s id {projektId} neexistuje!");
            }

            var oddelenieModel = await oddelenieRepo.UpdateAsync(projektId, oddelenieId, oddelenieDto);

            if (oddelenieModel == null) {
                return NotFound();
            }

            return Ok(oddelenieModel.ToOddelenieDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var oddelenie = await oddelenieRepo.DeleteAsync(id);

            if (oddelenie == null) {
                return NotFound();
            } 

            return NoContent();
        }
    }
}