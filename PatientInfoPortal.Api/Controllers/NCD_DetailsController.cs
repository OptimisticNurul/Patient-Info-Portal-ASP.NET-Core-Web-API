using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCD_DetailsController : ControllerBase
    {
        private readonly IRepository<NCD_Details> _ncdDetailsRepository;

        public NCD_DetailsController(IRepository<NCD_Details> ncdDetailsRepository)
        {
            _ncdDetailsRepository = ncdDetailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCD_Details>>> GetNCDDetails()
        {
            return Ok(await _ncdDetailsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NCD_Details>> GetNCDDetail(int id)
        {
            var ncdDetail = await _ncdDetailsRepository.GetById(id);
            if (ncdDetail == null)
            {
                return NotFound();
            }
            return Ok(ncdDetail);
        }

        [HttpPost]
        public async Task<ActionResult<NCD_Details>> CreateNCDDetail(NCD_Details ncdDetail)
        {
            await _ncdDetailsRepository.Add(ncdDetail);
            return CreatedAtAction(nameof(GetNCDDetail), new { id = ncdDetail.ID }, ncdDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNCDDetail(int id, NCD_Details ncdDetail)
        {
            if (id != ncdDetail.ID)
            {
                return BadRequest();
            }
            await _ncdDetailsRepository.Update(ncdDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCDDetail(int id)
        {
            var ncdDetail = await _ncdDetailsRepository.GetById(id);
            if (ncdDetail == null)
            {
                return NotFound();
            }
            await _ncdDetailsRepository.Delete(id);
            return NoContent();
        }
    }
}
