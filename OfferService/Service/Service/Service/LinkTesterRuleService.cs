using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class LinkTesterRuleService : ILinkTesterRule
    {
        private readonly OfferCategoryDbContext _context;

        public LinkTesterRuleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static LinkTesterRuleDTO ToDto(LinkTesterRule x) => new LinkTesterRuleDTO
        {
            Id = x.Id,

            RuleName = x.RuleName,

            AdvertiserId = x.AdvertiserId,
            OfferId = x.OfferId,
            CustomUrl = x.CustomUrl,

            Status = x.Status,
            Schedule = x.Schedule,
            Browser = x.Browser,
            TestCountry = x.TestCountry,

            HealthyCheckThreshold = x.HealthyCheckThreshold,
            AllowedRedirection = x.AllowedRedirection,
            ResaleDetection = x.ResaleDetection,

            AdvertiserAppId = x.AdvertiserAppId,
            AppIdMatch = x.AppIdMatch,
            AllowedHttpStatuses = x.AllowedHttpStatuses,
            StopOffer = x.StopOffer,
            MinimumOneRedirect = x.MinimumOneRedirect,

            LastCheck = x.LastCheck,
            Health = x.Health,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<LinkTesterRuleDTO>> GetAllAsync()
        {
            return await _context.LinkTesterRules
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<LinkTesterRuleDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.LinkTesterRules
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<LinkTesterRuleDTO> CreateAsync(LinkTesterRuleDTO dto)
        {
            var entity = new LinkTesterRule
            {
                RuleName = dto.RuleName,

                AdvertiserId = dto.AdvertiserId,
                OfferId = dto.OfferId,
                CustomUrl = dto.CustomUrl,

                Status = dto.Status,
                Schedule = dto.Schedule,
                Browser = dto.Browser,
                TestCountry = dto.TestCountry,

                HealthyCheckThreshold = dto.HealthyCheckThreshold,
                AllowedRedirection = dto.AllowedRedirection,
                ResaleDetection = dto.ResaleDetection,

                AdvertiserAppId = dto.AdvertiserAppId,
                AppIdMatch = dto.AppIdMatch,
                AllowedHttpStatuses = dto.AllowedHttpStatuses,
                StopOffer = dto.StopOffer,
                MinimumOneRedirect = dto.MinimumOneRedirect,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.LinkTesterRules.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, LinkTesterRuleDTO dto)
        {
            var entity = await _context.LinkTesterRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.RuleName = dto.RuleName;

            entity.AdvertiserId = dto.AdvertiserId;
            entity.OfferId = dto.OfferId;
            entity.CustomUrl = dto.CustomUrl;

            entity.Status = dto.Status;
            entity.Schedule = dto.Schedule;
            entity.Browser = dto.Browser;
            entity.TestCountry = dto.TestCountry;

            entity.HealthyCheckThreshold = dto.HealthyCheckThreshold;
            entity.AllowedRedirection = dto.AllowedRedirection;
            entity.ResaleDetection = dto.ResaleDetection;

            entity.AdvertiserAppId = dto.AdvertiserAppId;
            entity.AppIdMatch = dto.AppIdMatch;
            entity.AllowedHttpStatuses = dto.AllowedHttpStatuses;
            entity.StopOffer = dto.StopOffer;
            entity.MinimumOneRedirect = dto.MinimumOneRedirect;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.LinkTesterRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
