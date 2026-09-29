using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class SuppressionListService : ISuppressionList
    {
        private readonly OfferCategoryDbContext _context;

        public SuppressionListService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static SuppressionListDTO ToDto(SuppressionList x) => new SuppressionListDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            Name = x.Name,

            SourceType = x.SourceType,
            Url = x.Url,
            UnsubscribeUrl = x.UnsubscribeUrl,

            SubjectLines = x.SubjectLines,
            FromLines = x.FromLines,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<SuppressionListDTO>> GetAllAsync()
        {
            return await _context.SuppressionLists
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<SuppressionListDTO>> GetByOfferIdAsync(long offerId)
        {
            return await _context.SuppressionLists
                .Where(x => x.OfferId == offerId)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<SuppressionListDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.SuppressionLists
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<SuppressionListDTO> CreateAsync(
            SuppressionListDTO dto)
        {
            var entity = new SuppressionList
            {
                OfferId = dto.OfferId,

                Name = dto.Name,

                SourceType = dto.SourceType,
                Url = dto.Url,
                UnsubscribeUrl = dto.UnsubscribeUrl,

                SubjectLines = dto.SubjectLines,
                FromLines = dto.FromLines,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.SuppressionLists.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            SuppressionListDTO dto)
        {
            var entity = await _context.SuppressionLists
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.Name = dto.Name;

            entity.SourceType = dto.SourceType;
            entity.Url = dto.Url;
            entity.UnsubscribeUrl = dto.UnsubscribeUrl;

            entity.SubjectLines = dto.SubjectLines;
            entity.FromLines = dto.FromLines;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.SuppressionLists
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.SuppressionLists.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
