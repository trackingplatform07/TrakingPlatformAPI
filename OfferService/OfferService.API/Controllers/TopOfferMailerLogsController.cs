using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopOfferMailerLogsController : ControllerBase
    {
        private readonly ITopOfferMailerLog _service;

        public TopOfferMailerLogsController(ITopOfferMailerLog service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Top offer mailer log not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] TopOfferMailerLogDTO mailerLog)
        {
            if (mailerLog == null)
                return BadRequest("Invalid mailer log.");

            mailerLog.CreatedOn = DateTime.UtcNow;
            mailerLog.IsActive ??= true;

            var result = await _service.CreateAsync(mailerLog);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Top offer mailer log not found."
                });

            return Ok(new
            {
                message = "Top offer mailer log deleted successfully."
            });
        }
    }
}
