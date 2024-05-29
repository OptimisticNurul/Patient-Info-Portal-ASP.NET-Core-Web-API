using Microsoft.AspNetCore.Mvc;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpilepsyController : ControllerBase
    {
        private readonly IRepository<Epilepsy> _epilepsyRepository;

        public EpilepsyController(IRepository<Epilepsy> epilepsyRepository)
        {
            _epilepsyRepository = epilepsyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Epilepsy>>> GetEpilepsies()
        {
            return Ok(await _epilepsyRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Epilepsy>> GetEpilepsy(int id)
        {
            var epilepsy = await _epilepsyRepository.GetById(id);
            if (epilepsy == null)
            {
                return NotFound();
            }
            return Ok(epilepsy);
        }

        [HttpPost]
        public async Task<ActionResult<Epilepsy>> CreateEpilepsy(Epilepsy epilepsy)
        {
            await _epilepsyRepository.Add(epilepsy);
            return CreatedAtAction(nameof(GetEpilepsy), new { id = epilepsy.ID }, epilepsy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEpilepsy(int id, Epilepsy epilepsy)
        {
            if (id != epilepsy.ID)
            {
                return BadRequest();
            }
            await _epilepsyRepository.Update(epilepsy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpilepsy(int id)
        {
            var epilepsy = await _epilepsyRepository.GetById(id);
            if (epilepsy == null)
            {
                return NotFound();
            }
            await _epilepsyRepository.Delete(id);
            return NoContent();
        }
    }
}
