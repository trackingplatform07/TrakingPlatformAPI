using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class CouponService : ICoupon
    {
        private readonly OfferCategoryDbContext _context;

        public CouponService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static CouponDTO ToDto(Coupon x) => new CouponDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            CouponCode = x.CouponCode,
            CouponType = x.CouponType,

            AffiliateMode = x.AffiliateMode,
            AffiliateIds = x.AffiliateIds,

            StartDate = x.StartDate,
            EndDate = x.EndDate,

            Quota = x.Quota,
            UsedCount = x.UsedCount,

            Status = x.Status,
            Description = x.Description,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<CouponDTO>> GetAllAsync()
        {
            return await _context.Coupons
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<CouponDTO>> GetByOfferIdAsync(long offerId)
        {
            return await _context.Coupons
                .Where(x => x.OfferId == offerId)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<CouponDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.Coupons
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<CouponDTO> CreateAsync(CouponDTO dto)
        {
            var entity = new Coupon
            {
                OfferId = dto.OfferId,

                CouponCode = dto.CouponCode,
                CouponType = dto.CouponType,

                AffiliateMode = dto.AffiliateMode,
                AffiliateIds = dto.AffiliateIds,

                StartDate = dto.StartDate,
                EndDate = dto.EndDate,

                Quota = dto.Quota,
                UsedCount = dto.UsedCount ?? 0,

                Status = dto.Status ?? "Approved",
                Description = dto.Description,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.Coupons.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.UsedCount = entity.UsedCount;
            dto.Status = entity.Status;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, CouponDTO dto)
        {
            var entity = await _context.Coupons
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.CouponCode = dto.CouponCode;
            entity.CouponType = dto.CouponType;

            entity.AffiliateMode = dto.AffiliateMode;
            entity.AffiliateIds = dto.AffiliateIds;

            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;

            entity.Quota = dto.Quota;
            entity.UsedCount = dto.UsedCount ?? entity.UsedCount;

            entity.Status = dto.Status ?? entity.Status;
            entity.Description = dto.Description;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Coupons
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.Coupons.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
