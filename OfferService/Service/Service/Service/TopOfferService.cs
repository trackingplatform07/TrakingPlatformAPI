using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class TopOfferService : ITopOffer
    {
        private readonly OfferCategoryDbContext _context;

        public TopOfferService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static TopOfferDTO ToDto(TopOffer x) => new TopOfferDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            Description = x.Description,
            Kpi = x.Kpi,
            PreviewUrl = x.PreviewUrl,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<TopOfferDTO>> GetAllAsync()
        {
            return await _context.TopOffers
                .Where(x => x.IsActive == true)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<TopOfferDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.TopOffers
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<TopOfferDTO> CreateAsync(TopOfferDTO dto)
        {
            var entity = new TopOffer
            {
                OfferId = dto.OfferId,

                Description = dto.Description,
                Kpi = dto.Kpi,
                PreviewUrl = dto.PreviewUrl,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.TopOffers.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, TopOfferDTO dto)
        {
            var entity = await _context.TopOffers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.Description = dto.Description;
            entity.Kpi = dto.Kpi;
            entity.PreviewUrl = dto.PreviewUrl;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.TopOffers
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
