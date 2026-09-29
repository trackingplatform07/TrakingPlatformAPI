using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FallbackIntegrationsController : ControllerBase
    {
        private readonly IFallbackIntegration _service;

        public FallbackIntegrationsController(IFallbackIntegration service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? offerId)
        {
            if (offerId.HasValue)
            {
                var result = await _service.GetByOfferIdAsync(offerId.Value);

                if (result == null)
                    return NotFound(new
                    {
                        message = "Fallback / integration settings not found for this offer."
                    });

                return Ok(result);
            }

            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Fallback / integration settings not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] FallbackIntegrationDTO fallbackIntegration)
        {
            if (fallbackIntegration == null)
                return BadRequest("Invalid fallback / integration settings.");

            fallbackIntegration.CreatedOn = DateTime.UtcNow;
            fallbackIntegration.IsActive ??= true;

            var result = await _service.CreateAsync(fallbackIntegration);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] FallbackIntegrationDTO fallbackIntegration)
        {
            if (fallbackIntegration == null)
                return BadRequest("Invalid fallback / integration settings.");

            fallbackIntegration.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                fallbackIntegration);

            if (!updated)
                return NotFound(new
                {
                    message = "Fallback / integration settings not found."
                });

            return Ok(new
            {
                message = "Fallback / integration settings updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Fallback / integration settings not found."
                });

            return Ok(new
            {
                message = "Fallback / integration settings deleted successfully."
            });
        }
    }
}
