using Interface.DTOs;

namespace Interface.Interface
{
    public interface IBillingPlanHistoryLog
    {
        Task<IEnumerable<BillingPlanHistoryLogDTO>> GetAllAsync();
    }
}
