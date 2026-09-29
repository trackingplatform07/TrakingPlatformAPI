using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class PayoutRuleService : IPayoutRule
    {
        private readonly OfferCategoryDbContext _context;

        public PayoutRuleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static PayoutRuleDTO ToDto(PayoutRule x) => new PayoutRuleDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            RuleName = x.RuleName,

            RevenueModel = x.RevenueModel,
            RevenueValue = x.RevenueValue,

            PayoutModel = x.PayoutModel,
            PayoutValue = x.PayoutValue,

            Currency = x.Currency,

            ConditionsJson = x.ConditionsJson,

            AffiliateVisibility = x.AffiliateVisibility,
            RulePriority = x.RulePriority,
            EnableRule = x.EnableRule,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<PayoutRuleDTO>> GetAllAsync()
        {
            return await _context.PayoutRules
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<PayoutRuleDTO>> GetByOfferIdAsync(long offerId)
        {
            return await _context.PayoutRules
                .Where(x => x.OfferId == offerId)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<PayoutRuleDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.PayoutRules
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<PayoutRuleDTO> CreateAsync(
            PayoutRuleDTO dto)
        {
            var entity = new PayoutRule
            {
                OfferId = dto.OfferId,

                RuleName = dto.RuleName,

                RevenueModel = dto.RevenueModel,
                RevenueValue = dto.RevenueValue,

                PayoutModel = dto.PayoutModel,
                PayoutValue = dto.PayoutValue,

                Currency = dto.Currency,

                ConditionsJson = dto.ConditionsJson,

                AffiliateVisibility = dto.AffiliateVisibility,
                RulePriority = dto.RulePriority,
                EnableRule = dto.EnableRule,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.PayoutRules.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            PayoutRuleDTO dto)
        {
            var entity = await _context.PayoutRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.RuleName = dto.RuleName;

            entity.RevenueModel = dto.RevenueModel;
            entity.RevenueValue = dto.RevenueValue;

            entity.PayoutModel = dto.PayoutModel;
            entity.PayoutValue = dto.PayoutValue;

            entity.Currency = dto.Currency;

            entity.ConditionsJson = dto.ConditionsJson;

            entity.AffiliateVisibility = dto.AffiliateVisibility;
            entity.RulePriority = dto.RulePriority;
            entity.EnableRule = dto.EnableRule;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.PayoutRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.PayoutRules.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
