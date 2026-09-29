using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetargetingTagsController : ControllerBase
    {
        private readonly IRetargetingTag _service;

        public RetargetingTagsController(IRetargetingTag service)
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
                    message = "Retargeting tag not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] RetargetingTagDTO retargetingTag)
        {
            if (retargetingTag == null)
                return BadRequest("Invalid retargeting tag.");

            retargetingTag.CreatedOn = DateTime.UtcNow;
            retargetingTag.IsActive ??= true;

            var result = await _service.CreateAsync(retargetingTag);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] RetargetingTagDTO retargetingTag)
        {
            if (retargetingTag == null)
                return BadRequest("Invalid retargeting tag.");

            retargetingTag.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                retargetingTag);

            if (!updated)
                return NotFound(new
                {
                    message = "Retargeting tag not found."
                });

            return Ok(new
            {
                message = "Retargeting tag updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Retargeting tag not found."
                });

            return Ok(new
            {
                message = "Retargeting tag deleted successfully."
            });
        }
    }
}
