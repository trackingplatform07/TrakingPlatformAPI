using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopOffersController : ControllerBase
    {
        private readonly ITopOffer _service;

        public TopOffersController(ITopOffer service)
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
                    message = "Top offer not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] TopOfferDTO topOffer)
        {
            if (topOffer == null)
                return BadRequest("Invalid top offer.");

            topOffer.CreatedOn = DateTime.UtcNow;
            topOffer.IsActive ??= true;

            var result = await _service.CreateAsync(topOffer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] TopOfferDTO topOffer)
        {
            if (topOffer == null)
                return BadRequest("Invalid top offer.");

            topOffer.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                topOffer);

            if (!updated)
                return NotFound(new
                {
                    message = "Top offer not found."
                });

            return Ok(new
            {
                message = "Top offer updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Top offer not found."
                });

            return Ok(new
            {
                message = "Top offer deleted successfully."
            });
        }
    }
}
