using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeLogsController : ControllerBase
    {
        private readonly IChangeLog _service;

        public ChangeLogsController(IChangeLog service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Query(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] long? offerId,
            [FromQuery] long? advertiserId,
            [FromQuery] long? affiliateId,
            [FromQuery] int pageSize = 100)
        {
            var query = new ChangeLogQueryDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                OfferId = offerId,
                AdvertiserId = advertiserId,
                AffiliateId = affiliateId,
                PageSize = pageSize
            };

            return Ok(await _service.QueryAsync(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChangeLogDTO log)
        {
            if (log == null || string.IsNullOrWhiteSpace(log.ChangeType) || string.IsNullOrWhiteSpace(log.ActionType))
                return BadRequest("ChangeType and ActionType are required.");

            var result = await _service.CreateAsync(log);

            return Ok(result);
        }
    }
}
