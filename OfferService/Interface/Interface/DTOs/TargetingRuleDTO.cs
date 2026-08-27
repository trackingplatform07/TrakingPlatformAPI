using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class TargetingRuleDTO
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? RuleName { get; set; }

        public string? Country { get; set; }

        public string? OS { get; set; }

        public string? Browser { get; set; }

        public string? DeviceType { get; set; }

        public string? ISP { get; set; }

        public string? ActionOnClicks { get; set; }

        public string? ActionOnConversions { get; set; }

        public string? ActionOnImpressions { get; set; }

        public string? AffiliateVisibility { get; set; }

        public bool? Enabled { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
