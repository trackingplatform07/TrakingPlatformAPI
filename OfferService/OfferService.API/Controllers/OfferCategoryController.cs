using Interface.DTOs;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OfferService.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class OfferCategoriesController : ControllerBase
    {
        private readonly IOfferCategory _service;

        public OfferCategoriesController(IOfferCategory service)
        {
            _service = service;
        }

        // GET: api/OfferCategories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllOfferCategories();

            return Ok(result);
        }

        // GET: api/OfferCategories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetOfferCategoryById(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Offer Category not found."
                });
            }

            return Ok(result);
        }

        // POST: api/OfferCategories
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] OfferCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new
                {
                    message = "Invalid request."
                });
            }

            var result = await _service.CreateOfferCategory(dto);

            return Ok(result);
        }

        // PUT: api/OfferCategories/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] OfferCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new
                {
                    message = "Invalid request."
                });
            }

            var result = await _service.UpdateOfferCategory(id, dto);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Offer Category not found."
                });
            }

            return Ok(result);
        }

        // DELETE: api/OfferCategories/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteOfferCategory(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Offer Category not found."
                });
            }

            return Ok(new
            {
                message = "Offer Category deleted successfully."
            });
        }
    }


}
