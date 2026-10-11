using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLogsController : ControllerBase
    {
        private readonly IAccessLog _service;

        public AccessLogsController(IAccessLog service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Query(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] long? employeeId,
            [FromQuery] int pageSize = 100)
        {
            var query = new AccessLogQueryDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                EmployeeId = employeeId,
                PageSize = pageSize
            };

            return Ok(await _service.QueryAsync(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccessLogDTO log)
        {
            if (log == null || string.IsNullOrWhiteSpace(log.Type))
                return BadRequest("Type is required.");

            return Ok(await _service.CreateAsync(log));
        }
    }
}
