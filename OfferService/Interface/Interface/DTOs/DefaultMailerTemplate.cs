using System;

namespace Interface.DTOs
{
    public class DefaultMailerTemplate
    {
        public long Id { get; set; }

        public string TemplateKey { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public int SortOrder { get; set; }

        public string? Subject { get; set; }
        public string? Body { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
