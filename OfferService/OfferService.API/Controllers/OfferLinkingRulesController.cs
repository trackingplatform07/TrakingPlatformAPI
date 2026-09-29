using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferLinkingRulesController : ControllerBase
    {
        private readonly IOfferLinkingRule _service;

        public OfferLinkingRulesController(IOfferLinkingRule service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Offer linking rule not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] OfferLinkingRuleDTO rule)
        {
            if (rule == null)
                return BadRequest("Invalid offer linking rule.");

            rule.CreatedOn = DateTime.UtcNow;
            rule.IsActive ??= true;

            var result = await _service.CreateAsync(rule);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] OfferLinkingRuleDTO rule)
        {
            if (rule == null)
                return BadRequest("Invalid offer linking rule.");

            rule.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                rule);

            if (!updated)
                return NotFound(new
                {
                    message = "Offer linking rule not found."
                });

            return Ok(new
            {
                message = "Offer linking rule updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Offer linking rule not found."
                });

            return Ok(new
            {
                message = "Offer linking rule deleted successfully."
            });
        }
    }
}
