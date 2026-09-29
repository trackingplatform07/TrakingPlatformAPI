using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomationLogsController : ControllerBase
    {
        private readonly IAutomationLog _service;

        public AutomationLogsController(IAutomationLog service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? automationRuleId)
        {
            return Ok(await _service.GetAllAsync(automationRuleId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new { message = "Automation log not found." });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AutomationLogDTO log)
        {
            if (log == null)
                return BadRequest("Invalid automation log.");

            log.CreatedOn = DateTime.UtcNow;
            log.IsActive ??= true;

            var result = await _service.CreateAsync(log);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Automation log not found." });

            return Ok(new { message = "Automation log deleted successfully." });
        }
    }
}
