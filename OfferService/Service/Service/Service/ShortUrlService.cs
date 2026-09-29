using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class ShortUrlService : IShortUrl
    {
        private const string CodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly OfferCategoryDbContext _context;
        private readonly Random _random = new();

        public ShortUrlService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static ShortUrlDTO ToDto(ShortUrl x) => new ShortUrlDTO
        {
            Id = x.Id,

            Code = x.Code,
            OriginalUrl = x.OriginalUrl,

            OfferId = x.OfferId,
            AffiliateId = x.AffiliateId,

            Status = x.Status,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<ShortUrlDTO>> GetAllAsync()
        {
            return await _context.ShortUrls
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<ShortUrlDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<ShortUrlDTO?> GetByCodeAsync(string code)
        {
            var entity = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.Code == code);

            return entity == null ? null : ToDto(entity);
        }

        private string GenerateUniqueCode()
        {
            var buffer = new char[8];
            for (var attempt = 0; attempt < 20; attempt++)
            {
                for (var i = 0; i < buffer.Length; i++)
                    buffer[i] = CodeChars[_random.Next(CodeChars.Length)];

                var candidate = new string(buffer);
                if (!_context.ShortUrls.Any(x => x.Code == candidate))
                    return candidate;
            }

            return Guid.NewGuid().ToString("N")[..8];
        }

        private static (long? offerId, long? affiliateId) ParseIdsFromUrl(string url)
        {
            try
            {
                var uri = new Uri(url);
                var query = uri.Query.TrimStart('?');

                var pairs = query
                    .Split('&', StringSplitOptions.RemoveEmptyEntries)
                    .Select(part => part.Split('=', 2))
                    .Where(parts => parts.Length == 2)
                    .ToDictionary(
                        parts => Uri.UnescapeDataString(parts[0]).ToLowerInvariant(),
                        parts => Uri.UnescapeDataString(parts[1]),
                        StringComparer.OrdinalIgnoreCase);

                long? offerId = null;
                long? affiliateId = null;

                foreach (var key in new[] { "offerid", "offer_id", "oid" })
                {
                    if (pairs.TryGetValue(key, out var value) && long.TryParse(value, out var parsed))
                    {
                        offerId = parsed;
                        break;
                    }
                }

                foreach (var key in new[] { "affiliateid", "affiliate_id", "affid", "aff_id", "aid" })
                {
                    if (pairs.TryGetValue(key, out var value) && long.TryParse(value, out var parsed))
                    {
                        affiliateId = parsed;
                        break;
                    }
                }

                return (offerId, affiliateId);
            }
            catch
            {
                return (null, null);
            }
        }

        public async Task<ShortUrlDTO> CreateAsync(CreateShortUrlDTO request)
        {
            var (offerId, affiliateId) = ParseIdsFromUrl(request.Url);

            var entity = new ShortUrl
            {
                Code = GenerateUniqueCode(),
                OriginalUrl = request.Url,

                OfferId = offerId,
                AffiliateId = affiliateId,

                Status = "Enabled",

                CreatedOn = DateTime.UtcNow,
                CreatedBy = request.CreatedBy,

                IsActive = true
            };

            _context.ShortUrls.Add(entity);

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<bool> UpdateStatusAsync(long id, string status)
        {
            var entity = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.Status = status;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
