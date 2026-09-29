using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class TopOfferMailerLogService : ITopOfferMailerLog
    {
        private readonly OfferCategoryDbContext _context;

        public TopOfferMailerLogService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static TopOfferMailerLogDTO ToDto(TopOfferMailerLog x) => new TopOfferMailerLogDTO
        {
            Id = x.Id,

            AffiliateId = x.AffiliateId,
            BulkApproved = x.BulkApproved,

            Emails = x.Emails,
            Subject = x.Subject,

            Source = x.Source,
            TopOfferIds = x.TopOfferIds,
            OfferIds = x.OfferIds,

            SentOn = x.SentOn,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<TopOfferMailerLogDTO>> GetAllAsync()
        {
            return await _context.TopOfferMailerLogs
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.SentOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<TopOfferMailerLogDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.TopOfferMailerLogs
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<TopOfferMailerLogDTO> CreateAsync(TopOfferMailerLogDTO dto)
        {
            var entity = new TopOfferMailerLog
            {
                AffiliateId = dto.AffiliateId,
                BulkApproved = dto.BulkApproved,

                Emails = dto.Emails,
                Subject = dto.Subject,

                Source = dto.Source,
                TopOfferIds = dto.TopOfferIds,
                OfferIds = dto.OfferIds,

                SentOn = dto.SentOn ?? DateTime.UtcNow,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.TopOfferMailerLogs.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.SentOn = entity.SentOn;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.TopOfferMailerLogs
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
