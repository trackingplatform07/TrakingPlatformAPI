using System;

namespace Interface.DTOs
{
    public class BillingPlanHistoryLog
    {
        public long Id { get; set; }

        // "Plan Created" / "Plan Changed" / "Addons Updated" / "Subscription Cancelled"
        public string Action { get; set; } = string.Empty;

        public string? FromPlanName { get; set; }
        public string? ToPlanName { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public string? Notes { get; set; }

        public DateTime ChangedOn { get; set; }
        public string? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
