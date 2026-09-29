using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class ProductFeedService : IProductFeed
    {
        private readonly OfferCategoryDbContext _context;

        public ProductFeedService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static ProductFeedDTO ToDto(ProductFeed x) => new ProductFeedDTO
        {
            Id = x.Id,

            FeedName = x.FeedName,
            FeedType = x.FeedType,

            OfferId = x.OfferId,
            AdvertiserId = x.AdvertiserId,

            AffiliateMode = x.AffiliateMode,
            AffiliateIds = x.AffiliateIds,

            AppendTokens = x.AppendTokens,

            Status = x.Status,
            SyncFrequency = x.SyncFrequency,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<ProductFeedDTO>> GetAllAsync()
        {
            return await _context.ProductFeeds
                .Where(x => x.IsActive == true)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<ProductFeedDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.ProductFeeds
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<ProductFeedDTO> CreateAsync(ProductFeedDTO dto)
        {
            var entity = new ProductFeed
            {
                FeedName = dto.FeedName,
                FeedType = dto.FeedType,

                OfferId = dto.OfferId,
                AdvertiserId = dto.AdvertiserId,

                AffiliateMode = dto.AffiliateMode,
                AffiliateIds = dto.AffiliateIds,

                AppendTokens = dto.AppendTokens,

                Status = dto.Status,
                SyncFrequency = dto.SyncFrequency,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.ProductFeeds.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, ProductFeedDTO dto)
        {
            var entity = await _context.ProductFeeds
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.FeedName = dto.FeedName;
            entity.FeedType = dto.FeedType;

            entity.OfferId = dto.OfferId;
            entity.AdvertiserId = dto.AdvertiserId;

            entity.AffiliateMode = dto.AffiliateMode;
            entity.AffiliateIds = dto.AffiliateIds;

            entity.AppendTokens = dto.AppendTokens;

            entity.Status = dto.Status;
            entity.SyncFrequency = dto.SyncFrequency;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.ProductFeeds
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
