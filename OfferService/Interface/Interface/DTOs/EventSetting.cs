using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class EventSetting
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? ConversionWaitingTime { get; set; }
        public string? MultiConversion { get; set; }
        public string? ConversionApproval { get; set; }
        public string? MultiConversionIp { get; set; }
        public string? DefaultPostbackEvent { get; set; }
        public string? EventMismatchAction { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
