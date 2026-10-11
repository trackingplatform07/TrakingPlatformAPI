using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeysController : ControllerBase
    {
        private readonly IApiKey _service;

        public ApiKeysController(IApiKey service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string? createdBy)
        {
            return Ok(await _service.CreateAsync(createdBy));
        }

        [HttpPut("{id}/whitelist-ip")]
        public async Task<IActionResult> UpdateWhitelistIp(long id, [FromBody] string? whitelistIp)
        {
            var updated = await _service.UpdateWhitelistIpAsync(id, whitelistIp);

            if (!updated)
                return NotFound(new { message = "API key not found." });

            return Ok(new { message = "Whitelist IP updated successfully." });
        }

        [HttpPost("{id}/revoke")]
        public async Task<IActionResult> Revoke(long id)
        {
            var revoked = await _service.RevokeAsync(id);

            if (!revoked)
                return NotFound(new { message = "API key not found." });

            return Ok(new { message = "API key revoked successfully." });
        }
    }
}
