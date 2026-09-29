using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class FallbackIntegrationService : IFallbackIntegration
    {
        private readonly OfferCategoryDbContext _context;

        public FallbackIntegrationService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static FallbackIntegrationDTO ToDto(FallbackIntegration x) => new FallbackIntegrationDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            PostbackType = x.PostbackType,

            EnableFallback = x.EnableFallback,
            FallbackUrl = x.FallbackUrl,
            FallbackOfferId = x.FallbackOfferId,
            FallbackOfferReportsAffiliates = x.FallbackOfferReportsAffiliates,

            HtmlJsCode = x.HtmlJsCode,
            UrlToReplace = x.UrlToReplace,
            Erid = x.Erid,
            ForceAffiliateLandingRedirect = x.ForceAffiliateLandingRedirect,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<FallbackIntegrationDTO>> GetAllAsync()
        {
            return await _context.FallbackIntegrations
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<FallbackIntegrationDTO?> GetByOfferIdAsync(long offerId)
        {
            var entity = await _context.FallbackIntegrations
                .FirstOrDefaultAsync(x => x.OfferId == offerId);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<FallbackIntegrationDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.FallbackIntegrations
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<FallbackIntegrationDTO> CreateAsync(
            FallbackIntegrationDTO dto)
        {
            var entity = new FallbackIntegration
            {
                OfferId = dto.OfferId,

                PostbackType = dto.PostbackType,

                EnableFallback = dto.EnableFallback,
                FallbackUrl = dto.FallbackUrl,
                FallbackOfferId = dto.FallbackOfferId,
                FallbackOfferReportsAffiliates = dto.FallbackOfferReportsAffiliates,

                HtmlJsCode = dto.HtmlJsCode,
                UrlToReplace = dto.UrlToReplace,
                Erid = dto.Erid,
                ForceAffiliateLandingRedirect = dto.ForceAffiliateLandingRedirect,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.FallbackIntegrations.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            FallbackIntegrationDTO dto)
        {
            var entity = await _context.FallbackIntegrations
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.PostbackType = dto.PostbackType;

            entity.EnableFallback = dto.EnableFallback;
            entity.FallbackUrl = dto.FallbackUrl;
            entity.FallbackOfferId = dto.FallbackOfferId;
            entity.FallbackOfferReportsAffiliates = dto.FallbackOfferReportsAffiliates;

            entity.HtmlJsCode = dto.HtmlJsCode;
            entity.UrlToReplace = dto.UrlToReplace;
            entity.Erid = dto.Erid;
            entity.ForceAffiliateLandingRedirect = dto.ForceAffiliateLandingRedirect;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.FallbackIntegrations
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.FallbackIntegrations.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
