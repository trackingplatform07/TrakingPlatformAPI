using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AffiliatesService.API.Controllers.AffiliatesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliatesController : ControllerBase
    {
        private readonly IAffiliateService _service;

        public AffiliatesController(IAffiliateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAffiliates());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetAffiliateById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AffiliateDto dto)
        {
            var result = await _service.CreateAffiliate(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAffiliateDto dto)
        {
            var result = await _service.UpdateAffiliate(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateAffiliateStausDto dto)
        {
            var result = await _service.UpdateAffiliateStaus(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAffiliate(id);
            if (!result) return NotFound();
            return Ok("Deleted Successfully");
        }
    }
}
