using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateReferralsController : ControllerBase
    {
        private readonly IAffiliateReferral _service;

        public AffiliateReferralsController(IAffiliateReferral service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
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
    }
}
