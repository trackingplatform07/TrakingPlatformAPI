using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Service
{
    public class AffiliatePostbackService : IAffiliatePostbackService
    {
        private readonly AffiliateDbContext _context;

        public AffiliatePostbackService(AffiliateDbContext context)
        {
            _context = context;
        }

        // ✅ Get All
        public async Task<List<AffiliatePostbackDto>> GetAllPostbacks()
        {
            return await _context.AffiliatePostbacks
                .Where(x => x.IsActive == true)
                .Select(x => new AffiliatePostbackDto
                {
                    Id = x.Id,
                    AffiliateId = x.AffiliateId,
                    AffiliateName = x.AffiliateName,
                    Position = x.Position,
                    OfferId = x.OfferId,
                    EventType = x.EventType,
                    IntegrationType = x.IntegrationType,
                    Type = x.Type,
                    PostbackURL = x.PostbackURL,
                    Status = x.Status,
                    TriggerType = x.TriggerType,
                    UpdateTime = x.UpdateTime,

                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        // ✅ Get By Id
        public async Task<AffiliatePostbackDto?> GetPostbackById(int id)
        {
            var x = await _context.AffiliatePostbacks.FindAsync(id);

            if (x == null) return null;

            return new AffiliatePostbackDto
            {
                Id = x.Id,
                AffiliateId = x.AffiliateId,
                AffiliateName = x.AffiliateName,
                Position = x.Position,
                OfferId = x.OfferId,
                EventType = x.EventType,
                IntegrationType = x.IntegrationType,
                Type = x.Type,
                PostbackURL = x.PostbackURL,
                Status = x.Status,
                TriggerType = x.TriggerType,
                UpdateTime = x.UpdateTime,

                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                ModifiedOn = x.ModifiedOn,
                ModifiedBy = x.ModifiedBy,
                IsActive = x.IsActive
            };
        }

        // ✅ Create
        public async Task<AffiliatePostbackDto> CreatePostback(CreateAffiliatePostbackDto dto)
        {
            var entity = new AffiliatePostbackDto
            {
                AffiliateId = dto.AffiliateId,
                AffiliateName = dto.AffiliateName,
                Position = dto.Position,
                OfferId = dto.OfferId,
                EventType = dto.EventType,
                IntegrationType = dto.IntegrationType,
                Type = dto.Type,
                PostbackURL = dto.PostbackUrl,
                Status = dto.Status,
                TriggerType = dto.TriggerType,

                CreatedBy = dto.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };
            
            _context.AffiliatePostbacks.Add(entity);
            await _context.SaveChangesAsync();

            return new AffiliatePostbackDto
            {
                Id = entity.Id,
                AffiliateId = entity.AffiliateId,
                AffiliateName = entity.AffiliateName,
                Position = entity.Position,
                OfferId = entity.OfferId,
                EventType = entity.EventType,
                IntegrationType = entity.IntegrationType,
                Type = entity.Type,
                PostbackURL = entity.PostbackURL,
                Status = entity.Status,
                TriggerType = entity.TriggerType,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                IsActive = entity.IsActive
            };
        }

        // ✅ Update
        public async Task<AffiliatePostbackDto?> UpdatePostback(int id, UpdateAffiliatePostbackDto dto)
        {
            var entity = await _context.AffiliatePostbacks.FindAsync(id);

            if (entity == null) return null;

            entity.AffiliateId = dto.AffiliateId;
            entity.AffiliateName = dto.AffiliateName;
            entity.Position = dto.Position;
            entity.OfferId = dto.OfferId;
            entity.EventType = dto.EventType;
            entity.IntegrationType = dto.IntegrationType;
            entity.Type = dto.Type;
            entity.PostbackURL = dto.PostbackUrl;
            entity.Status = dto.Status;
            entity.TriggerType = dto.TriggerType;

            entity.ModifiedBy = dto.ModifiedBy;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new AffiliatePostbackDto
            {
                Id = entity.Id,
                AffiliateId = entity.AffiliateId,
                AffiliateName = entity.AffiliateName,
                Position = entity.Position,
                OfferId = entity.OfferId,
                EventType = entity.EventType,
                IntegrationType = entity.IntegrationType,
                Type = entity.Type,
                PostbackURL = entity.PostbackURL,
                Status = entity.Status,
                TriggerType = entity.TriggerType,
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = entity.ModifiedBy
            };
        }

        // ✅ Update Status
        public async Task<UpdatePostbackStatusDto?> UpdatePostbackStatus(UpdatePostbackStatusDto dto)
        {
            var entity = await _context.AffiliatePostbacks.FindAsync(dto.Id);

            if (entity == null) return null;

            entity.Status = dto.Status;
            entity.ModifiedBy = dto.ModifiedBy;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new UpdatePostbackStatusDto
            {
                Id = entity.Id,
                Status = entity.Status,
                ModifiedBy = entity.ModifiedBy
            };
        }

        // ✅ Delete (Soft Delete)
        public async Task<bool> DeletePostback(int id)
        {
            var entity = await _context.AffiliatePostbacks.FindAsync(id);

            if (entity == null) return false;

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}