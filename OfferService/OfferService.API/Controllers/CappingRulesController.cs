using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CappingRulesController : ControllerBase
    {
        private readonly ICappingRule _service;

        public CappingRulesController(ICappingRule service)
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
                    message = "Capping rule not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CappingRuleDTO cappingRule)
        {
            if (cappingRule == null)
                return BadRequest("Invalid capping rule.");

            cappingRule.CreatedOn = DateTime.UtcNow;
            cappingRule.IsActive ??= true;

            var result = await _service.CreateAsync(cappingRule);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] CappingRuleDTO cappingRule)
        {
            if (cappingRule == null)
                return BadRequest("Invalid capping rule.");

            cappingRule.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                cappingRule);

            if (!updated)
                return NotFound(new
                {
                    message = "Capping rule not found."
                });

            return Ok(new
            {
                message = "Capping rule updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Capping rule not found."
                });

            return Ok(new
            {
                message = "Capping rule deleted successfully."
            });
        }
    }
}
