using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPagesController : ControllerBase
    {
        private readonly ILandingPage _service;

        public LandingPagesController(ILandingPage service)
        {
            _service = service;
        }

        // GET: api/LandingPages
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        // GET: api/LandingPages/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Landing Page not found"
                });

            return Ok(result);
        }

        // POST: api/LandingPages
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LandingPageDTO dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result
            );
        }

        // PUT: api/LandingPages/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] LandingPageDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound(new
                {
                    message = "Landing Page not found"
                });

            return Ok(new
            {
                message = "Landing Page updated successfully"
            });
        }

        // DELETE: api/LandingPages/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound(new
                {
                    message = "Landing Page not found"
                });

            return Ok(new
            {
                message = "Landing Page deleted successfully"
            });
        }
    }
}