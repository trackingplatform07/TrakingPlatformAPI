using System;

namespace Interface.DTOs
{
    public class BillingInvoice
    {
        public long Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;
        public string Type { get; set; } = "Subscription";
        public DateTime InvoiceDate { get; set; }

        // "Due" / "Paid" / "Failed"
        public string Status { get; set; } = "Due";
        public decimal Amount { get; set; }

        public DateTime? PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
