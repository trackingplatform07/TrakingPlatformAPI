using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeedsController : ControllerBase
    {
        private readonly IProductFeed _service;

        public ProductFeedsController(IProductFeed service)
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
                    message = "Product feed not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProductFeedDTO productFeed)
        {
            if (productFeed == null)
                return BadRequest("Invalid product feed.");

            productFeed.CreatedOn = DateTime.UtcNow;
            productFeed.IsActive ??= true;

            var result = await _service.CreateAsync(productFeed);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] ProductFeedDTO productFeed)
        {
            if (productFeed == null)
                return BadRequest("Invalid product feed.");

            productFeed.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                productFeed);

            if (!updated)
                return NotFound(new
                {
                    message = "Product feed not found."
                });

            return Ok(new
            {
                message = "Product feed updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Product feed not found."
                });

            return Ok(new
            {
                message = "Product feed deleted successfully."
            });
        }
    }
}
