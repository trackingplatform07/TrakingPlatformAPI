using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Security.Cryptography;

namespace Service.Services
{
    public class ApiKeyService : IApiKey
    {
        private const string CodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly OfferCategoryDbContext _context;

        public ApiKeyService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static ApiKeyDTO ToDto(ApiKey x) => new ApiKeyDTO
        {
            Id = x.Id,

            KeyCode = x.KeyCode,
            SecretKey = x.SecretKey,

            LastActiveOn = x.LastActiveOn,
            WhitelistIp = x.WhitelistIp,

            Status = x.Status,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        private static string RandomCode(int length)
        {
            var bytes = RandomNumberGenerator.GetBytes(length);
            var chars = new char[length];
            for (var i = 0; i < length; i++) chars[i] = CodeChars[bytes[i] % CodeChars.Length];
            return new string(chars);
        }

        public async Task<IEnumerable<ApiKeyDTO>> GetAllAsync()
        {
            return await _context.ApiKeys
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<ApiKeyDTO> CreateAsync(string? createdBy)
        {
            var entity = new ApiKey
            {
                KeyCode = $"4860{RandomCode(16)}",
                SecretKey = Convert.ToHexString(RandomNumberGenerator.GetBytes(24)).ToLowerInvariant(),
                WhitelistIp = "1.1.1.1, 1.1.1.2",
                Status = "Active",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = createdBy,
                IsActive = true
            };

            _context.ApiKeys.Add(entity);

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<bool> UpdateWhitelistIpAsync(long id, string? whitelistIp)
        {
            var entity = await _context.ApiKeys
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.WhitelistIp = whitelistIp;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RevokeAsync(long id)
        {
            var entity = await _context.ApiKeys
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.Status = "Revoked";
            entity.IsActive = false;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
