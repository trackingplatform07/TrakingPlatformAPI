using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class LandingPageDTO
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Url { get; set; }

        public string? Targeting { get; set; }

        public string? AffiliateMode { get; set; }

        public long? AffiliateId { get; set; }

        public decimal? Weight { get; set; }

        public string? Visibility { get; set; }

        public string? Description { get; set; }

        public bool? Fallback { get; set; }

        public string? FallbackName { get; set; }

        public string? FallbackUrl { get; set; }

        public decimal? FallbackWeight { get; set; }

        public bool? Enabled { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
