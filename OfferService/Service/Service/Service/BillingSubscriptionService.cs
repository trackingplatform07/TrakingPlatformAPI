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

            GstVatNumber = x.GstVatNumber,
            TaxNumberPan = x.TaxNumberPan,
            CompanyName = x.CompanyName,
            CompanyAddress = x.CompanyAddress,
            Country = x.Country,
            State = x.State,
            StateCode = x.StateCode,
            City = x.City,
            Zip = x.Zip,
            Phone = x.Phone,
            NotificationEmails = x.NotificationEmails,

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
                TaxNumberPan = "33434",
                CompanyName = "Demo",
                CompanyAddress = "Demo",
                Country = "India",
                StateCode = "08",
                Phone = "0000000000",
                NotificationEmails = "demo40@offer18.com",
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

            var invoiceCount = await _context.BillingInvoices.CountAsync();
            _context.BillingInvoices.Add(new BillingInvoice
            {
                InvoiceNumber = $"INV-{invoiceCount + 1:D5}",
                Type = "Subscription",
                InvoiceDate = DateTime.UtcNow,
                Status = "Due",
                Amount = request.PlanPriceMonthly,
                CreatedOn = DateTime.UtcNow,
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

        public async Task<BillingSubscriptionDTO> UpdateBillingProfileAsync(BillingSubscriptionDTO request)
        {
            var entity = await EnsureExistsAsync();

            entity.GstVatNumber = request.GstVatNumber;
            entity.TaxNumberPan = request.TaxNumberPan;
            entity.CompanyName = request.CompanyName;
            entity.CompanyAddress = request.CompanyAddress;
            entity.Country = request.Country;
            entity.State = request.State;
            entity.StateCode = request.StateCode;
            entity.City = request.City;
            entity.Zip = request.Zip;
            entity.Phone = request.Phone;
            entity.NotificationEmails = request.NotificationEmails;
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

        public async Task<BillingUsageDTO> GetUsageAsync()
        {
            var entity = await EnsureExistsAsync();

            var now = DateTime.UtcNow;
            var monthStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTestRunsThisMonth = await _context.LinkTestResults
                .Where(x => x.IsActive == true && x.StartedOn >= monthStart)
                .CountAsync();

            var addonUsage = new List<BillingUsageAddonDTO>();
            var addons = new List<(string Name, int Quantity)>();
            try
            {
                var parsed = System.Text.Json.JsonSerializer.Deserialize<List<System.Text.Json.JsonElement>>(entity.AddonsJson ?? "[]");
                if (parsed != null)
                {
                    foreach (var item in parsed)
                    {
                        var name = item.TryGetProperty("name", out var nameProp) ? nameProp.GetString() ?? "" : "";
                        var quantity = item.TryGetProperty("quantity", out var qtyProp) ? qtyProp.GetInt32() : 0;
                        addons.Add((name, quantity));
                    }
                }
            }
            catch
            {
                // ignore malformed addons json
            }

            if (addons.Any(a => a.Name == "LinkTest"))
            {
                addonUsage.Add(new BillingUsageAddonDTO
                {
                    ServiceName = "Link Test",
                    RunTimes = linkTestRunsThisMonth,
                    UnitsUsed = linkTestRunsThisMonth
                });
            }

            return new BillingUsageDTO
            {
                ImpressionsUsed = 0,
                ImpressionsLimit = entity.ImpressionsLimit ?? 0,
                ClicksUsed = linkTestRunsThisMonth,
                ClicksUnlimited = entity.ClicksUnlimited,
                ConversionsUsed = 0,
                ConversionsLimit = entity.ConversionsLimit ?? 0,
                AddonUsage = addonUsage
            };
        }
    }
}
