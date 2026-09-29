using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class AutomationLogService : IAutomationLog
    {
        private readonly OfferCategoryDbContext _context;

        public AutomationLogService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static AutomationLogDTO ToDto(AutomationLog x) => new AutomationLogDTO
        {
            Id = x.Id,

            AutomationRuleId = x.AutomationRuleId,

            BlockLevel = x.BlockLevel,
            Alarm = x.Alarm,

            TargetLabel = x.TargetLabel,
            CurrentValue = x.CurrentValue,

            CheckedOn = x.CheckedOn,
            BlockedUntil = x.BlockedUntil,

            Status = x.Status,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<AutomationLogDTO>> GetAllAsync(long? automationRuleId)
        {
            var query = _context.AutomationLogs.Where(x => x.IsActive == true);

            if (automationRuleId.HasValue)
                query = query.Where(x => x.AutomationRuleId == automationRuleId.Value);

            return await query
                .OrderByDescending(x => x.CheckedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<AutomationLogDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.AutomationLogs
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<AutomationLogDTO> CreateAsync(AutomationLogDTO dto)
        {
            var entity = new AutomationLog
            {
                AutomationRuleId = dto.AutomationRuleId,

                BlockLevel = dto.BlockLevel,
                Alarm = dto.Alarm,

                TargetLabel = dto.TargetLabel,
                CurrentValue = dto.CurrentValue,

                CheckedOn = dto.CheckedOn ?? DateTime.UtcNow,
                BlockedUntil = dto.BlockedUntil,

                Status = dto.Status,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.AutomationLogs.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CheckedOn = entity.CheckedOn;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.AutomationLogs
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.IsActive = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
