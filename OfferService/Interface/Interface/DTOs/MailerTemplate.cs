using System;

namespace Interface.DTOs
{
    public class MailerTemplate
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
