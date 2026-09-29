using System;

namespace Interface.DTOs
{
    public class BillingSubscription
    {
        public long Id { get; set; }

        public string PlanName { get; set; } = "Professional";
        public decimal PlanPriceMonthly { get; set; } = 399.00m;
        public string PlanType { get; set; } = "Conversion Based Plan";
        public string? PlanDescription { get; set; }

        public int? ConversionsLimit { get; set; }
        public bool ClicksUnlimited { get; set; } = true;
        public long? ImpressionsLimit { get; set; }

        public string? AddonsJson { get; set; }

        // "Active" / "Cancelled"
        public string Status { get; set; } = "Active";

        public string? BankName { get; set; }
        public string? BankAccountHolder { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankIfscSwift { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
