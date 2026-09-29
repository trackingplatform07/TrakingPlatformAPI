using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class AntiFraudSetting
    {
        public long Id { get; set; }

        public long? OfferId { get; set; }

        // Fraud Detection
        public string? ClickSpammingDefender { get; set; }
        public string? UniqueClickLimit { get; set; }
        public string? ProxyBotBlock { get; set; }
        public string? BrowserBlankReferral { get; set; }
        public string? DefaultIpSource { get; set; }

        // Click IPv4 Range Filter
        public string? ClickIpv4RangeFilter { get; set; }
        public string? ClickIpv4RangeValues { get; set; }

        // HTML Redirect / HTTP Referral
        public string? HtmlRedirectHttpReferral { get; set; }

        // Serialized JSON: { ip, aff_id, sub_aff_id, aff_sub1..5, source, referral_domain }
        public string? ClickBlockFiltersJson { get; set; }

        // Serialized JSON: { <key>: { value, mode } } for adv_sub1..5, click_aff_sub1..4,
        // click_source, click_google_aid, click_device_id, click_android_id, click_ios_idfa
        public string? ConversionValidateFiltersJson { get; set; }

        // Serialized JSON array of Conversions CTIT rule rows
        public string? CtitRulesJson { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
