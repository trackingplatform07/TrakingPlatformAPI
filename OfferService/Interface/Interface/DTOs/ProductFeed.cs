using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class ProductFeed
    {
        public long Id { get; set; }

        public string FeedName { get; set; } = string.Empty;
        public string FeedType { get; set; } = "CSV";

        public long? OfferId { get; set; }
        public long? AdvertiserId { get; set; }

        public string AffiliateMode { get; set; } = "Allow";
        public string? AffiliateIds { get; set; }

        public string? AppendTokens { get; set; }

        public string Status { get; set; } = "Enabled";
        public string SyncFrequency { get; set; } = "Every 24 Hrs";

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
