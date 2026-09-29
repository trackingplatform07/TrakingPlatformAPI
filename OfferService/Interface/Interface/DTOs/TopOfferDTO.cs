using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class TopOfferDTO
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? Description { get; set; }
        public string? Kpi { get; set; }
        public string? PreviewUrl { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
