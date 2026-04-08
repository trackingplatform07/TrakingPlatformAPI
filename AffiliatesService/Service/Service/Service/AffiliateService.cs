using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System;

namespace Service.Service
{
    public class AffiliateService : IAffiliateService
    {
        private readonly AffiliateDbContext _context;

        public AffiliateService(AffiliateDbContext context)
        {
            _context = context;
        }

        public async Task<List<AffiliateDto>> GetAllAffiliates()
        {
            return await _context.Affiliates
                .Where(x => x.IsActive == true)
                .Select(x => new AffiliateDto
                {
                    Id = x.Id,

                    // Basic Information
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ExternalID = x.ExternalID,
                    Email = x.Email,
                    Contact = x.Contact,

                    // Company Information
                    Company = x.Company,
                    JobTitle = x.JobTitle,

                    // Address Information
                    Address = x.Address,
                    City = x.City,
                    State = x.State,
                    Country = x.Country,
                    ZipCode = x.ZipCode,

                    // Social Information
                    SocialContactType = x.SocialContactType,
                    SocialContact = x.SocialContact,

                    // Traffic
                    TrafficSources = x.TrafficSources,

                    // System Info
                    LastLogin = x.LastLogin,
                    SignupDate = x.SignupDate,
                    SignupIP = x.SignupIP,
                    SignupSource = x.SignupSource,

                    // Settings
                    PostbackDelay = x.PostbackDelay,
                    DefaultClickTokens = x.DefaultClickTokens,
                    TimeZone = x.TimeZone,
                    Currency = x.Currency,
                    FallBackURL = x.FallBackURL,

                    // API
                    ApiAccess = x.ApiAccess,
                    ApiKey = x.ApiKey,

                    // Account
                    Manager = x.Manager,
                    PrivateNote = x.PrivateNote,
                    Status = x.Status,
                    AllowProfileUpdate = x.AllowProfileUpdate,

                    // Additional
                    Options = x.Options,

                    // Audit
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<AffiliateDto?> GetAffiliateById(int id)
        {
            var x = await _context.Affiliates.FindAsync(id);

            if (x == null) return null;

            return new AffiliateDto
            {
                Id = x.Id,

                // Profile Fields
                ExternalID = x.ExternalID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Contact = x.Contact,
                Company = x.Company,
                JobTitle = x.JobTitle,
                Address = x.Address,
                City = x.City,
                State = x.State,
                Country = x.Country,
                ZipCode = x.ZipCode,
                SocialContactType = x.SocialContactType,
                MessengerAddress = x.MessengerAddress,
                SocialContact = x.SocialContact,
                TrafficSources = x.TrafficSources,
                Education = x.Education,
                Gender = x.Gender,
                Age = x.Age,
                Experience = x.Experience,

                // System Info
                LastLogin = x.LastLogin,
                SignupDate = x.SignupDate,
                SignupIP = x.SignupIP,
                SignupSource = x.SignupSource,

                // Settings
                PostbackDelay = x.PostbackDelay,
                DefaultClickTokens = x.DefaultClickTokens,
                TimeZone = x.TimeZone,
                Currency = x.Currency,
                FallBackURL = x.FallBackURL,

                // API Settings
                ApiAccess = x.ApiAccess,
                ApiKey = x.ApiKey,

                // Account Settings
                Manager = x.Manager,
                PrivateNote = x.PrivateNote,
                Status = x.Status,
                AllowProfileUpdate = x.AllowProfileUpdate,
                Options = x.Options,

                // Audit Columns
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                ModifiedOn = x.ModifiedOn,
                ModifiedBy = x.ModifiedBy,
                IsActive = x.IsActive
            };
        }

        public async Task<AffiliateDto> CreateAffiliate(AffiliateDto dto)
        {
            var entity = new AffiliateDto
            {
                ExternalID = dto.ExternalID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Contact = dto.Contact,
                Company = dto.Company,
                JobTitle = dto.JobTitle,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                SignupDate = DateTime.UtcNow,
                SignupIP= dto.SignupIP,
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                ZipCode=dto.ZipCode,
                SocialContactType=dto.SocialContactType,
                MessengerAddress=dto.MessengerAddress,
                Education=dto.Education,
                Gender=dto.Gender,
                Age=dto.Age,
                Experience=dto.Experience

            };

            _context.Affiliates.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<UpdateAffiliateDto?> UpdateAffiliate(int id, UpdateAffiliateDto dto)
        {
            var entity = await _context.Affiliates.FindAsync(id);

            if (entity == null) return null;

            // Profile Fields
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Company = dto.Company;
            entity.Contact =  dto.MobileNumber; // Support both field names
            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.State = dto.State;
            entity.Country = dto.Country;
            entity.ZipCode = dto.ZipCode;
            entity.SocialContactType = dto.SocialContactType;
            entity.SocialContact = dto.SocialContact;
            entity.TrafficSources = dto.TrafficSources;
            entity.ExternalID = dto.ExternalID;

            // Account Fields
            entity.Email = dto.Email;
            entity.Manager = dto.Manager;
            entity.PostbackDelay = dto.PostbackDelay;
            entity.TimeZone = dto.TimeZone;
            entity.FallBackURL = dto.FallBackURL;
            entity.AllowProfileUpdate = dto.AllowProfileUpdate;
            entity.Status = dto.Status;
            entity.PrivateNote = dto.PrivateNote;

            // API Fields
            entity.ApiAccess = dto.ApiAccess;
            // Note: API Key and Affiliate ID are usually not updated here, they are auto-generated

            // Sign Up & System Info Fields
            entity.SignupSource = dto.SignupSource;
            // SignUpDate should not be updated, it's set on creation
            // LastLogin should not be updated here, it's updated on login

            // Common Fields
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Return updated entity
            return dto; // Or map back to DTO
        }
        public async Task<UpdateAffiliateStausDto?> UpdateAffiliateStaus(int id, UpdateAffiliateStausDto dto)
        {
            var entity = await _context.Affiliates.FindAsync(id);

            if (entity == null) return null;
            entity.Status = dto.Status;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new UpdateAffiliateStausDto
            {
                Id = entity.Id,
                Status = entity.Status
            };
        }
        public async Task<bool> DeleteAffiliate(int id)
        {
            var entity = await _context.Affiliates.FindAsync(id);

            if (entity == null) return false;

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}