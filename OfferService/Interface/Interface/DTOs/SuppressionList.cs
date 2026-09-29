using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class SuppressionList
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? Name { get; set; }

        // Email Opt-out
        public string? SourceType { get; set; }
        public string? Url { get; set; }
        public string? UnsubscribeUrl { get; set; }

        // Email Instructions
        public string? SubjectLines { get; set; }
        public string? FromLines { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
