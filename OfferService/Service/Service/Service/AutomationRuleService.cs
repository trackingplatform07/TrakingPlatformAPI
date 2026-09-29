using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class AutomationRuleService : IAutomationRule
    {
        private readonly OfferCategoryDbContext _context;

        public AutomationRuleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static AutomationRuleDTO ToDto(AutomationRule x) => new AutomationRuleDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            RuleName = x.RuleName,
            Status = x.Status,
            BlockLevel = x.BlockLevel,

            Advertiser = x.Advertiser,
            OffersJson = x.OffersJson,

            Conversion = x.Conversion,
            Clicks = x.Clicks,
            Impressions = x.Impressions,
            Field = x.Field,
            CompareType = x.CompareType,
            MinValue = x.MinValue,
            MaxValue = x.MaxValue,

            ReportStatus = x.ReportStatus,
            DataLookBack = x.DataLookBack,
            Schedule = x.Schedule,
            DateStart = x.DateStart,
            DateEnd = x.DateEnd,

            WhitelistOffers = x.WhitelistOffers,
            ResumeAfter = x.ResumeAfter,
            AlertEnabled = x.AlertEnabled,

            LastCheck = x.LastCheck,
            Alarm = x.Alarm,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<AutomationRuleDTO>> GetAllAsync()
        {
            return await _context.AutomationRules
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<AutomationRuleDTO>> GetByOfferIdAsync(long offerId)
        {
            return await _context.AutomationRules
                .Where(x => x.OfferId == offerId)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<AutomationRuleDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.AutomationRules
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<AutomationRuleDTO> CreateAsync(
            AutomationRuleDTO dto)
        {
            var entity = new AutomationRule
            {
                OfferId = dto.OfferId,

                RuleName = dto.RuleName,
                Status = dto.Status,
                BlockLevel = dto.BlockLevel,

                Advertiser = dto.Advertiser,
                OffersJson = dto.OffersJson,

                Conversion = dto.Conversion,
                Clicks = dto.Clicks,
                Impressions = dto.Impressions,
                Field = dto.Field,
                CompareType = dto.CompareType,
                MinValue = dto.MinValue,
                MaxValue = dto.MaxValue,

                ReportStatus = dto.ReportStatus,
                DataLookBack = dto.DataLookBack,
                Schedule = dto.Schedule,
                DateStart = dto.DateStart,
                DateEnd = dto.DateEnd,

                WhitelistOffers = dto.WhitelistOffers,
                ResumeAfter = dto.ResumeAfter,
                AlertEnabled = dto.AlertEnabled,

                LastCheck = dto.LastCheck ?? DateTime.UtcNow,
                Alarm = dto.Alarm,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.AutomationRules.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastCheck = entity.LastCheck;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            AutomationRuleDTO dto)
        {
            var entity = await _context.AutomationRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.RuleName = dto.RuleName;
            entity.Status = dto.Status;
            entity.BlockLevel = dto.BlockLevel;

            entity.Advertiser = dto.Advertiser;
            entity.OffersJson = dto.OffersJson;

            entity.Conversion = dto.Conversion;
            entity.Clicks = dto.Clicks;
            entity.Impressions = dto.Impressions;
            entity.Field = dto.Field;
            entity.CompareType = dto.CompareType;
            entity.MinValue = dto.MinValue;
            entity.MaxValue = dto.MaxValue;

            entity.ReportStatus = dto.ReportStatus;
            entity.DataLookBack = dto.DataLookBack;
            entity.Schedule = dto.Schedule;
            entity.DateStart = dto.DateStart;
            entity.DateEnd = dto.DateEnd;

            entity.WhitelistOffers = dto.WhitelistOffers;
            entity.ResumeAfter = dto.ResumeAfter;
            entity.AlertEnabled = dto.AlertEnabled;

            entity.LastCheck = DateTime.UtcNow;
            entity.Alarm = dto.Alarm;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.AutomationRules
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.AutomationRules.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
