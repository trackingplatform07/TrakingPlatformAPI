using Interface.DTOs;

namespace Interface.Interface
{
    public interface IAffiliateReferral
    {
        Task<IEnumerable<AffiliateReferralDTO>> GetAllAsync();

        Task<AffiliateReferralDTO> MarkPaidAsync(long id, string? modifiedBy);
    }
}
