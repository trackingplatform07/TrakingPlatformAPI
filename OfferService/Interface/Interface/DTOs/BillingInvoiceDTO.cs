using System;

namespace Interface.DTOs
{
    public class BillingInvoiceDTO
    {
        public long Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;
        public string Type { get; set; } = "Subscription";
        public DateTime InvoiceDate { get; set; }

        public string Status { get; set; } = "Due";
        public decimal Amount { get; set; }

        public DateTime? PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }

    public class BillingUsageAddonDTO
    {
        public string ServiceName { get; set; } = string.Empty;
        public int RunTimes { get; set; }
        public int UnitsUsed { get; set; }
    }

    public class BillingUsageDTO
    {
        public long ImpressionsUsed { get; set; }
        public long ImpressionsLimit { get; set; }
        public int ClicksUsed { get; set; }
        public bool ClicksUnlimited { get; set; }
        public int ConversionsUsed { get; set; }
        public int ConversionsLimit { get; set; }
        public List<BillingUsageAddonDTO> AddonUsage { get; set; } = new();
    }
}
