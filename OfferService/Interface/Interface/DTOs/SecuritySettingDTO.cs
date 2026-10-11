using System;

namespace Interface.DTOs
{
    public class SecuritySettingDTO
    {
        public long Id { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LastPasswordChangeOn { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ChangePasswordRequestDTO
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string? ChangedBy { get; set; }
    }
}
