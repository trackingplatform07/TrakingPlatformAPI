using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class Affiliate
    {
        public int AffiliateID { get; set; }

        public string? ExternalID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }

        public string? Company { get; set; }
        public string? JobTitle { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public string? Social { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? SignupDate { get; set; }
        public string? SignupIP { get; set; }
        public string? SignupSource { get; set; }

        public int? PostbackDelay { get; set; }
        public string? DefaultClickTokens { get; set; }

        public string? TimeZone { get; set; }
        public string? TrafficSources { get; set; }
        public string? Currency { get; set; }

        public string? FallBackURL { get; set; }

        public bool? ApiAccess { get; set; }

        public string? Manager { get; set; }
        public string? PrivateNote { get; set; }

        public string? Status { get; set; }

        public string? Options { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
