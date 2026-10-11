using System;

namespace Interface.DTOs
{
    public class ApiKeyDTO
    {
        public long Id { get; set; }

        public string KeyCode { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;

        public DateTime? LastActiveOn { get; set; }
        public string? WhitelistIp { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
