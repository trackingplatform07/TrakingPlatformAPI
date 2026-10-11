using System;

namespace Interface.DTOs
{
    public class CompanyProfile
    {
        public long Id { get; set; }

        public string AccountId { get; set; } = string.Empty;

        public string? Company { get; set; }
        public string? AccountEmail { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }

        public string? Contact { get; set; }

        public string? SocialContactPlatform { get; set; }
        public string? SocialContactValue { get; set; }

        public string? CustomProfileName { get; set; }
        public string? CustomProfileEmail { get; set; }
        public string? CustomProfileContact { get; set; }
        public string? CustomProfileSelect { get; set; }
        public string? CustomProfileExtra { get; set; }

        public string? TaxGstVat { get; set; }
        public string? TaxIgstVatType { get; set; }
        public string? TaxPan { get; set; }
        public decimal? TaxPercentage { get; set; }

        public string AccountSecretKey { get; set; } = string.Empty;
        public DateTime? SecretKeyGeneratedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
