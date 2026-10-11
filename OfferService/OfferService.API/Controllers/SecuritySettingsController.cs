using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritySettingsController : ControllerBase
    {
        private readonly ISecuritySetting _service;

        public SecuritySettingsController(ISecuritySetting service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NewPassword))
                return BadRequest("A new password is required.");

            var changed = await _service.ChangePasswordAsync(request);

            if (!changed)
                return BadRequest(new { message = "The old password you entered is incorrect." });

            return Ok(new { message = "Password changed successfully." });
        }

        [HttpPut("two-factor")]
        public async Task<IActionResult> SetTwoFactor([FromBody] bool enabled)
        {
            return Ok(await _service.SetTwoFactorAsync(enabled, null));
        }
    }
}
