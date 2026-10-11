namespace Interface.DTOs
{
    public class ReferredAccountDTO
    {
        public long Id { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime SignedUpOn { get; set; }
        public string Status { get; set; } = "Active";
        public decimal Profit { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
    }

    public class ReferralSummaryDTO
    {
        public string ReferralCode { get; set; } = string.Empty;
        public string ReferralLink { get; set; } = string.Empty;
        public bool AffiliateDashboardVisible { get; set; }
        public int ReferredUsers { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public List<ReferredAccountDTO> ReferredAccounts { get; set; } = new();
    }

    public class SetAffiliateDashboardVisibilityRequestDTO
    {
        public bool Visible { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
