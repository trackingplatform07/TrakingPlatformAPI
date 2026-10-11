using System;

namespace Interface.DTOs
{
    public class ChangeLog
    {
        public long Id { get; set; }

        public DateTime OccurredOn { get; set; }

        // "Offer" / "Affiliate" / "Advertiser"
        public string ChangeType { get; set; } = string.Empty;

        // "Create" / "Update" / "Delete"
        public string ActionType { get; set; } = string.Empty;

        public string? AffectedEntity { get; set; }
        public long? OfferId { get; set; }
        public long? AdvertiserId { get; set; }
        public long? AffiliateId { get; set; }

        public string? ActionBy { get; set; }
        public string? LogData { get; set; }
        public string? UserInfo { get; set; }
        public string? Url { get; set; }

        public bool? IsActive { get; set; }
    }
}
