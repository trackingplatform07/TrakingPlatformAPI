using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class BillingSubscriptionService : IBillingSubscription
    {
        private readonly OfferCategoryDbContext _context;

        public BillingSubscriptionService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static BillingSubscriptionDTO ToDto(BillingSubscription x) => new BillingSubscriptionDTO
        {
            Id = x.Id,

            PlanName = x.PlanName,
            PlanPriceMonthly = x.PlanPriceMonthly,
            PlanType = x.PlanType,
            PlanDescription = x.PlanDescription,

            ConversionsLimit = x.ConversionsLimit,
            ClicksUnlimited = x.ClicksUnlimited,
            ImpressionsLimit = x.ImpressionsLimit,

            AddonsJson = x.AddonsJson,

            Status = x.Status,

            BankName = x.BankName,
            BankAccountHolder = x.BankAccountHolder,
            BankAccountNumber = x.BankAccountNumber,
            BankIfscSwift = x.BankIfscSwift,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        private async Task<BillingSubscription> EnsureExistsAsync()
        {
            var entity = await _context.BillingSubscriptions.FirstOrDefaultAsync();
            if (entity != null) return entity;

            entity = new BillingSubscription
            {
                PlanName = "Professional",
                PlanPriceMonthly = 399.00m,
                PlanType = "Conversion Based Plan",
                PlanDescription = "Scale up Business Capabilities with Cost-effective Pricing & Premium Customer Support.",
                ConversionsLimit = 50000,
                ClicksUnlimited = true,
                ImpressionsLimit = 20000000,
                AddonsJson = "[{\"name\":\"iGaming\",\"quantity\":9,\"priceMonthly\":9.00},{\"name\":\"LinkTest\",\"quantity\":19,\"priceMonthly\":19.00}]",
                Status = "Active",
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            _context.BillingSubscriptions.Add(entity);
            await _context.SaveChangesAsync();

            _context.BillingPlanHistoryLogs.Add(new BillingPlanHistoryLog
            {
                Action = "Plan Created",
                ToPlanName = entity.PlanName,
                ToPrice = entity.PlanPriceMonthly,
                ChangedOn = DateTime.UtcNow,
                IsActive = true
            });
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<BillingSubscriptionDTO> GetAsync()
        {
            var entity = await EnsureExistsAsync();
            return ToDto(entity);
        }

        public async Task<BillingSubscriptionDTO> ChangePlanAsync(ChangePlanRequestDTO request)
        {
            var entity = await EnsureExistsAsync();

            var fromPlanName = entity.PlanName;
            var fromPrice = entity.PlanPriceMonthly;

            entity.PlanName = request.PlanName;
            entity.PlanPriceMonthly = request.PlanPriceMonthly;
            entity.PlanType = request.PlanType;
            entity.PlanDescription = request.PlanDescription;
            entity.ConversionsLimit = request.ConversionsLimit;
            entity.ClicksUnlimited = request.ClicksUnlimited;
            entity.ImpressionsLimit = request.ImpressionsLimit;
            entity.Status = "Active";
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = request.ChangedBy;

            _context.BillingPlanHistoryLogs.Add(new BillingPlanHistoryLog
            {
                Action = "Plan Changed",
                FromPlanName = fromPlanName,
                ToPlanName = request.PlanName,
                FromPrice = fromPrice,
                ToPrice = request.PlanPriceMonthly,
                ChangedOn = DateTime.UtcNow,
                CreatedBy = request.ChangedBy,
                IsActive = true
            });

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<BillingSubscriptionDTO> UpdateAddonsAsync(UpdateAddonsRequestDTO request)
        {
            var entity = await EnsureExistsAsync();

            entity.AddonsJson = request.AddonsJson;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = request.ChangedBy;

            _context.BillingPlanHistoryLogs.Add(new BillingPlanHistoryLog
            {
                Action = "Addons Updated",
                ToPlanName = entity.PlanName,
                Notes = request.AddonsJson,
                ChangedOn = DateTime.UtcNow,
                CreatedBy = request.ChangedBy,
                IsActive = true
            });

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<BillingSubscriptionDTO> UpdateBankDetailsAsync(BillingSubscriptionDTO request)
        {
            var entity = await EnsureExistsAsync();

            entity.BankName = request.BankName;
            entity.BankAccountHolder = request.BankAccountHolder;
            entity.BankAccountNumber = request.BankAccountNumber;
            entity.BankIfscSwift = request.BankIfscSwift;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = request.ModifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<BillingSubscriptionDTO> CancelAsync(string? cancelledBy)
        {
            var entity = await EnsureExistsAsync();

            entity.Status = "Cancelled";
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = cancelledBy;

            _context.BillingPlanHistoryLogs.Add(new BillingPlanHistoryLog
            {
                Action = "Subscription Cancelled",
                FromPlanName = entity.PlanName,
                FromPrice = entity.PlanPriceMonthly,
                ChangedOn = DateTime.UtcNow,
                CreatedBy = cancelledBy,
                IsActive = true
            });

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
