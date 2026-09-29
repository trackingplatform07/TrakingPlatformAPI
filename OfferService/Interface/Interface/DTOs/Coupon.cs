using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class Coupon
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? CouponCode { get; set; }
        public string? CouponType { get; set; }

        public string? AffiliateMode { get; set; }
        public string? AffiliateIds { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? Quota { get; set; }
        public int? UsedCount { get; set; }

        public string? Status { get; set; }
        public string? Description { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
