using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppressionListsController : ControllerBase
    {
        private readonly ISuppressionList _service;

        public SuppressionListsController(ISuppressionList service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? offerId)
        {
            var result = offerId.HasValue
                ? await _service.GetByOfferIdAsync(offerId.Value)
                : await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Suppression list not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] SuppressionListDTO suppressionList)
        {
            if (suppressionList == null)
                return BadRequest("Invalid suppression list.");

            suppressionList.CreatedOn = DateTime.UtcNow;
            suppressionList.IsActive ??= true;

            var result = await _service.CreateAsync(suppressionList);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] SuppressionListDTO suppressionList)
        {
            if (suppressionList == null)
                return BadRequest("Invalid suppression list.");

            suppressionList.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                suppressionList);

            if (!updated)
                return NotFound(new
                {
                    message = "Suppression list not found."
                });

            return Ok(new
            {
                message = "Suppression list updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Suppression list not found."
                });

            return Ok(new
            {
                message = "Suppression list deleted successfully."
            });
        }
    }
}
