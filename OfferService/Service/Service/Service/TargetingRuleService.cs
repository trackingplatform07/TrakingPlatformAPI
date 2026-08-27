using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class TargetingRuleService : ITargetingRule
    {
        private readonly OfferCategoryDbContext _context;

        public TargetingRuleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TargetingRuleDTO>> GetAllAsync()
        {
            return await _context.TargetingRules
                .Select(x => new TargetingRuleDTO
                {
                    Id = x.Id,
                    OfferId = x.OfferId,
                    RuleName = x.RuleName,

                    Country = x.Country,
                    OS = x.OS,
                    Browser = x.Browser,
                    DeviceType = x.DeviceType,
                    ISP = x.ISP,

                    ActionOnClicks = x.ActionOnClicks,
                    ActionOnConversions = x.ActionOnConversions,
                    ActionOnImpressions = x.ActionOnImpressions,

                    AffiliateVisibility = x.AffiliateVisibility,
                    Enabled = x.Enabled,

                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,

                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,

                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<TargetingRuleDTO?> GetByIdAsync(long id)
        {
            return await _context.TargetingRules
                .Where(x => x.Id == id)
                .Select(x => new TargetingRuleDTO
                {
                    Id = x.Id,
                    OfferId = x.OfferId,
                    RuleName = x.RuleName,

                    Country = x.Country,
                    OS = x.OS,
                    Browser = x.Browser,
                    DeviceType = x.DeviceType,
                    ISP = x.ISP,

                    ActionOnClicks = x.ActionOnClicks,
                    ActionOnConversions = x.ActionOnConversions,
                    ActionOnImpressions = x.ActionOnImpressions,

                    AffiliateVisibility = x.AffiliateVisibility,
                    Enabled = x.Enabled,

                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,

                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,

                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TargetingRuleDTO> CreateAsync(
            TargetingRuleDTO dto)
        {
            var entity = new TargetingRules
            {
                OfferId = dto.OfferId,
                RuleName = dto.RuleName,

                Country = dto.Country,
                OS = dto.OS,
                Browser = dto.Browser,
                DeviceType = dto.DeviceType,
                ISP = dto.ISP,

                ActionOnClicks = dto.ActionOnClicks,
                ActionOnConversions = dto.ActionOnConversions,
                ActionOnImpressions = dto.ActionOnImpressions,

                AffiliateVisibility = dto.AffiliateVisibility,
                Enabled = dto.Enabled,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.TargetingRules.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            TargetingRuleDTO dto)
        {
            var entity = await _context.TargetingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;
            entity.RuleName = dto.RuleName;

            entity.Country = dto.Country;
            entity.OS = dto.OS;
            entity.Browser = dto.Browser;
            entity.DeviceType = dto.DeviceType;
            entity.ISP = dto.ISP;

            entity.ActionOnClicks = dto.ActionOnClicks;
            entity.ActionOnConversions = dto.ActionOnConversions;
            entity.ActionOnImpressions = dto.ActionOnImpressions;

            entity.AffiliateVisibility = dto.AffiliateVisibility;
            entity.Enabled = dto.Enabled;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.TargetingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.TargetingRules.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}