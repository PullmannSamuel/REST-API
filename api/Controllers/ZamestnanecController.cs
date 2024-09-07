using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Zamestnanec;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/zamestnanec")]
    [ApiController]
    public class ZamestnanecController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IZamestnanecRepository zamestRepo;

        public ZamestnanecController(ApplicationDBContext context, IZamestnanecRepository zamestRepo)
        {
            this.context = context;
            this.zamestRepo = zamestRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zamestnanci = await zamestRepo.GetAllAsync();

            var zamestnanciDto = zamestnanci.Select(z => z.ToZamestnanecDto());

            return Ok(zamestnanciDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var zamestnanec = await zamestRepo.GetByIdAsync(id);

            if (zamestnanec == null) {
                return NotFound();
            }

            return Ok(zamestnanec.ToZamestnanecDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateZamestnanecRequest zamestDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var zamestModel = zamestDto.ToZamestnanecFromCreateDto();
            await zamestRepo.CreateAsync(zamestModel);

            return CreatedAtAction(nameof(GetById), new { id = zamestModel.id }, zamestModel.ToZamestnanecDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateZamestnanecRequestDto updateDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var zamestModel = await zamestRepo.UpdateAsync(id, updateDto);

            if (zamestModel == null) {
                return NotFound();
            }

            return Ok(zamestModel.ToZamestnanecDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var zamestModel = await zamestRepo.DeleteAsync(id);

            if (zamestModel == null) {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}