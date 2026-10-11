using System;

namespace Interface.DTOs
{
    public class EmployeeAccess
    {
        public long Id { get; set; }

        // "AffiliateManager" / "AdvertiserManager" / "Custom"
        public string Tag { get; set; } = "Custom";

        public string? Name { get; set; }
        public string Email { get; set; } = string.Empty;

        public DateTime? LastLoginOn { get; set; }

        // Null/0 = Not Assigned
        public int? PermissionsCount { get; set; }

        // "Active" / "Inactive"
        public string Status { get; set; } = "Active";

        public string AvatarColor { get; set; } = "#1f78d1";

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
