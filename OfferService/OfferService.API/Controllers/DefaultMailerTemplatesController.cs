using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultMailerTemplatesController : ControllerBase
    {
        private readonly IDefaultMailerTemplate _service;

        public DefaultMailerTemplatesController(IDefaultMailerTemplate service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{templateKey}")]
        public async Task<IActionResult> GetByKey(string templateKey)
        {
            var result = await _service.GetByKeyAsync(templateKey);

            if (result == null)
                return NotFound(new { message = "Default mailer template not found." });

            return Ok(result);
        }

        [HttpPut("{templateKey}")]
        public async Task<IActionResult> Update(string templateKey, [FromBody] DefaultMailerTemplateDTO template)
        {
            if (template == null)
                return BadRequest("Invalid template.");

            template.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(templateKey, template);

            if (!updated)
                return NotFound(new { message = "Default mailer template not found." });

            return Ok(new { message = "Template updated successfully." });
        }

        [HttpPost("{templateKey}/reset")]
        public async Task<IActionResult> Reset(string templateKey)
        {
            var result = await _service.ResetAsync(templateKey);

            if (result == null)
                return NotFound(new { message = "Default mailer template not found." });

            return Ok(result);
        }

        [HttpPost("reset-all")]
        public async Task<IActionResult> ResetAll()
        {
            return Ok(await _service.ResetAllAsync());
        }
    }
}
