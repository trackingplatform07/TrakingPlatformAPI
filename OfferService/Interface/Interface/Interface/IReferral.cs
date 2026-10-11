using Interface.DTOs;

namespace Interface.Interface
{
    public interface IReferral
    {
        Task<ReferralSummaryDTO> GetSummaryAsync();

        Task<ReferralSummaryDTO> SetAffiliateDashboardVisibilityAsync(SetAffiliateDashboardVisibilityRequestDTO request);
    }
}
