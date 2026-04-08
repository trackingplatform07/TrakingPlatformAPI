using System;

namespace Interface.DTOs
{
    public class UpdateAffiliateDto
    {
        // Profile Fields
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Company { get; set; }
        public string? MobileNumber { get; set; }
        public string? Contact { get; set; } // For backward compatibility
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? SocialContactType { get; set; }
        public string? SocialContact { get; set; }
        public string? TrafficSources { get; set; }
        public string? ExternalID { get; set; }

        // Account Fields
        public string? Email { get; set; }
        public string? Manager { get; set; }
        public int? PostbackDelay { get; set; }
        public string? TimeZone { get; set; }
        public string? FallBackURL { get; set; }
        public bool AllowProfileUpdate { get; set; }
        public string? Status { get; set; }
        public string? PrivateNote { get; set; }

        // API Fields
        public bool ApiAccess { get; set; }
        // ApiKey and Id are typically not updated via this DTO

        // Sign Up & System Info Fields
        public string? SignupSource { get; set; }
    }
}