using EmisionAPI.Interfaces;
using EmisionAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmissionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmissionsController : ControllerBase
    {
        private readonly IEmission _emissionRepository;

        public EmissionsController(IEmission emissionRepository)
        {
            _emissionRepository = emissionRepository;
        }

        // 1. GET: api/emissions
        [HttpGet]
        public async Task<ActionResult> GetAllEmissions()
        {
            var emissions = await _emissionRepository.GetAllEmissions();
            return Ok(new { Success = true, Data = emissions });
        }

        // 2. GET: api/emissions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmissionById(int id)
        {
            var emission = await _emissionRepository.GetEmissionById(id);
            if (emission == null)
            {
                return NotFound(new { Success = false, Message = "Emission not found" });
            }
            return Ok(new { Success = true, Data = emission });
        }

        // 3. GET: api/emissions/company/{companyId}
        [HttpGet("company/{companyId}")]
        public async Task<ActionResult> GetEmissionsByCompanyId(int companyId)
        {
            var emissions = await _emissionRepository.GetEmissionsByCompanyId(companyId);
            if (emissions == null || emissions.Count == 0)
            {
                return NotFound(new { Success = false, Message = "No emissions found for the specified company" });
            }
            return Ok(new { Success = true, Data = emissions });
        }

        // 4. POST: api/emissions
        [HttpPost]
        public async Task<ActionResult> AddEmission(Emission emission)
        {
            if (emission == null)
            {
                return BadRequest(new { Success = false, Message = "Emission data is required" });
            }

            var createdEmission = await _emissionRepository.AddEmission(emission);
            return CreatedAtAction(nameof(GetEmissionById), new { id = createdEmission.Id }, new { Success = true, Data = createdEmission });
        }

        // 5. PUT: api/emissions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmission(int id, Emission emission)
        {
            if (id != emission.Id)
            {
                return BadRequest(new { Success = false, Message = "Emission ID in the URL and the body must match" });
            }

            var emissionExists = await _emissionRepository.EmissionExists(id);
            if (!emissionExists)
            {
                return NotFound(new { Success = false, Message = "Emission not found" });
            }

            await _emissionRepository.UpdateEmission(emission);
            return Ok(new { Success = true, Message = "Emission updated successfully", Data = emission });
        }

        // 6. DELETE: api/emissions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmission(int id)
        {
            var emissionExists = await _emissionRepository.EmissionExists(id);
            if (!emissionExists)
            {
                return NotFound(new { Success = false, Message = "Emission not found" });
            }

            var result = await _emissionRepository.DeleteEmission(id);
            if (!result)
            {
                return StatusCode(500, new { Success = false, Message = "Error deleting the emission" });
            }

            return Ok(new { Success = true, Message = "Emission deleted successfully" });
        }
    }
}
