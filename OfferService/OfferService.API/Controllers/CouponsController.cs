using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICoupon _service;

        public CouponsController(ICoupon service)
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
                    message = "Coupon not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CouponDTO coupon)
        {
            if (coupon == null)
                return BadRequest("Invalid coupon.");

            coupon.CreatedOn = DateTime.UtcNow;
            coupon.IsActive ??= true;

            var result = await _service.CreateAsync(coupon);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] CouponDTO coupon)
        {
            if (coupon == null)
                return BadRequest("Invalid coupon.");

            coupon.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                coupon);

            if (!updated)
                return NotFound(new
                {
                    message = "Coupon not found."
                });

            return Ok(new
            {
                message = "Coupon updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Coupon not found."
                });

            return Ok(new
            {
                message = "Coupon deleted successfully."
            });
        }
    }
}
