using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class AntiFraudSettingDTO
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        public string? ClickSpammingDefender { get; set; }
        public string? UniqueClickLimit { get; set; }
        public string? ProxyBotBlock { get; set; }
        public string? BrowserBlankReferral { get; set; }
        public string? DefaultIpSource { get; set; }

        public string? ClickIpv4RangeFilter { get; set; }
        public string? ClickIpv4RangeValues { get; set; }

        public string? HtmlRedirectHttpReferral { get; set; }

        public string? ClickBlockFiltersJson { get; set; }
        public string? ConversionValidateFiltersJson { get; set; }
        public string? CtitRulesJson { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
