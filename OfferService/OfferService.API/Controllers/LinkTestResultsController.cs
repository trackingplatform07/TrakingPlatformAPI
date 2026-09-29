using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkTestResultsController : ControllerBase
    {
        private readonly ILinkTestResult _service;

        public LinkTestResultsController(ILinkTestResult service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? ruleId)
        {
            return Ok(await _service.GetAllAsync(ruleId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new { message = "Link test result not found." });

            return Ok(result);
        }

        [HttpPost("run")]
        public async Task<IActionResult> Run([FromBody] LinkTestRunRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Url))
                return BadRequest("A URL is required to run a link test.");

            var result = await _service.RunTestAsync(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Link test result not found." });

            return Ok(new { message = "Link test result deleted successfully." });
        }
    }
}
