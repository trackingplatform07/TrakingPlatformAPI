using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetingRulesController : ControllerBase
    {
        private readonly ITargetingRule _service;

        public TargetingRulesController(ITargetingRule service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Targeting rule not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] TargetingRuleDTO targetingRule)
        {
            if (targetingRule == null)
                return BadRequest("Invalid targeting rule.");

            targetingRule.CreatedOn = DateTime.UtcNow;
            targetingRule.IsActive ??= true;

            var result = await _service.CreateAsync(targetingRule);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] TargetingRuleDTO targetingRule)
        {
            if (targetingRule == null)
                return BadRequest("Invalid targeting rule.");

            targetingRule.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                targetingRule);

            if (!updated)
                return NotFound(new
                {
                    message = "Targeting rule not found."
                });

            return Ok(new
            {
                message = "Targeting rule updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Targeting rule not found."
                });

            return Ok(new
            {
                message = "Targeting rule deleted successfully."
            });
        }
    }
}