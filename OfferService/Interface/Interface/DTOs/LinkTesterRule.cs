using System;

namespace Interface.DTOs
{
    public class LinkTesterRule
    {
        public long Id { get; set; }

        public string RuleName { get; set; } = string.Empty;

        public long? AdvertiserId { get; set; }
        public long? OfferId { get; set; }
        public string? CustomUrl { get; set; }

        public string Status { get; set; } = "Active";
        public string? Schedule { get; set; }
        public string? Browser { get; set; }
        public string? TestCountry { get; set; }

        public string? HealthyCheckThreshold { get; set; }
        public string? AllowedRedirection { get; set; }
        public string? ResaleDetection { get; set; }

        public string? AdvertiserAppId { get; set; }
        public string? AppIdMatch { get; set; }
        public string? AllowedHttpStatuses { get; set; }
        public bool StopOffer { get; set; }
        public bool MinimumOneRedirect { get; set; }

        public DateTime? LastCheck { get; set; }
        public string? Health { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
