using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class EventGoalService : IEventGoal
    {
        private readonly OfferCategoryDbContext _context;

        public EventGoalService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static EventGoalDTO ToDto(EventGoal x) => new EventGoalDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            EventName = x.EventName,
            Token = x.Token,

            MultiConversion = x.MultiConversion,
            MultiConversionIp = x.MultiConversionIp,
            Approval = x.Approval,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<EventGoalDTO>> GetAllAsync()
        {
            return await _context.EventGoals
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<EventGoalDTO>> GetByOfferIdAsync(long offerId)
        {
            return await _context.EventGoals
                .Where(x => x.OfferId == offerId)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<EventGoalDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.EventGoals
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<EventGoalDTO> CreateAsync(
            EventGoalDTO dto)
        {
            var entity = new EventGoal
            {
                OfferId = dto.OfferId,

                EventName = dto.EventName,
                Token = dto.Token,

                MultiConversion = dto.MultiConversion,
                MultiConversionIp = dto.MultiConversionIp,
                Approval = dto.Approval,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.EventGoals.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            EventGoalDTO dto)
        {
            var entity = await _context.EventGoals
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.EventName = dto.EventName;
            entity.Token = dto.Token;

            entity.MultiConversion = dto.MultiConversion;
            entity.MultiConversionIp = dto.MultiConversionIp;
            entity.Approval = dto.Approval;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.EventGoals
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.EventGoals.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
