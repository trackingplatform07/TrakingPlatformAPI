using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Net;
using System.Net.Mail;

namespace Service.Services
{
    public class MailerLogService : IMailerLog
    {
        private readonly OfferCategoryDbContext _context;

        public MailerLogService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static MailerLogDTO ToDto(MailerLog x) => new MailerLogDTO
        {
            Id = x.Id,

            AdvertiserId = x.AdvertiserId,
            AffiliateId = x.AffiliateId,

            BulkAdvertiserStatus = x.BulkAdvertiserStatus,
            BulkAffiliateStatus = x.BulkAffiliateStatus,

            AdvertiserCountry = x.AdvertiserCountry,
            AffiliateCountry = x.AffiliateCountry,

            Recipients = x.Recipients,
            Cc = x.Cc,
            Bcc = x.Bcc,

            Schedule = x.Schedule,
            ScheduledOn = x.ScheduledOn,

            TemplateId = x.TemplateId,
            Subject = x.Subject,
            Body = x.Body,

            RecipientCount = x.RecipientCount,

            Status = x.Status,
            ErrorMessage = x.ErrorMessage,

            SentOn = x.SentOn,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<MailerLogDTO>> GetAllAsync()
        {
            return await _context.MailerLogs
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<MailerLogDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.MailerLogs
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<MailerLogDTO> SendAsync(MailerLogDTO dto)
        {
            var entity = new MailerLog
            {
                AdvertiserId = dto.AdvertiserId,
                AffiliateId = dto.AffiliateId,

                BulkAdvertiserStatus = dto.BulkAdvertiserStatus,
                BulkAffiliateStatus = dto.BulkAffiliateStatus,

                AdvertiserCountry = dto.AdvertiserCountry,
                AffiliateCountry = dto.AffiliateCountry,

                Recipients = dto.Recipients,
                Cc = dto.Cc,
                Bcc = dto.Bcc,

                Schedule = dto.Schedule,
                ScheduledOn = dto.ScheduledOn,

                TemplateId = dto.TemplateId,
                Subject = dto.Subject,
                Body = dto.Body,

                RecipientCount = dto.RecipientCount,

                CreatedOn = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                IsActive = true
            };

            if (string.Equals(dto.Schedule, "Schedule Later", StringComparison.OrdinalIgnoreCase) && dto.ScheduledOn.HasValue)
            {
                entity.Status = "Scheduled";
            }
            else
            {
                var recipientList = (dto.Recipients ?? string.Empty)
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList();

                if (recipientList.Count == 0)
                {
                    entity.Status = "Failed";
                    entity.ErrorMessage = "No recipients resolved for the selected advertiser/affiliate/email filters.";
                }
                else
                {
                    var smtp = await _context.SmtpSettings
                        .Where(x => x.IsActive == true)
                        .OrderByDescending(x => x.ModifiedOn ?? x.CreatedOn)
                        .FirstOrDefaultAsync();

                    if (smtp == null)
                    {
                        entity.Status = "Logged (No SMTP Configured)";
                        entity.ErrorMessage = "No SMTP settings configured yet — the send was logged but no email was dispatched.";
                    }
                    else
                    {
                        try
                        {
                            using var client = new SmtpClient(smtp.Host, smtp.Port)
                            {
                                EnableSsl = smtp.UseSsl,
                                Credentials = string.IsNullOrWhiteSpace(smtp.Username)
                                    ? null
                                    : new NetworkCredential(smtp.Username, smtp.Password)
                            };

                            using var message = new MailMessage
                            {
                                From = new MailAddress(smtp.FromEmail ?? smtp.Username ?? "no-reply@offer18.com", smtp.FromName ?? "Offer18"),
                                Subject = dto.Subject ?? string.Empty,
                                Body = dto.Body ?? string.Empty,
                                IsBodyHtml = true
                            };

                            foreach (var address in recipientList) message.To.Add(address);
                            foreach (var address in (dto.Cc ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) message.CC.Add(address);
                            foreach (var address in (dto.Bcc ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) message.Bcc.Add(address);

                            await client.SendMailAsync(message);

                            entity.Status = "Sent";
                            entity.SentOn = DateTime.UtcNow;
                        }
                        catch (Exception ex)
                        {
                            entity.Status = "Failed";
                            entity.ErrorMessage = ex.Message;
                        }
                    }
                }
            }

            _context.MailerLogs.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.Status = entity.Status;
            dto.ErrorMessage = entity.ErrorMessage;
            dto.SentOn = entity.SentOn;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.MailerLogs
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.IsActive = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
