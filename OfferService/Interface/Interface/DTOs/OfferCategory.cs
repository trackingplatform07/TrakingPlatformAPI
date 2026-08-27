using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class OfferCategory
    {
        public int Id { get; set; }

        public string OfferCategoryName { get; set; }

        // Audit Columns
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
