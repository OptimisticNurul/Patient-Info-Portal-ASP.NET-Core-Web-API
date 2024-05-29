using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Allergies_DetailsController : ControllerBase
    {
        private readonly IRepository<Allergies_Details> _allergiesDetailsRepository;

        public Allergies_DetailsController(IRepository<Allergies_Details> allergiesDetailsRepository)
        {
            _allergiesDetailsRepository = allergiesDetailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergies_Details>>> GetAllergiesDetails()
        {
            return Ok(await _allergiesDetailsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Allergies_Details>> GetAllergiesDetail(int id)
        {
            var allergiesDetail = await _allergiesDetailsRepository.GetById(id);
            if (allergiesDetail == null)
            {
                return NotFound();
            }
            return Ok(allergiesDetail);
        }

        [HttpPost]
        public async Task<ActionResult<Allergies_Details>> CreateAllergiesDetail(Allergies_Details allergiesDetail)
        {
            await _allergiesDetailsRepository.Add(allergiesDetail);
            return CreatedAtAction(nameof(GetAllergiesDetail), new { id = allergiesDetail.ID }, allergiesDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergiesDetail(int id, Allergies_Details allergiesDetail)
        {
            if (id != allergiesDetail.ID)
            {
                return BadRequest();
            }
            await _allergiesDetailsRepository.Update(allergiesDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergiesDetail(int id)
        {
            var allergiesDetail = await _allergiesDetailsRepository.GetById(id);
            if (allergiesDetail == null)
            {
                return NotFound();
            }
            await _allergiesDetailsRepository.Delete(id);
            return NoContent();
        }
    }
}
