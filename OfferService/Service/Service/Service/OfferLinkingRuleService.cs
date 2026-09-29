using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class OfferLinkingRuleService : IOfferLinkingRule
    {
        private readonly OfferCategoryDbContext _context;

        public OfferLinkingRuleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static OfferLinkingRuleDTO ToDto(OfferLinkingRule x) => new OfferLinkingRuleDTO
        {
            Id = x.Id,

            RuleName = x.RuleName,

            AdvertiserId = x.AdvertiserId,

            OffersMode = x.OffersMode,
            OfferIds = x.OfferIds,

            AffiliatesMode = x.AffiliatesMode,
            AffiliateIds = x.AffiliateIds,

            PayoutCurrency = x.PayoutCurrency,
            PayoutModel = x.PayoutModel,

            MinPayout = x.MinPayout,
            MaxPayout = x.MaxPayout,

            Country = x.Country,
            Status = x.Status,

            LastChecked = x.LastChecked,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<OfferLinkingRuleDTO>> GetAllAsync()
        {
            return await _context.OfferLinkingRules
                .Where(x => x.IsActive == true)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<OfferLinkingRuleDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.OfferLinkingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<OfferLinkingRuleDTO> CreateAsync(OfferLinkingRuleDTO dto)
        {
            var entity = new OfferLinkingRule
            {
                RuleName = dto.RuleName,

                AdvertiserId = dto.AdvertiserId,

                OffersMode = dto.OffersMode,
                OfferIds = dto.OfferIds,

                AffiliatesMode = dto.AffiliatesMode,
                AffiliateIds = dto.AffiliateIds,

                PayoutCurrency = dto.PayoutCurrency,
                PayoutModel = dto.PayoutModel,

                MinPayout = dto.MinPayout,
                MaxPayout = dto.MaxPayout,

                Country = dto.Country,
                Status = dto.Status ?? "Active",

                LastChecked = dto.LastChecked ?? DateTime.UtcNow,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.OfferLinkingRules.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.Status = entity.Status;
            dto.LastChecked = entity.LastChecked;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, OfferLinkingRuleDTO dto)
        {
            var entity = await _context.OfferLinkingRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.RuleName = dto.RuleName;

            entity.AdvertiserId = dto.AdvertiserId;

            entity.OffersMode = dto.OffersMode;
            entity.OfferIds = dto.OfferIds;

            entity.AffiliatesMode = dto.AffiliatesMode;
            entity.AffiliateIds = dto.AffiliateIds;

            entity.PayoutCurrency = dto.PayoutCurrency;
            entity.PayoutModel = dto.PayoutModel;

            entity.MinPayout = dto.MinPayout;
            entity.MaxPayout = dto.MaxPayout;

            entity.Country = dto.Country;
            entity.Status = dto.Status ?? entity.Status;

            entity.LastChecked = DateTime.UtcNow;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.OfferLinkingRules
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
