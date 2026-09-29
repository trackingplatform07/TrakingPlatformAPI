using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingSubscriptionsController : ControllerBase
    {
        private readonly IBillingSubscription _service;

        public BillingSubscriptionsController(IBillingSubscription service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpPut("change-plan")]
        public async Task<IActionResult> ChangePlan([FromBody] ChangePlanRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.PlanName))
                return BadRequest("A plan name is required.");

            return Ok(await _service.ChangePlanAsync(request));
        }

        [HttpPut("addons")]
        public async Task<IActionResult> UpdateAddons([FromBody] UpdateAddonsRequestDTO request)
        {
            if (request == null)
                return BadRequest("Invalid addons request.");

            return Ok(await _service.UpdateAddonsAsync(request));
        }

        [HttpPut("bank-details")]
        public async Task<IActionResult> UpdateBankDetails([FromBody] BillingSubscriptionDTO request)
        {
            if (request == null)
                return BadRequest("Invalid bank details request.");

            return Ok(await _service.UpdateBankDetailsAsync(request));
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel([FromBody] string? cancelledBy)
        {
            return Ok(await _service.CancelAsync(cancelledBy));
        }
    }
}
