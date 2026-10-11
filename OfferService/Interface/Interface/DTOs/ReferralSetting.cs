namespace Interface.DTOs
{
    public class ReferralSetting
    {
        public long Id { get; set; }
        public bool AffiliateDashboardVisible { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
