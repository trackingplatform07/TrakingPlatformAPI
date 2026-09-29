using Interface.DTOs;

namespace Interface.Interface
{
    public interface IBillingSubscription
    {
        Task<BillingSubscriptionDTO> GetAsync();

        Task<BillingSubscriptionDTO> ChangePlanAsync(ChangePlanRequestDTO request);

        Task<BillingSubscriptionDTO> UpdateAddonsAsync(UpdateAddonsRequestDTO request);

        Task<BillingSubscriptionDTO> UpdateBankDetailsAsync(BillingSubscriptionDTO request);

        Task<BillingSubscriptionDTO> CancelAsync(string? cancelledBy);
    }
}
