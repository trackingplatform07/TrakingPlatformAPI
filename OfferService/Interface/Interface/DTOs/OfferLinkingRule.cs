using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class OfferLinkingRule
    {
        public long Id { get; set; }

        public string? RuleName { get; set; }

        public long? AdvertiserId { get; set; }

        public string? OffersMode { get; set; }
        public string? OfferIds { get; set; }

        public string? AffiliatesMode { get; set; }
        public string? AffiliateIds { get; set; }

        public string? PayoutCurrency { get; set; }
        public string? PayoutModel { get; set; }

        public decimal? MinPayout { get; set; }
        public decimal? MaxPayout { get; set; }

        public string? Country { get; set; }
        public string? Status { get; set; }

        public DateTime? LastChecked { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
