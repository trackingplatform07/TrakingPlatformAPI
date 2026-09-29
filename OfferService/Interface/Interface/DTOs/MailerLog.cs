using System;

namespace Interface.DTOs
{
    public class MailerLog
    {
        public long Id { get; set; }

        public long? AdvertiserId { get; set; }
        public long? AffiliateId { get; set; }

        // "Approved" / "Pending" / "Rejected" when a bulk group was targeted
        public string? BulkAdvertiserStatus { get; set; }
        public string? BulkAffiliateStatus { get; set; }

        public string? AdvertiserCountry { get; set; }
        public string? AffiliateCountry { get; set; }

        public string? Recipients { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }

        // "Send Now" or "Schedule Later"
        public string? Schedule { get; set; }
        public DateTime? ScheduledOn { get; set; }

        public long? TemplateId { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public int RecipientCount { get; set; }

        // "Sent" / "Failed" / "Scheduled" / "Logged (No SMTP Configured)"
        public string Status { get; set; } = "Logged (No SMTP Configured)";
        public string? ErrorMessage { get; set; }

        public DateTime? SentOn { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
