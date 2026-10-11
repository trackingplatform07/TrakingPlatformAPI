using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateInvoicesController : ControllerBase
    {
        private readonly IAffiliateInvoice _service;

        public AffiliateInvoicesController(IAffiliateInvoice service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAffiliateInvoiceRequestDTO request)
        {
            if (request == null || request.AffiliateId <= 0 || request.TotalAmount < 0)
                return BadRequest("AffiliateId and a valid TotalAmount are required.");

            return Ok(await _service.CreateAsync(request));
        }

        [HttpPatch("{id}/mark-paid")]
        public async Task<IActionResult> MarkPaid(long id, [FromQuery] string? modifiedBy)
        {
            try
            {
                return Ok(await _service.MarkPaidAsync(id, modifiedBy));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/note")]
        public async Task<IActionResult> UpdateNote(long id, [FromBody] UpdateAffiliateInvoiceNoteRequestDTO request)
        {
            try
            {
                return Ok(await _service.UpdateNoteAsync(id, request));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
