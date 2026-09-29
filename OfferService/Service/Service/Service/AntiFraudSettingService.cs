using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class AntiFraudSettingService : IAntiFraudSetting
    {
        private readonly OfferCategoryDbContext _context;

        public AntiFraudSettingService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static AntiFraudSettingDTO ToDto(AntiFraudSetting x) => new AntiFraudSettingDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            ClickSpammingDefender = x.ClickSpammingDefender,
            UniqueClickLimit = x.UniqueClickLimit,
            ProxyBotBlock = x.ProxyBotBlock,
            BrowserBlankReferral = x.BrowserBlankReferral,
            DefaultIpSource = x.DefaultIpSource,

            ClickIpv4RangeFilter = x.ClickIpv4RangeFilter,
            ClickIpv4RangeValues = x.ClickIpv4RangeValues,

            HtmlRedirectHttpReferral = x.HtmlRedirectHttpReferral,

            ClickBlockFiltersJson = x.ClickBlockFiltersJson,
            ConversionValidateFiltersJson = x.ConversionValidateFiltersJson,
            CtitRulesJson = x.CtitRulesJson,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<AntiFraudSettingDTO>> GetAllAsync()
        {
            return await _context.AntiFraudSettings
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<AntiFraudSettingDTO?> GetByOfferIdAsync(long offerId)
        {
            var entity = await _context.AntiFraudSettings
                .FirstOrDefaultAsync(x => x.OfferId == offerId);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<AntiFraudSettingDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.AntiFraudSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<AntiFraudSettingDTO> CreateAsync(
            AntiFraudSettingDTO dto)
        {
            var entity = new AntiFraudSetting
            {
                OfferId = dto.OfferId,

                ClickSpammingDefender = dto.ClickSpammingDefender,
                UniqueClickLimit = dto.UniqueClickLimit,
                ProxyBotBlock = dto.ProxyBotBlock,
                BrowserBlankReferral = dto.BrowserBlankReferral,
                DefaultIpSource = dto.DefaultIpSource,

                ClickIpv4RangeFilter = dto.ClickIpv4RangeFilter,
                ClickIpv4RangeValues = dto.ClickIpv4RangeValues,

                HtmlRedirectHttpReferral = dto.HtmlRedirectHttpReferral,

                ClickBlockFiltersJson = dto.ClickBlockFiltersJson,
                ConversionValidateFiltersJson = dto.ConversionValidateFiltersJson,
                CtitRulesJson = dto.CtitRulesJson,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.AntiFraudSettings.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            AntiFraudSettingDTO dto)
        {
            var entity = await _context.AntiFraudSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.ClickSpammingDefender = dto.ClickSpammingDefender;
            entity.UniqueClickLimit = dto.UniqueClickLimit;
            entity.ProxyBotBlock = dto.ProxyBotBlock;
            entity.BrowserBlankReferral = dto.BrowserBlankReferral;
            entity.DefaultIpSource = dto.DefaultIpSource;

            entity.ClickIpv4RangeFilter = dto.ClickIpv4RangeFilter;
            entity.ClickIpv4RangeValues = dto.ClickIpv4RangeValues;

            entity.HtmlRedirectHttpReferral = dto.HtmlRedirectHttpReferral;

            entity.ClickBlockFiltersJson = dto.ClickBlockFiltersJson;
            entity.ConversionValidateFiltersJson = dto.ConversionValidateFiltersJson;
            entity.CtitRulesJson = dto.CtitRulesJson;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.AntiFraudSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.AntiFraudSettings.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
