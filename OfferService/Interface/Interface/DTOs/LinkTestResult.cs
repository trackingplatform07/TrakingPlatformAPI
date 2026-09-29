using System;

namespace Interface.DTOs
{
    public class LinkTestResult
    {
        public long Id { get; set; }

        public long? RuleId { get; set; }

        public string Url { get; set; } = string.Empty;
        public string? OsDevice { get; set; }
        public string? Country { get; set; }

        public int? FinalStatusCode { get; set; }
        public int RedirectCount { get; set; }
        public string? ResultText { get; set; }

        // "Success" / "Failed" / "Error"
        public string Status { get; set; } = "Failed";

        public DateTime StartedOn { get; set; }
        public DateTime? FinishedOn { get; set; }

        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
