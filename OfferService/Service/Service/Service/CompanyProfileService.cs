using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Security.Cryptography;

namespace Service.Services
{
    public class CompanyProfileService : ICompanyProfile
    {
        private readonly OfferCategoryDbContext _context;
        private readonly Random _random = new();

        public CompanyProfileService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static CompanyProfileDTO ToDto(CompanyProfile x) => new CompanyProfileDTO
        {
            Id = x.Id,

            AccountId = x.AccountId,

            Company = x.Company,
            AccountEmail = x.AccountEmail,

            FirstName = x.FirstName,
            LastName = x.LastName,

            Address = x.Address,
            City = x.City,
            State = x.State,
            Country = x.Country,
            Zip = x.Zip,

            Contact = x.Contact,

            SocialContactPlatform = x.SocialContactPlatform,
            SocialContactValue = x.SocialContactValue,

            CustomProfileName = x.CustomProfileName,
            CustomProfileEmail = x.CustomProfileEmail,
            CustomProfileContact = x.CustomProfileContact,
            CustomProfileSelect = x.CustomProfileSelect,
            CustomProfileExtra = x.CustomProfileExtra,

            TaxGstVat = x.TaxGstVat,
            TaxIgstVatType = x.TaxIgstVatType,
            TaxPan = x.TaxPan,
            TaxPercentage = x.TaxPercentage,

            AccountSecretKey = x.AccountSecretKey,
            SecretKeyGeneratedOn = x.SecretKeyGeneratedOn,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        private static string GenerateSecretKey() => Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLowerInvariant();

        private async Task<CompanyProfile> EnsureExistsAsync()
        {
            var entity = await _context.CompanyProfiles.FirstOrDefaultAsync();
            if (entity != null) return entity;

            entity = new CompanyProfile
            {
                AccountId = _random.Next(1000, 9999).ToString(),
                Company = "Demo",
                AccountEmail = "demo40@offer18.com",
                FirstName = "DEMO",
                Country = "India",
                Contact = "0000000000",
                SocialContactPlatform = "skype",
                SocialContactValue = "00",
                TaxPan = "ABCDEF00001",
                TaxPercentage = 18.00m,
                AccountSecretKey = GenerateSecretKey(),
                SecretKeyGeneratedOn = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            _context.CompanyProfiles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<CompanyProfileDTO> GetAsync()
        {
            var entity = await EnsureExistsAsync();
            return ToDto(entity);
        }

        public async Task<CompanyProfileDTO> UpdateAsync(CompanyProfileDTO dto)
        {
            var entity = await EnsureExistsAsync();

            entity.Company = dto.Company;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;

            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.State = dto.State;
            entity.Country = dto.Country;
            entity.Zip = dto.Zip;

            entity.Contact = dto.Contact;

            entity.SocialContactPlatform = dto.SocialContactPlatform;
            entity.SocialContactValue = dto.SocialContactValue;

            entity.CustomProfileName = dto.CustomProfileName;
            entity.CustomProfileEmail = dto.CustomProfileEmail;
            entity.CustomProfileContact = dto.CustomProfileContact;
            entity.CustomProfileSelect = dto.CustomProfileSelect;
            entity.CustomProfileExtra = dto.CustomProfileExtra;

            entity.TaxGstVat = dto.TaxGstVat;
            entity.TaxIgstVatType = dto.TaxIgstVatType;
            entity.TaxPan = dto.TaxPan;
            entity.TaxPercentage = dto.TaxPercentage;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<CompanyProfileDTO> ChangeEmailAsync(ChangeAccountEmailRequestDTO request)
        {
            var entity = await EnsureExistsAsync();

            entity.AccountEmail = request.NewEmail;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = request.ChangedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<CompanyProfileDTO> RegenerateSecretKeyAsync(string? regeneratedBy)
        {
            var entity = await EnsureExistsAsync();

            entity.AccountSecretKey = GenerateSecretKey();
            entity.SecretKeyGeneratedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = regeneratedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
