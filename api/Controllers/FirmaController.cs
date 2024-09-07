using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Firma;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/firma")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IFirmaRepository firmaRepo;

        public FirmaController(ApplicationDBContext context, IFirmaRepository firmaRepo)
        {
            this.context = context;
            this.firmaRepo = firmaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var firmy = await firmaRepo.GetAllAsync();

            var firmyDto = firmy.Select(f => f.ToFirmaDto());

            return Ok(firmyDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var firma = await firmaRepo.GetByIdAsync(id);

            if (firma == null) {
                return NotFound();
            }

            return Ok(firma.ToFirmaDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFirmaRequestDto firmaDto) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var firmaModel = firmaDto.ToFirmaFromCreateDto();
            await firmaRepo.CreateAsync(firmaModel);
            
            return CreatedAtAction(nameof(GetById), new { id = firmaModel.id }, firmaModel.ToFirmaDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFirmaRequestDto updateDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var firmaModel = await firmaRepo.UpdateAsync(id, updateDto);

            if (firmaModel == null) {
                return NotFound();
            }

            return Ok(firmaModel.ToFirmaDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var firmaModel = await firmaRepo.DeleteAsync(id);

            if (firmaModel == null) {
                return NotFound();
            }
            
            return NoContent();
        }
    }   
}