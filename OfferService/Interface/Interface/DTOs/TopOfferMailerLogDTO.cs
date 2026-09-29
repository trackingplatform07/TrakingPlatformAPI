using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class TopOfferMailerLogDTO
    {
        public long Id { get; set; }

        public long? AffiliateId { get; set; }
        public bool? BulkApproved { get; set; }

        public string? Emails { get; set; }
        public string? Subject { get; set; }

        public string? Source { get; set; }
        public string? TopOfferIds { get; set; }
        public string? OfferIds { get; set; }

        public DateTime? SentOn { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
