using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Security.Cryptography;
using System.Text;

namespace Service.Services
{
    public class SecuritySettingService : ISecuritySetting
    {
        private readonly OfferCategoryDbContext _context;

        public SecuritySettingService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static string Hash(string value) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value))).ToLowerInvariant();

        private static SecuritySettingDTO ToDto(SecuritySetting x) => new SecuritySettingDTO
        {
            Id = x.Id,

            TwoFactorEnabled = x.TwoFactorEnabled,
            LastPasswordChangeOn = x.LastPasswordChangeOn,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        private async Task<SecuritySetting> EnsureExistsAsync()
        {
            var entity = await _context.SecuritySettings.FirstOrDefaultAsync();
            if (entity != null) return entity;

            entity = new SecuritySetting
            {
                TwoFactorEnabled = false,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            _context.SecuritySettings.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<SecuritySettingDTO> GetAsync()
        {
            var entity = await EnsureExistsAsync();
            return ToDto(entity);
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordRequestDTO request)
        {
            var entity = await EnsureExistsAsync();

            if (!string.IsNullOrEmpty(entity.PasswordHash) && entity.PasswordHash != Hash(request.OldPassword))
                return false;

            entity.PasswordHash = Hash(request.NewPassword);
            entity.LastPasswordChangeOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = request.ChangedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SecuritySettingDTO> SetTwoFactorAsync(bool enabled, string? modifiedBy)
        {
            var entity = await EnsureExistsAsync();

            entity.TwoFactorEnabled = enabled;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
