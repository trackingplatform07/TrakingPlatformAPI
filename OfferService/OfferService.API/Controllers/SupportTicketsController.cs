using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketsController : ControllerBase
    {
        private readonly ISupportTicket _service;

        public SupportTicketsController(ISupportTicket service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupportTicketRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Subject) || string.IsNullOrWhiteSpace(request.Type) || string.IsNullOrWhiteSpace(request.Query))
                return BadRequest("Subject, Type and Query are required.");

            return Ok(await _service.CreateAsync(request));
        }
    }
}
