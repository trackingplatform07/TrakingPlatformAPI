using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class AutomationRule
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        // Setup
        public string? RuleName { get; set; }
        public string? Status { get; set; }
        public string? BlockLevel { get; set; }

        // Scope
        public string? Advertiser { get; set; }

        // Serialized JSON array of { id, name } offer chips
        public string? OffersJson { get; set; }

        // Trigger
        public string? Conversion { get; set; }
        public string? Clicks { get; set; }
        public string? Impressions { get; set; }
        public string? Field { get; set; }
        public string? CompareType { get; set; }
        public string? MinValue { get; set; }
        public string? MaxValue { get; set; }

        // Filters / Schedule
        public string? ReportStatus { get; set; }
        public string? DataLookBack { get; set; }
        public string? Schedule { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        // Recovery / Whitelist
        public string? WhitelistOffers { get; set; }
        public string? ResumeAfter { get; set; }
        public bool? AlertEnabled { get; set; }

        // Runtime / list display
        public DateTime? LastCheck { get; set; }
        public string? Alarm { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
