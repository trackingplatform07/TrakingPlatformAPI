using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkSettingsController : ControllerBase
    {
        private readonly INetworkSetting _service;

        public NetworkSettingsController(INetworkSetting service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NetworkSettingDTO settings)
        {
            if (settings == null || string.IsNullOrWhiteSpace(settings.NetworkName))
                return BadRequest("Network name is required.");

            var result = await _service.UpdateAsync(settings);

            return Ok(result);
        }
    }
}
