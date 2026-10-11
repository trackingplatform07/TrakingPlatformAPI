using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSessionsController : ControllerBase
    {
        private readonly ILoginSession _service;

        public LoginSessionsController(ILoginSession service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost("record")]
        public async Task<IActionResult> Record()
        {
            var userAgent = Request.Headers["User-Agent"].ToString();
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            // Respect a real client-reported IP when behind a dev proxy, otherwise fall back to the socket address.
            var forwardedFor = Request.Headers["X-Forwarded-For"].ToString();
            if (!string.IsNullOrWhiteSpace(forwardedFor)) ip = forwardedFor.Split(',')[0].Trim();

            return Ok(await _service.RecordAsync(userAgent, ip));
        }

        [HttpPost("logout-all")]
        public async Task<IActionResult> LogoutAll()
        {
            await _service.LogoutAllAsync();
            return Ok(new { message = "All devices logged out." });
        }
    }
}
