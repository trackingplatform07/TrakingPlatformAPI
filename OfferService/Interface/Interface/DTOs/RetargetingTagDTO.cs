using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class RetargetingTagDTO
    {
        public long Id { get; set; }

        public long? AffiliateId { get; set; }

        public string? TagName { get; set; }
        public string? Url { get; set; }
        public string? Code { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
