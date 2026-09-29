using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class RetargetingTagService : IRetargetingTag
    {
        private readonly OfferCategoryDbContext _context;

        public RetargetingTagService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static RetargetingTagDTO ToDto(RetargetingTag x) => new RetargetingTagDTO
        {
            Id = x.Id,
            AffiliateId = x.AffiliateId,

            TagName = x.TagName,
            Url = x.Url,
            Code = x.Code,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<RetargetingTagDTO>> GetAllAsync()
        {
            return await _context.RetargetingTags
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<RetargetingTagDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.RetargetingTags
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<RetargetingTagDTO> CreateAsync(
            RetargetingTagDTO dto)
        {
            var entity = new RetargetingTag
            {
                AffiliateId = dto.AffiliateId,

                TagName = dto.TagName,
                Url = dto.Url,
                Code = dto.Code,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.RetargetingTags.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            RetargetingTagDTO dto)
        {
            var entity = await _context.RetargetingTags
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.AffiliateId = dto.AffiliateId;

            entity.TagName = dto.TagName;
            entity.Url = dto.Url;
            entity.Code = dto.Code;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.RetargetingTags
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.RetargetingTags.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
