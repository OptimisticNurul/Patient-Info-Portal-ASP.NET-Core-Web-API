using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly IRepository<NCD> _ncdRepository;

        public NCDController(IRepository<NCD> ncdRepository)
        {
            _ncdRepository = ncdRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCD>>> GetNCDs()
        {
            return Ok(await _ncdRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NCD>> GetNCD(int id)
        {
            var ncd = await _ncdRepository.GetById(id);
            if (ncd == null)
            {
                return NotFound();
            }
            return Ok(ncd);
        }

        [HttpPost]
        public async Task<ActionResult<NCD>> CreateNCD(NCD ncd)
        {
            await _ncdRepository.Add(ncd);
            return CreatedAtAction(nameof(GetNCD), new { id = ncd.ID }, ncd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNCD(int id, NCD ncd)
        {
            if (id != ncd.ID)
            {
                return BadRequest();
            }
            await _ncdRepository.Update(ncd);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCD(int id)
        {
            var ncd = await _ncdRepository.GetById(id);
            if (ncd == null)
            {
                return NotFound();
            }
            await _ncdRepository.Delete(id);
            return NoContent();
        }
    }
}
