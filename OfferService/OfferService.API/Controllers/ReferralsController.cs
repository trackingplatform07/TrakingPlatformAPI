using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralsController : ControllerBase
    {
        private readonly IReferral _service;

        public ReferralsController(IReferral service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetSummaryAsync());
        }

        [HttpPut("visibility")]
        public async Task<IActionResult> SetVisibility([FromBody] SetAffiliateDashboardVisibilityRequestDTO request)
        {
            return Ok(await _service.SetAffiliateDashboardVisibilityAsync(request));
        }
    }
}
