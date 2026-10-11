using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeArticlesController : ControllerBase
    {
        private readonly IKnowledgeArticle _service;

        public KnowledgeArticlesController(IKnowledgeArticle service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? search, [FromQuery] string? category)
        {
            return Ok(await _service.SearchAsync(search, category));
        }
    }
}
