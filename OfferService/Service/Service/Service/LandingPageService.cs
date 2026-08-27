using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class LandingPageService : ILandingPage
    {
        private readonly OfferCategoryDbContext _context;

        public LandingPageService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LandingPageDTO>> GetAllAsync()
        {
            return await _context.LandingPage
                .Select(x => new LandingPageDTO
                {
                    Id = x.Id,
                    OfferId = x.OfferId,
                    Name = x.Name,
                    Type = x.Type,
                    Url = x.Url,
                    Targeting = x.Targeting,
                    AffiliateMode = x.AffiliateMode,
                    AffiliateId = x.AffiliateId,
                    Weight = x.Weight,
                    Visibility = x.Visibility,
                    Description = x.Description,
                    Fallback = x.Fallback,
                    FallbackName = x.FallbackName,
                    FallbackUrl = x.FallbackUrl,
                    FallbackWeight = x.FallbackWeight,
                    Enabled = x.Enabled,
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<LandingPageDTO?> GetByIdAsync(long id)
        {
            return await _context.LandingPage
                .Where(x => x.Id == id)
                .Select(x => new LandingPageDTO
                {
                    Id = x.Id,
                    OfferId = x.OfferId,
                    Name = x.Name,
                    Type = x.Type,
                    Url = x.Url,
                    Targeting = x.Targeting,
                    AffiliateMode = x.AffiliateMode,
                    AffiliateId = x.AffiliateId,
                    Weight = x.Weight,
                    Visibility = x.Visibility,
                    Description = x.Description,
                    Fallback = x.Fallback,
                    FallbackName = x.FallbackName,
                    FallbackUrl = x.FallbackUrl,
                    FallbackWeight = x.FallbackWeight,
                    Enabled = x.Enabled,
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<LandingPageDTO> CreateAsync(LandingPageDTO dto)
        {
            var entity = new LandingPage
            {
                OfferId = dto.OfferId,
                Name = dto.Name,
                Type = dto.Type,
                Url = dto.Url,
                Targeting = dto.Targeting,
                AffiliateMode = dto.AffiliateMode,
                AffiliateId = dto.AffiliateId,
                Weight = dto.Weight,
                Visibility = dto.Visibility,
                Description = dto.Description,
                Fallback = dto.Fallback,
                FallbackName = dto.FallbackName,
                FallbackUrl = dto.FallbackUrl,
                FallbackWeight = dto.FallbackWeight,
                Enabled = dto.Enabled,
                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,
                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,
                IsActive = dto.IsActive
            };

            _context.LandingPage.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, LandingPageDTO dto)
        {
            var entity = await _context.LandingPage
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;
            entity.Name = dto.Name;
            entity.Type = dto.Type;
            entity.Url = dto.Url;
            entity.Targeting = dto.Targeting;
            entity.AffiliateMode = dto.AffiliateMode;
            entity.AffiliateId = dto.AffiliateId;
            entity.Weight = dto.Weight;
            entity.Visibility = dto.Visibility;
            entity.Description = dto.Description;
            entity.Fallback = dto.Fallback;
            entity.FallbackName = dto.FallbackName;
            entity.FallbackUrl = dto.FallbackUrl;
            entity.FallbackWeight = dto.FallbackWeight;
            entity.Enabled = dto.Enabled;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;
            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.LandingPage
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.LandingPage.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}