using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class BillingPlanHistoryLogService : IBillingPlanHistoryLog
    {
        private readonly OfferCategoryDbContext _context;

        public BillingPlanHistoryLogService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static BillingPlanHistoryLogDTO ToDto(BillingPlanHistoryLog x) => new BillingPlanHistoryLogDTO
        {
            Id = x.Id,

            Action = x.Action,

            FromPlanName = x.FromPlanName,
            ToPlanName = x.ToPlanName,
            FromPrice = x.FromPrice,
            ToPrice = x.ToPrice,
            Notes = x.Notes,

            ChangedOn = x.ChangedOn,
            CreatedBy = x.CreatedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<BillingPlanHistoryLogDTO>> GetAllAsync()
        {
            return await _context.BillingPlanHistoryLogs
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.ChangedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }
    }
}
