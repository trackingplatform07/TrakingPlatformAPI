namespace Interface.DTOs
{
    public class AffiliateInvoice
    {
        public long Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public long AffiliateId { get; set; }
        public string? AffiliateName { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string TimezoneOffset { get; set; } = "+0:00";
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = "USD";
        public string Status { get; set; } = "Pending";
        public string? Note { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
