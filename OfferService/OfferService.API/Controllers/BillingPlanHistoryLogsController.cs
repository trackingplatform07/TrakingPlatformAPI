using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingPlanHistoryLogsController : ControllerBase
    {
        private readonly IBillingPlanHistoryLog _service;

        public BillingPlanHistoryLogsController(IBillingPlanHistoryLog service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
