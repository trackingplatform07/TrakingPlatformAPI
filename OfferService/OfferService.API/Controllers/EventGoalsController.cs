using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGoalsController : ControllerBase
    {
        private readonly IEventGoal _service;

        public EventGoalsController(IEventGoal service)
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
                    message = "Event not found."
                });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] EventGoalDTO eventGoal)
        {
            if (eventGoal == null)
                return BadRequest("Invalid event.");

            eventGoal.CreatedOn = DateTime.UtcNow;
            eventGoal.IsActive ??= true;

            var result = await _service.CreateAsync(eventGoal);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] EventGoalDTO eventGoal)
        {
            if (eventGoal == null)
                return BadRequest("Invalid event.");

            eventGoal.ModifiedOn = DateTime.UtcNow;

            var updated = await _service.UpdateAsync(
                id,
                eventGoal);

            if (!updated)
                return NotFound(new
                {
                    message = "Event not found."
                });

            return Ok(new
            {
                message = "Event updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    message = "Event not found."
                });

            return Ok(new
            {
                message = "Event deleted successfully."
            });
        }
    }
}
