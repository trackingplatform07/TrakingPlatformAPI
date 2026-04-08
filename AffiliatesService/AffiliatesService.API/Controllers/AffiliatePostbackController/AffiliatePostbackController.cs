using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliatePostbackController : ControllerBase
    {
        private readonly IAffiliatePostbackService _service;

        public AffiliatePostbackController(IAffiliatePostbackService service)
        {
            _service = service;
        }

        // ✅ Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllPostbacks();
            return Ok(data);
        }

        // ✅ Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetPostbackById(id);

            if (data == null)
                return NotFound(new { message = "Postback not found" });

            return Ok(data);
        }

        // ✅ Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAffiliatePostbackDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreatePostback(dto);

            return Ok(new
            {
                message = "Postback created successfully",
                data = result
            });
        }

        // ✅ Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAffiliatePostbackDto dto)
        {
            var result = await _service.UpdatePostback(id, dto);

            if (result == null)
                return NotFound(new { message = "Postback not found" });

            return Ok(new
            {
                message = "Postback updated successfully",
                data = result
            });
        }

        // ✅ Update Status
        [HttpPatch("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdatePostbackStatusDto dto)
        {
            var result = await _service.UpdatePostbackStatus(dto);

            if (result == null)
                return NotFound(new { message = "Postback not found" });

            return Ok(new
            {
                message = "Status updated successfully",
                data = result
            });
        }

        // ✅ Delete (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeletePostback(id);

            if (!isDeleted)
                return NotFound(new { message = "Postback not found" });

            return Ok(new
            {
                message = "Postback deleted successfully"
            });
        }
    }
}