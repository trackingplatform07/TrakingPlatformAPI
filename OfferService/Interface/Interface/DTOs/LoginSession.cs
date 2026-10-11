using System;

namespace Interface.DTOs
{
    public class LoginSession
    {
        public long Id { get; set; }

        public string SessionId { get; set; } = string.Empty;

        // "Active" / "Logged Out"
        public string Status { get; set; } = "Active";

        public string? UserAgent { get; set; }
        public string? LoginIp { get; set; }
        public DateTime LoginOn { get; set; }
        public int SignInCount { get; set; } = 1;

        public bool? IsActive { get; set; }
    }
}
