using System;

namespace Interface.DTOs
{
    public class ShortUrlDTO
    {
        public long Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string OriginalUrl { get; set; } = string.Empty;

        public long? OfferId { get; set; }
        public long? AffiliateId { get; set; }

        public string Status { get; set; } = "Enabled";

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }

    public class CreateShortUrlDTO
    {
        public string Url { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
    }
}
