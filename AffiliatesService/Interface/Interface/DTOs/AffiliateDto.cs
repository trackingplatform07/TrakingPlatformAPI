using System;

namespace Interface.DTOs
{
    public class AffiliateDto
    {
        public int Id { get; set; }

        // Profile Fields
        public string? ExternalID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? SocialContactType { get; set; }
        public string? MessengerAddress { get; set; }
        public string? SocialContact { get; set; }
        public string? TrafficSources { get; set; }
        public string? Education { get; set; }
        public string? Gender { get; set; }
        public string? Age { get; set; }
        public string? Experience { get; set; }

        // System Info
        public DateTime? LastLogin { get; set; }
        public DateTime? SignupDate { get; set; }
        public string? SignupIP { get; set; }
        public string? SignupSource { get; set; }

        // Settings
        public int? PostbackDelay { get; set; }
        public string? DefaultClickTokens { get; set; }
        public string? TimeZone { get; set; }
        public string? Currency { get; set; }
        public string? FallBackURL { get; set; }

        // API Settings
        public bool ApiAccess { get; set; }
        public string? ApiKey { get; set; }

        // Account Settings
        public string? Manager { get; set; }
        public string? PrivateNote { get; set; }
        public string? Status { get; set; }
        public bool AllowProfileUpdate { get; set; }
        public string? Options { get; set; }
        

        // Audit Columns
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateAffiliateStausDto
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}