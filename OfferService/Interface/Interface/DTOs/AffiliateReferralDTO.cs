namespace Interface.DTOs
{
    public class AffiliateReferralDTO
    {
        public long Id { get; set; }
        public long ReferrerAffiliateId { get; set; }
        public string? ReferrerName { get; set; }
        public long ReferredAffiliateId { get; set; }
        public string? ReferredName { get; set; }
        public decimal ReferralPercentage { get; set; }
        public decimal TotalCommission { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
        public DateTime? CreatedOn { get; set; }
    }
}
