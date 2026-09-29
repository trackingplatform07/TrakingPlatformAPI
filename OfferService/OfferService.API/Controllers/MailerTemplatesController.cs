using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailerTemplatesController : ControllerBase
    {
        private readonly IMailerTemplate _service;

        public MailerTemplatesController(IMailerTemplate service)
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
                return NotFound(new { message = "Mailer template not found." });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MailerTemplateDTO template)
        {
            if (template == null || string.IsNullOrWhiteSpace(template.Name))
                return BadRequest("Invalid mailer template.");

            template.CreatedOn = DateTime.UtcNow;
            template.IsActive ??= true;

            var result = await _service.CreateAsync(template);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] MailerTemplateDTO template)
        {
            if (template == null)
                return BadRequest("Invalid mailer template.");

            template.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(id, template);

            if (!updated)
                return NotFound(new { message = "Mailer template not found." });

            return Ok(new { message = "Mailer template updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Mailer template not found." });

            return Ok(new { message = "Mailer template deleted successfully." });
        }
    }
}
