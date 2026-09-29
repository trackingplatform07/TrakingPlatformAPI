using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayoutRulesController : ControllerBase
    {
        private readonly IPayoutRule _service;

        public PayoutRulesController(IPayoutRule service)
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
                    message = "Payout rule not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PayoutRuleDTO payoutRule)
        {
            if (payoutRule == null)
                return BadRequest("Invalid payout rule.");

            payoutRule.CreatedOn = DateTime.UtcNow;
            payoutRule.IsActive ??= true;

            var result = await _service.CreateAsync(payoutRule);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] PayoutRuleDTO payoutRule)
        {
            if (payoutRule == null)
                return BadRequest("Invalid payout rule.");

            payoutRule.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                payoutRule);

            if (!updated)
                return NotFound(new
                {
                    message = "Payout rule not found."
                });

            return Ok(new
            {
                message = "Payout rule updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Payout rule not found."
                });

            return Ok(new
            {
                message = "Payout rule deleted successfully."
            });
        }
    }
}
