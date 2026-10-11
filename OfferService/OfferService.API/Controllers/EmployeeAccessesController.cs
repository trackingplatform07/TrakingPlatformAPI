using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAccessesController : ControllerBase
    {
        private readonly IEmployeeAccess _service;

        public EmployeeAccessesController(IEmployeeAccess service)
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
                return NotFound(new { message = "Employee not found." });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeAccessRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("An email is required.");

            var result = await _service.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] string status)
        {
            var updated = await _service.UpdateStatusAsync(id, status);

            if (!updated)
                return NotFound(new { message = "Employee not found." });

            return Ok(new { message = "Employee status updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Employee not found." });

            return Ok(new { message = "Employee removed successfully." });
        }
    }
}
