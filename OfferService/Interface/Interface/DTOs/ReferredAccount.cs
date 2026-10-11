namespace Interface.DTOs
{
    public class ReferredAccount
    {
        public long Id { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime SignedUpOn { get; set; }
        public string Status { get; set; } = "Active";
        public decimal Profit { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public bool? IsActive { get; set; }
    }
}
