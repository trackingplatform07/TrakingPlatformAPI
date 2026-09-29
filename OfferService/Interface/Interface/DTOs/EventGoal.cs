using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class EventGoal
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? EventName { get; set; }
        public string? Token { get; set; }

        public string? MultiConversion { get; set; }
        public string? MultiConversionIp { get; set; }
        public string? Approval { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
