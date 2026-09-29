using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class PayoutRule
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? RuleName { get; set; }

        public string? RevenueModel { get; set; }
        public decimal? RevenueValue { get; set; }

        public string? PayoutModel { get; set; }
        public decimal? PayoutValue { get; set; }

        public string? Currency { get; set; }

        // Serialized JSON array of { type, operator, value } condition rows
        // (Affiliate ID / Event / Country / custom conditions).
        public string? ConditionsJson { get; set; }

        public string? AffiliateVisibility { get; set; }
        public string? RulePriority { get; set; }
        public bool? EnableRule { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
