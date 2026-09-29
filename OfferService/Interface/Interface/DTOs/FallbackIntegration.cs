using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class FallbackIntegration
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        // Postback
        public string? PostbackType { get; set; }

        // Fallback Config
        public string? EnableFallback { get; set; }
        public string? FallbackUrl { get; set; }
        public long? FallbackOfferId { get; set; }
        public string? FallbackOfferReportsAffiliates { get; set; }

        // Integration
        public string? HtmlJsCode { get; set; }
        public string? UrlToReplace { get; set; }
        public string? Erid { get; set; }
        public string? ForceAffiliateLandingRedirect { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
