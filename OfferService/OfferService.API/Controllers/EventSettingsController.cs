using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSettingsController : ControllerBase
    {
        private readonly IEventSetting _service;

        public EventSettingsController(IEventSetting service)
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
                        message = "Event settings not found for this offer."
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
                    message = "Event settings not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] EventSettingDTO eventSetting)
        {
            if (eventSetting == null)
                return BadRequest("Invalid event settings.");

            eventSetting.CreatedOn = DateTime.UtcNow;
            eventSetting.IsActive ??= true;

            var result = await _service.CreateAsync(eventSetting);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] EventSettingDTO eventSetting)
        {
            if (eventSetting == null)
                return BadRequest("Invalid event settings.");

            eventSetting.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                eventSetting);

            if (!updated)
                return NotFound(new
                {
                    message = "Event settings not found."
                });

            return Ok(new
            {
                message = "Event settings updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Event settings not found."
                });

            return Ok(new
            {
                message = "Event settings deleted successfully."
            });
        }
    }
}
