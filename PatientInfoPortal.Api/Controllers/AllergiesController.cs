using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IRepository<Allergies> _allergiesRepository;

        public AllergiesController(IRepository<Allergies> allergiesRepository)
        {
            _allergiesRepository = allergiesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergies>>> GetAllergies()
        {
            return Ok(await _allergiesRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Allergies>> GetAllergy(int id)
        {
            var allergy = await _allergiesRepository.GetById(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return Ok(allergy);
        }

        [HttpPost]
        public async Task<ActionResult<Allergies>> CreateAllergy(Allergies allergy)
        {
            await _allergiesRepository.Add(allergy);
            return CreatedAtAction(nameof(GetAllergy), new { id = allergy.ID }, allergy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergy(int id, Allergies allergy)
        {
            if (id != allergy.ID)
            {
                return BadRequest();
            }
            await _allergiesRepository.Update(allergy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergy(int id)
        {
            var allergy = await _allergiesRepository.GetById(id);
            if (allergy == null)
            {
                return NotFound();
            }
            await _allergiesRepository.Delete(id);
            return NoContent();
        }
    }
}
