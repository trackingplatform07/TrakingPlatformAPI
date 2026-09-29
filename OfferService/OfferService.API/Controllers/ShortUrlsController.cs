using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlsController : ControllerBase
    {
        private readonly IShortUrl _service;

        public ShortUrlsController(IShortUrl service)
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
                return NotFound(new { message = "Short URL not found." });

            return Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _service.GetByCodeAsync(code);

            if (result == null)
                return NotFound(new { message = "Short URL not found." });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShortUrlDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Url))
                return BadRequest("A URL is required.");

            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
                return BadRequest("Please enter a valid absolute URL.");

            var result = await _service.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] string status)
        {
            var updated = await _service.UpdateStatusAsync(id, status);

            if (!updated)
                return NotFound(new { message = "Short URL not found." });

            return Ok(new { message = "Short URL status updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Short URL not found." });

            return Ok(new { message = "Short URL deleted successfully." });
        }
    }
}
