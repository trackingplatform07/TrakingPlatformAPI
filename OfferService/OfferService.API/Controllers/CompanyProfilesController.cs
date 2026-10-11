using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfilesController : ControllerBase
    {
        private readonly ICompanyProfile _service;

        public CompanyProfilesController(ICompanyProfile service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CompanyProfileDTO request)
        {
            if (request == null)
                return BadRequest("Invalid company profile request.");

            return Ok(await _service.UpdateAsync(request));
        }

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeAccountEmailRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NewEmail))
                return BadRequest("A new email is required.");

            return Ok(await _service.ChangeEmailAsync(request));
        }

        [HttpPost("regenerate-secret-key")]
        public async Task<IActionResult> RegenerateSecretKey([FromBody] string? regeneratedBy)
        {
            return Ok(await _service.RegenerateSecretKeyAsync(regeneratedBy));
        }
    }
}
