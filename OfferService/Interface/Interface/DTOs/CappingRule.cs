using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class CappingRule
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? RuleName { get; set; }
        public string? RuleType { get; set; }

        public string? CappingType { get; set; }
        public string? Period { get; set; }
        public decimal? CappingValue { get; set; }

        public string? OverCappingAction { get; set; }
        public bool? CappingTimezoneEnabled { get; set; }

        public string? Events { get; set; }

        public string? AffiliateVisibility { get; set; }
        public bool? EnableRule { get; set; }

        public string? NotificationEmail { get; set; }
        public decimal? EarlierNotificationThreshold { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
