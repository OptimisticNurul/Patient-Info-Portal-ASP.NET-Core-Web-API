using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseInformationController : ControllerBase
    {
        private readonly IRepository<DiseaseInformation> _diseaseInformationRepository;

        public DiseaseInformationController(IRepository<DiseaseInformation> diseaseInformationRepository)
        {
            _diseaseInformationRepository = diseaseInformationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseInformation>>> GetDiseaseInformations()
        {
            return Ok(await _diseaseInformationRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseInformation>> GetDiseaseInformation(int id)
        {
            var diseaseInformation = await _diseaseInformationRepository.GetById(id);
            if (diseaseInformation == null)
            {
                return NotFound();
            }
            return Ok(diseaseInformation);
        }

        [HttpPost]
        public async Task<ActionResult<DiseaseInformation>> CreateDiseaseInformation(DiseaseInformation diseaseInformation)
        {
            await _diseaseInformationRepository.Add(diseaseInformation);
            return CreatedAtAction(nameof(GetDiseaseInformation), new { id = diseaseInformation.ID }, diseaseInformation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiseaseInformation(int id, DiseaseInformation diseaseInformation)
        {
            if (id != diseaseInformation.ID)
            {
                return BadRequest();
            }
            await _diseaseInformationRepository.Update(diseaseInformation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiseaseInformation(int id)
        {
            var diseaseInformation = await _diseaseInformationRepository.GetById(id);
            if (diseaseInformation == null)
            {
                return NotFound();
            }
            await _diseaseInformationRepository.Delete(id);
            return NoContent();
        }
    }
}
