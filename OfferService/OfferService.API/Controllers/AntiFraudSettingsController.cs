using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntiFraudSettingsController : ControllerBase
    {
        private readonly IAntiFraudSetting _service;

        public AntiFraudSettingsController(IAntiFraudSetting service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? offerId)
        {
            if (offerId.HasValue)
            {
                var result = await _service.GetByOfferIdAsync(offerId.Value);

                if (result == null)
                    return NotFound(new
                    {
                        message = "Anti fraud settings not found for this offer."
                    });

                return Ok(result);
            }

            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new
                {
                    message = "Anti fraud settings not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] AntiFraudSettingDTO antiFraudSetting)
        {
            if (antiFraudSetting == null)
                return BadRequest("Invalid anti fraud settings.");

            antiFraudSetting.CreatedOn = DateTime.UtcNow;
            antiFraudSetting.IsActive ??= true;

            var result = await _service.CreateAsync(antiFraudSetting);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] AntiFraudSettingDTO antiFraudSetting)
        {
            if (antiFraudSetting == null)
                return BadRequest("Invalid anti fraud settings.");

            antiFraudSetting.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                antiFraudSetting);

            if (!updated)
                return NotFound(new
                {
                    message = "Anti fraud settings not found."
                });

            return Ok(new
            {
                message = "Anti fraud settings updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Anti fraud settings not found."
                });

            return Ok(new
            {
                message = "Anti fraud settings deleted successfully."
            });
        }
    }
}
