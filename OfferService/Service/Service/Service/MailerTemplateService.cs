using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class MailerTemplateService : IMailerTemplate
    {
        private readonly OfferCategoryDbContext _context;

        public MailerTemplateService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static MailerTemplateDTO ToDto(MailerTemplate x) => new MailerTemplateDTO
        {
            Id = x.Id,

            Name = x.Name,
            Subject = x.Subject,
            Body = x.Body,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<MailerTemplateDTO>> GetAllAsync()
        {
            return await _context.MailerTemplates
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<MailerTemplateDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.MailerTemplates
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<MailerTemplateDTO> CreateAsync(MailerTemplateDTO dto)
        {
            var entity = new MailerTemplate
            {
                Name = dto.Name,
                Subject = dto.Subject,
                Body = dto.Body,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.MailerTemplates.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, MailerTemplateDTO dto)
        {
            var entity = await _context.MailerTemplates
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.Name = dto.Name;
            entity.Subject = dto.Subject;
            entity.Body = dto.Body;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.MailerTemplates
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
