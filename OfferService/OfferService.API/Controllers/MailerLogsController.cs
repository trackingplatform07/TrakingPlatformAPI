using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailerLogsController : ControllerBase
    {
        private readonly IMailerLog _service;

        public MailerLogsController(IMailerLog service)
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
                return NotFound(new { message = "Mailer log not found." });

            return Ok(result);
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] MailerLogDTO log)
        {
            if (log == null)
                return BadRequest("Invalid mailer request.");

            var result = await _service.SendAsync(log);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Mailer log not found." });

            return Ok(new { message = "Mailer log deleted successfully." });
        }
    }
}
