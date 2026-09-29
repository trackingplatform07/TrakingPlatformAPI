using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class EventSettingService : IEventSetting
    {
        private readonly OfferCategoryDbContext _context;

        public EventSettingService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static EventSettingDTO ToDto(EventSetting x) => new EventSettingDTO
        {
            Id = x.Id,
            OfferId = x.OfferId,

            ConversionWaitingTime = x.ConversionWaitingTime,
            MultiConversion = x.MultiConversion,
            ConversionApproval = x.ConversionApproval,
            MultiConversionIp = x.MultiConversionIp,
            DefaultPostbackEvent = x.DefaultPostbackEvent,
            EventMismatchAction = x.EventMismatchAction,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<EventSettingDTO>> GetAllAsync()
        {
            return await _context.EventSettings
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<EventSettingDTO?> GetByOfferIdAsync(long offerId)
        {
            var entity = await _context.EventSettings
                .FirstOrDefaultAsync(x => x.OfferId == offerId);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<EventSettingDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.EventSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<EventSettingDTO> CreateAsync(
            EventSettingDTO dto)
        {
            var entity = new EventSetting
            {
                OfferId = dto.OfferId,

                ConversionWaitingTime = dto.ConversionWaitingTime,
                MultiConversion = dto.MultiConversion,
                ConversionApproval = dto.ConversionApproval,
                MultiConversionIp = dto.MultiConversionIp,
                DefaultPostbackEvent = dto.DefaultPostbackEvent,
                EventMismatchAction = dto.EventMismatchAction,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive
            };

            _context.EventSettings.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;

            return dto;
        }

        public async Task<bool> UpdateAsync(
            long id,
            EventSettingDTO dto)
        {
            var entity = await _context.EventSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.OfferId = dto.OfferId;

            entity.ConversionWaitingTime = dto.ConversionWaitingTime;
            entity.MultiConversion = dto.MultiConversion;
            entity.ConversionApproval = dto.ConversionApproval;
            entity.MultiConversionIp = dto.MultiConversionIp;
            entity.DefaultPostbackEvent = dto.DefaultPostbackEvent;
            entity.EventMismatchAction = dto.EventMismatchAction;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.EventSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.EventSettings.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
