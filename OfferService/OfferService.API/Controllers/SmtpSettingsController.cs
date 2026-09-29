using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmtpSettingsController : ControllerBase
    {
        private readonly ISmtpSetting _service;

        public SmtpSettingsController(ISmtpSetting service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await _service.GetActiveAsync();

            if (result == null)
                return NotFound(new { message = "No SMTP settings configured." });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new { message = "SMTP setting not found." });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SmtpSettingDTO setting)
        {
            if (setting == null || string.IsNullOrWhiteSpace(setting.Host))
                return BadRequest("Invalid SMTP setting.");

            setting.CreatedOn = DateTime.UtcNow;
            setting.IsActive ??= true;

            var result = await _service.CreateAsync(setting);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] SmtpSettingDTO setting)
        {
            if (setting == null)
                return BadRequest("Invalid SMTP setting.");

            setting.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(id, setting);

            if (!updated)
                return NotFound(new { message = "SMTP setting not found." });

            return Ok(new { message = "SMTP setting updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "SMTP setting not found." });

            return Ok(new { message = "SMTP setting deleted successfully." });
        }

        [HttpPost("test-connection")]
        public async Task<IActionResult> TestConnection([FromBody] SmtpSettingDTO setting)
        {
            if (setting == null)
                return BadRequest("Invalid SMTP setting.");

            return Ok(await _service.TestConnectionAsync(setting));
        }
    }
}
