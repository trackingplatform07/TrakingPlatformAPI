using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class CreativeService : ICreative
    {
        private readonly OfferCategoryDbContext _context;

        public CreativeService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreativeDTO>> GetAllAsync()
        {
            return await _context.Creative
                .Select(x => new CreativeDTO
                {
                    CreativeID = x.CreativeID,
                    OfferID = x.OfferID,
                    Title = x.Title,
                    Dimensions = x.Dimensions,
                    Size = x.Size,
                    Preview = x.Preview,
                    AffiliateTrackingURL = x.AffiliateTrackingURL,
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<CreativeDTO?> GetByIdAsync(long id)
        {
            return await _context.Creative
                .Where(x => x.CreativeID == id)
                .Select(x => new CreativeDTO
                {
                    CreativeID = x.CreativeID,
                    OfferID = x.OfferID,
                    Title = x.Title,
                    Dimensions = x.Dimensions,
                    Size = x.Size,
                    Preview = x.Preview,
                    AffiliateTrackingURL = x.AffiliateTrackingURL,
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CreativeDTO> CreateAsync(CreativeDTO dto)
        {
            var creative = new Creative
            {
                OfferID = dto.OfferID,
                Title = dto.Title,
                Dimensions = dto.Dimensions,
                Size = dto.Size,
                Preview = dto.Preview,
                AffiliateTrackingURL = dto.AffiliateTrackingURL,
                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,
                IsActive = dto.IsActive ?? true
            };

            _context.Creative.Add(creative);

            await _context.SaveChangesAsync();

            dto.CreativeID = creative.CreativeID;
            dto.CreatedOn = creative.CreatedOn;
            dto.IsActive = creative.IsActive;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, CreativeDTO dto)
        {
            var creative = await _context.Creative
                .FirstOrDefaultAsync(x => x.CreativeID == id);

            if (creative == null)
                return false;

            creative.OfferID = dto.OfferID;
            creative.Title = dto.Title;
            creative.Dimensions = dto.Dimensions;
            creative.Size = dto.Size;
            creative.Preview = dto.Preview;
            creative.AffiliateTrackingURL = dto.AffiliateTrackingURL;

            creative.ModifiedOn = DateTime.UtcNow;
            creative.ModifiedBy = dto.ModifiedBy;

            if (dto.IsActive.HasValue)
                creative.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var creative = await _context.Creative
                .FirstOrDefaultAsync(x => x.CreativeID == id);

            if (creative == null)
                return false;

            _context.Creative.Remove(creative);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}