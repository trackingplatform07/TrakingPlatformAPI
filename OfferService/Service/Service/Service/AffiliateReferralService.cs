using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class AffiliateReferralService : IAffiliateReferral
    {
        private readonly OfferCategoryDbContext _context;

        public AffiliateReferralService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static AffiliateReferralDTO ToDto(AffiliateReferral x) => new AffiliateReferralDTO
        {
            Id = x.Id,
            ReferrerAffiliateId = x.ReferrerAffiliateId,
            ReferrerName = x.ReferrerName,
            ReferredAffiliateId = x.ReferredAffiliateId,
            ReferredName = x.ReferredName,
            ReferralPercentage = x.ReferralPercentage,
            TotalCommission = x.TotalCommission,
            PaymentStatus = x.PaymentStatus,
            CreatedOn = x.CreatedOn
        };

        public async Task<IEnumerable<AffiliateReferralDTO>> GetAllAsync()
        {
            return await _context.AffiliateReferrals
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<AffiliateReferralDTO> MarkPaidAsync(long id, string? modifiedBy)
        {
            var entity = await _context.AffiliateReferrals.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("Referral not found.");

            entity.PaymentStatus = "Paid";
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
