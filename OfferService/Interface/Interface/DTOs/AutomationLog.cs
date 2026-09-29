using System;

namespace Interface.DTOs
{
    public class AutomationLog
    {
        public long Id { get; set; }

        public long? AutomationRuleId { get; set; }

        public string? BlockLevel { get; set; }
        public string? Alarm { get; set; }

        // Label of the specific Offer / Affiliate / Sub value this log row is about
        public string? TargetLabel { get; set; }

        public string? CurrentValue { get; set; }

        public DateTime? CheckedOn { get; set; }
        public DateTime? BlockedUntil { get; set; }

        // "Blocked" / "Resumed" / "Active"
        public string? Status { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
