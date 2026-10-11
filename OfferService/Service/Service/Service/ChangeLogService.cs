using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class ChangeLogService : IChangeLog
    {
        private readonly OfferCategoryDbContext _context;

        public ChangeLogService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static ChangeLogDTO ToDto(ChangeLog x) => new ChangeLogDTO
        {
            Id = x.Id,

            OccurredOn = x.OccurredOn,

            ChangeType = x.ChangeType,
            ActionType = x.ActionType,

            AffectedEntity = x.AffectedEntity,
            OfferId = x.OfferId,
            AdvertiserId = x.AdvertiserId,
            AffiliateId = x.AffiliateId,

            ActionBy = x.ActionBy,
            LogData = x.LogData,
            UserInfo = x.UserInfo,
            Url = x.Url,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<ChangeLogDTO>> QueryAsync(ChangeLogQueryDTO query)
        {
            var logs = _context.ChangeLogs.Where(x => x.IsActive == true);

            if (query.StartDate.HasValue)
                logs = logs.Where(x => x.OccurredOn >= query.StartDate.Value);

            if (query.EndDate.HasValue)
                logs = logs.Where(x => x.OccurredOn <= query.EndDate.Value);

            if (query.OfferId.HasValue)
                logs = logs.Where(x => x.OfferId == query.OfferId.Value);

            if (query.AdvertiserId.HasValue)
                logs = logs.Where(x => x.AdvertiserId == query.AdvertiserId.Value);

            if (query.AffiliateId.HasValue)
                logs = logs.Where(x => x.AffiliateId == query.AffiliateId.Value);

            return await logs
                .OrderByDescending(x => x.OccurredOn)
                .Take(Math.Clamp(query.PageSize <= 0 ? 100 : query.PageSize, 1, 500))
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<ChangeLogDTO> CreateAsync(ChangeLogDTO dto)
        {
            var entity = new ChangeLog
            {
                OccurredOn = dto.OccurredOn == default ? DateTime.UtcNow : dto.OccurredOn,

                ChangeType = dto.ChangeType,
                ActionType = dto.ActionType,

                AffectedEntity = dto.AffectedEntity,
                OfferId = dto.OfferId,
                AdvertiserId = dto.AdvertiserId,
                AffiliateId = dto.AffiliateId,

                ActionBy = dto.ActionBy,
                LogData = dto.LogData,
                UserInfo = dto.UserInfo,
                Url = dto.Url,

                IsActive = true
            };

            _context.ChangeLogs.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.OccurredOn = entity.OccurredOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }
    }
}
