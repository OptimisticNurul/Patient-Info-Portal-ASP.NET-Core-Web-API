using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientsController(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return Ok(await _patientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            await _patientRepository.Add(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.ID }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.ID)
            {
                return BadRequest();
            }
            await _patientRepository.Update(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            await _patientRepository.Delete(id);
            return NoContent();
        }
    }
}
