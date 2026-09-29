using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class DefaultMailerTemplateService : IDefaultMailerTemplate
    {
        private readonly OfferCategoryDbContext _context;

        public DefaultMailerTemplateService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static readonly (string Key, string Label, int Order, string Subject, string Body)[] Defaults = new[]
        {
            ("affiliate-signup", "Affiliate Signup", 1,
                "Your account has been registered - {network_name}",
                "Hi {firstname},\n\nWelcome to {network_name}.\n\nTo access your affiliate account, use the following login credentials:\n\n{network_url}\nE-mail: {email}\nPassword: {password}\n\nYour Account Status is {status}.\n\n\nSincerely,\n{network_name}"),
            ("affiliate-reject", "Affiliate Reject", 2,
                "Your affiliate application was not approved - {network_name}",
                "Hi {firstname},\n\nThank you for applying to {network_name}.\n\nUnfortunately your affiliate application has been rejected.\n\nYour Account Status is {status}.\n\n\nSincerely,\n{network_name}"),
            ("affiliate-approve", "Affiliate Approve", 3,
                "Your affiliate account has been approved - {network_name}",
                "Hi {firstname},\n\nGreat news! Your affiliate account with {network_name} has been approved.\n\n{network_url}\nE-mail: {email}\n\nYour Account Status is {status}.\n\n\nSincerely,\n{network_name}"),
            ("advertiser-signup", "Advertiser Signup", 4,
                "Your account has been registered - {network_name}",
                "Hi {firstname},\n\nWelcome to {network_name}.\n\nTo access your advertiser account, use the following login credentials:\n\n{network_url}\nE-mail: {email}\nPassword: {password}\n\nYour Account Status is {status}.\n\n\nSincerely,\n{network_name}"),
            ("advertiser-reject", "Advertiser Reject", 5,
                "Your advertiser application was not approved - {network_name}",
                "Hi {firstname},\n\nThank you for applying to {network_name}.\n\nUnfortunately your advertiser application has been rejected.\n\nYour Account Status is {status}.\n\n\nSincerely,\n{network_name}"),
            ("advertiser-approve", "Advertiser Approve", 6,
                "Your advertiser account has been approved - {network_name}",
                "Hi {firstname},\n\nGreat news! Your advertiser account with {network_name} has been approved.\n\n{network_url}\nE-mail: {email}\n\nYour Account Status is {status}.\n\n\nSincerely,\n{network_name}"),
            ("password-reset", "Password Reset", 7,
                "Reset your password - {network_name}",
                "Hi {firstname},\n\nWe received a request to reset your password for {network_name}.\n\nClick the link below to reset it:\n{reset_url}\n\nIf you did not request this, please ignore this email.\n\n\nSincerely,\n{network_name}"),
            ("offer-approve", "Offer Approve", 8,
                "Your offer request has been approved - {network_name}",
                "Hi {firstname},\n\nYour request for offer {offer_name} has been approved.\n\n{network_url}\n\n\nSincerely,\n{network_name}"),
            ("offer-reject", "Offer Reject", 9,
                "Your offer request has been rejected - {network_name}",
                "Hi {firstname},\n\nYour request for offer {offer_name} has been rejected.\n\n\nSincerely,\n{network_name}"),
            ("offer-change", "Offer Change", 10,
                "An offer you are running has been updated - {network_name}",
                "Hi {firstname},\n\nThe offer {offer_name} has been updated. Please review the latest terms.\n\n{network_url}\n\n\nSincerely,\n{network_name}"),
            ("affiliate-invoice", "Affiliate Invoice", 11,
                "Your invoice is ready - {network_name}",
                "Hi {firstname},\n\nYour invoice {invoice_number} for {invoice_amount} is now available.\n\n{network_url}\n\n\nSincerely,\n{network_name}"),
            ("advertiser-invoice", "Advertiser Invoice", 12,
                "Your invoice is ready - {network_name}",
                "Hi {firstname},\n\nYour invoice {invoice_number} for {invoice_amount} is now available.\n\n{network_url}\n\n\nSincerely,\n{network_name}"),
        };

        private static DefaultMailerTemplateDTO ToDto(DefaultMailerTemplate x) => new DefaultMailerTemplateDTO
        {
            Id = x.Id,

            TemplateKey = x.TemplateKey,
            Label = x.Label,
            SortOrder = x.SortOrder,

            Subject = x.Subject,
            Body = x.Body,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        private async Task EnsureSeededAsync()
        {
            var existingKeys = await _context.DefaultMailerTemplates
                .Select(x => x.TemplateKey)
                .ToListAsync();

            var missing = Defaults.Where(d => !existingKeys.Contains(d.Key)).ToList();
            if (missing.Count == 0) return;

            foreach (var d in missing)
            {
                _context.DefaultMailerTemplates.Add(new DefaultMailerTemplate
                {
                    TemplateKey = d.Key,
                    Label = d.Label,
                    SortOrder = d.Order,
                    Subject = d.Subject,
                    Body = d.Body,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DefaultMailerTemplateDTO>> GetAllAsync()
        {
            await EnsureSeededAsync();

            return await _context.DefaultMailerTemplates
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.SortOrder)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<DefaultMailerTemplateDTO?> GetByKeyAsync(string templateKey)
        {
            await EnsureSeededAsync();

            var entity = await _context.DefaultMailerTemplates
                .FirstOrDefaultAsync(x => x.TemplateKey == templateKey);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<bool> UpdateAsync(string templateKey, DefaultMailerTemplateDTO dto)
        {
            var entity = await _context.DefaultMailerTemplates
                .FirstOrDefaultAsync(x => x.TemplateKey == templateKey);

            if (entity == null)
                return false;

            entity.Subject = dto.Subject;
            entity.Body = dto.Body;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<DefaultMailerTemplateDTO?> ResetAsync(string templateKey)
        {
            var entity = await _context.DefaultMailerTemplates
                .FirstOrDefaultAsync(x => x.TemplateKey == templateKey);

            var defaultDef = Defaults.FirstOrDefault(d => d.Key == templateKey);
            if (entity == null || defaultDef.Key == null)
                return null;

            entity.Subject = defaultDef.Subject;
            entity.Body = defaultDef.Body;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<IEnumerable<DefaultMailerTemplateDTO>> ResetAllAsync()
        {
            await EnsureSeededAsync();

            var entities = await _context.DefaultMailerTemplates
                .Where(x => x.IsActive == true)
                .ToListAsync();

            foreach (var entity in entities)
            {
                var defaultDef = Defaults.FirstOrDefault(d => d.Key == entity.TemplateKey);
                if (defaultDef.Key == null) continue;

                entity.Subject = defaultDef.Subject;
                entity.Body = defaultDef.Body;
                entity.ModifiedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            return entities.OrderBy(x => x.SortOrder).Select(ToDto);
        }
    }
}
