using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class Creative
    {
        public long CreativeID { get; set; }

        public long? OfferID { get; set; }

        public string? Title { get; set; }

        public string? Dimensions { get; set; }

        public decimal? Size { get; set; }

        public string? Preview { get; set; }

        public string? AffiliateTrackingURL { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
