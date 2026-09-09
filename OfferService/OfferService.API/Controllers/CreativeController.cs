using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreativeController : ControllerBase
    {
        private readonly ICreative _creativeService;

        public CreativeController(ICreative creativeService)
        {
            _creativeService = creativeService;
        }

        // GET: api/Creative
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _creativeService.GetAllAsync();

            return Ok(result);
        }

        // GET: api/Creative/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _creativeService.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Creative not found."
                });

            return Ok(result);
        }

        // POST: api/Creative
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreativeDTO dto)
        {
            var result = await _creativeService.CreateAsync(dto);

            return Ok(result);
        }

        // PUT: api/Creative/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] CreativeDTO dto)
        {
            var result = await _creativeService.UpdateAsync(id, dto);

            if (!result)
                return NotFound(new
                {
                    message = "Creative not found."
                });

            return Ok(new
            {
                message = "Creative updated successfully."
            });
        }

        // DELETE: api/Creative/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _creativeService.DeleteAsync(id);

            if (!result)
                return NotFound(new
                {
                    message = "Creative not found."
                });

            return Ok(new
            {
                message = "Creative deleted successfully."
            });
        }
    }
}