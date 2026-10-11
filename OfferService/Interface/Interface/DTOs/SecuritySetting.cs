using System;

namespace Interface.DTOs
{
    public class SecuritySetting
    {
        public long Id { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public string? PasswordHash { get; set; }
        public DateTime? LastPasswordChangeOn { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
