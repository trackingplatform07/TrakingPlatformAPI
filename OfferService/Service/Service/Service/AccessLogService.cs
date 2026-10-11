using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class AccessLogService : IAccessLog
    {
        private readonly OfferCategoryDbContext _context;

        public AccessLogService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static AccessLogDTO ToDto(AccessLog x) => new AccessLogDTO
        {
            Id = x.Id,
            OccurredOn = x.OccurredOn,
            Type = x.Type,
            AccessBy = x.AccessBy,
            EmployeeId = x.EmployeeId,
            Location = x.Location,
            LogData = x.LogData,
            UserInfo = x.UserInfo,
            IsActive = x.IsActive
        };

        public async Task<IEnumerable<AccessLogDTO>> QueryAsync(AccessLogQueryDTO query)
        {
            var logs = _context.AccessLogs.Where(x => x.IsActive == true);

            if (query.StartDate.HasValue)
                logs = logs.Where(x => x.OccurredOn >= query.StartDate.Value);

            if (query.EndDate.HasValue)
                logs = logs.Where(x => x.OccurredOn <= query.EndDate.Value);

            if (query.EmployeeId.HasValue)
                logs = logs.Where(x => x.EmployeeId == query.EmployeeId.Value);

            return await logs
                .OrderByDescending(x => x.OccurredOn)
                .Take(Math.Clamp(query.PageSize <= 0 ? 100 : query.PageSize, 1, 500))
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<AccessLogDTO> CreateAsync(AccessLogDTO dto)
        {
            var entity = new AccessLog
            {
                OccurredOn = dto.OccurredOn == default ? DateTime.UtcNow : dto.OccurredOn,
                Type = dto.Type,
                AccessBy = dto.AccessBy,
                EmployeeId = dto.EmployeeId,
                Location = dto.Location,
                LogData = dto.LogData,
                UserInfo = dto.UserInfo,
                IsActive = true
            };

            _context.AccessLogs.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.OccurredOn = entity.OccurredOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }
    }
}
