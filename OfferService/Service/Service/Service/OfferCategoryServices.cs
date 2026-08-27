using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;


namespace Service.Service
{
    public class OfferCategoryServices : IOfferCategory
    {
        private readonly OfferCategoryDbContext _context;

        public OfferCategoryServices(OfferCategoryDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<OfferCategoryDto>> GetAllOfferCategories()
        {
            return await _context.OfferCategories
                .Where(x => x.IsActive)
                .Select(x => new OfferCategoryDto
                {
                    Id = x.Id,
                    OfferCategoryName = x.OfferCategoryName,

                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,

                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,

                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<OfferCategoryDto> GetOfferCategoryById(int id)
        {
            return await _context.OfferCategories
                .Where(x => x.Id == id && x.IsActive)
                .Select(x => new OfferCategoryDto
                {
                    Id = x.Id,
                    OfferCategoryName = x.OfferCategoryName,

                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,

                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,

                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        // POST
        public async Task<OfferCategoryDto> CreateOfferCategory(
            OfferCategoryDto dto)
        {
            var offerCategory = new OfferCategory
            {
                OfferCategoryName = dto.OfferCategoryName,

                CreatedOn = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                IsActive = true
            };

            _context.OfferCategories.Add(offerCategory);
            await _context.SaveChangesAsync();

            dto.Id = offerCategory.Id;
            dto.CreatedOn = offerCategory.CreatedOn;
            dto.IsActive = offerCategory.IsActive;

            return dto;
        }

        // PUT
        public async Task<OfferCategoryDto> UpdateOfferCategory(
            int id,
            OfferCategoryDto dto)
        {
            var offerCategory = await _context.OfferCategories
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (offerCategory == null)
            {
                return null;
            }

            offerCategory.OfferCategoryName = dto.OfferCategoryName;

            offerCategory.ModifiedOn = DateTime.UtcNow;
            offerCategory.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return new OfferCategoryDto
            {
                Id = offerCategory.Id,
                OfferCategoryName = offerCategory.OfferCategoryName,

                CreatedOn = offerCategory.CreatedOn,
                CreatedBy = offerCategory.CreatedBy,

                ModifiedOn = offerCategory.ModifiedOn,
                ModifiedBy = offerCategory.ModifiedBy,

                IsActive = offerCategory.IsActive
            };
        }

        // DELETE
        public async Task<bool> DeleteOfferCategory(int id)
        {
            var offerCategory = await _context.OfferCategories
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (offerCategory == null)
            {
                return false;
            }

            // Soft Delete
            offerCategory.IsActive = false;
            offerCategory.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
