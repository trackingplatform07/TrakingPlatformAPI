using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class CappingRuleService : ICappingRule
    {
        private readonly OfferCategoryDbContext _context;

        public CappingRuleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static CappingRuleDTO ToDto(CappingRule x) => new CappingRuleDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            RuleName = x.RuleName,
            RuleType = x.RuleType,

            CappingType = x.CappingType,
            Period = x.Period,
            CappingValue = x.CappingValue,

            OverCappingAction = x.OverCappingAction,
            CappingTimezoneEnabled = x.CappingTimezoneEnabled,

            Events = x.Events,

            AffiliateVisibility = x.AffiliateVisibility,
            EnableRule = x.EnableRule,

            NotificationEmail = x.NotificationEmail,
            EarlierNotificationThreshold = x.EarlierNotificationThreshold,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<CappingRuleDTO>> GetAllAsync()
        {
            return await _context.CappingRules
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<CappingRuleDTO>> GetByOfferIdAsync(long offerId)
        {
            return await _context.CappingRules
                .Where(x => x.OfferId == offerId)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<CappingRuleDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.CappingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<CappingRuleDTO> CreateAsync(
            CappingRuleDTO dto)
        {
            var entity = new CappingRule
            {
                OfferId = dto.OfferId,

                RuleName = dto.RuleName,
                RuleType = dto.RuleType,

                CappingType = dto.CappingType,
                Period = dto.Period,
                CappingValue = dto.CappingValue,

                OverCappingAction = dto.OverCappingAction,
                CappingTimezoneEnabled = dto.CappingTimezoneEnabled,

                Events = dto.Events,

                AffiliateVisibility = dto.AffiliateVisibility,
                EnableRule = dto.EnableRule,

                NotificationEmail = dto.NotificationEmail,
                EarlierNotificationThreshold = dto.EarlierNotificationThreshold,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.CappingRules.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            CappingRuleDTO dto)
        {
            var entity = await _context.CappingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.RuleName = dto.RuleName;
            entity.RuleType = dto.RuleType;

            entity.CappingType = dto.CappingType;
            entity.Period = dto.Period;
            entity.CappingValue = dto.CappingValue;

            entity.OverCappingAction = dto.OverCappingAction;
            entity.CappingTimezoneEnabled = dto.CappingTimezoneEnabled;

            entity.Events = dto.Events;

            entity.AffiliateVisibility = dto.AffiliateVisibility;
            entity.EnableRule = dto.EnableRule;

            entity.NotificationEmail = dto.NotificationEmail;
            entity.EarlierNotificationThreshold = dto.EarlierNotificationThreshold;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.CappingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.CappingRules.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
