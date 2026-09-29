using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomationRulesController : ControllerBase
    {
        private readonly IAutomationRule _service;

        public AutomationRulesController(IAutomationRule service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? offerId)
        {
            var result = offerId.HasValue
                ? await _service.GetByOfferIdAsync(offerId.Value)
                : await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Automation rule not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] AutomationRuleDTO automationRule)
        {
            if (automationRule == null)
                return BadRequest("Invalid automation rule.");

            automationRule.CreatedOn = DateTime.UtcNow;
            automationRule.IsActive ??= true;

            var result = await _service.CreateAsync(automationRule);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] AutomationRuleDTO automationRule)
        {
            if (automationRule == null)
                return BadRequest("Invalid automation rule.");

            automationRule.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                automationRule);

            if (!updated)
                return NotFound(new
                {
                    message = "Automation rule not found."
                });

            return Ok(new
            {
                message = "Automation rule updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Automation rule not found."
                });

            return Ok(new
            {
                message = "Automation rule deleted successfully."
            });
        }
    }
}
