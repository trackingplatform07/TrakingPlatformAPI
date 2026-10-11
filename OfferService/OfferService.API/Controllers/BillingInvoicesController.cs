using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInvoicesController : ControllerBase
    {
        private readonly IBillingInvoice _service;

        public BillingInvoicesController(IBillingInvoice service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost("{id}/mark-paid")]
        public async Task<IActionResult> MarkPaid(long id)
        {
            var result = await _service.MarkPaidAsync(id);

            if (result == null)
                return NotFound(new { message = "Invoice not found." });

            return Ok(result);
        }
    }
}
