using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Net.Sockets;

namespace Service.Services
{
    public class SmtpSettingService : ISmtpSetting
    {
        private readonly OfferCategoryDbContext _context;

        public SmtpSettingService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static SmtpSettingDTO ToDto(SmtpSetting x) => new SmtpSettingDTO
        {
            Id = x.Id,

            Host = x.Host,
            Port = x.Port,
            Username = x.Username,
            Password = x.Password,
            FromEmail = x.FromEmail,
            FromName = x.FromName,
            UseSsl = x.UseSsl,
            EncryptionMode = x.EncryptionMode,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<SmtpSettingDTO>> GetAllAsync()
        {
            return await _context.SmtpSettings
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<SmtpSettingDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.SmtpSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<SmtpSettingDTO?> GetActiveAsync()
        {
            var entity = await _context.SmtpSettings
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.ModifiedOn ?? x.CreatedOn)
                .FirstOrDefaultAsync();

            return entity == null ? null : ToDto(entity);
        }

        public async Task<SmtpSettingDTO> CreateAsync(SmtpSettingDTO dto)
        {
            var entity = new SmtpSetting
            {
                Host = dto.Host,
                Port = dto.Port,
                Username = dto.Username,
                Password = dto.Password,
                FromEmail = dto.FromEmail,
                FromName = dto.FromName,
                UseSsl = dto.UseSsl,
                EncryptionMode = dto.EncryptionMode,

                CreatedOn = dto.CreatedOn ?? DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,

                ModifiedOn = dto.ModifiedOn,
                ModifiedBy = dto.ModifiedBy,

                IsActive = dto.IsActive ?? true
            };

            _context.SmtpSettings.Add(entity);

            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsActive = entity.IsActive;

            return dto;
        }

        public async Task<bool> UpdateAsync(long id, SmtpSettingDTO dto)
        {
            var entity = await _context.SmtpSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.Host = dto.Host;
            entity.Port = dto.Port;
            entity.Username = dto.Username;
            entity.Password = dto.Password;
            entity.FromEmail = dto.FromEmail;
            entity.FromName = dto.FromName;
            entity.UseSsl = dto.UseSsl;
            entity.EncryptionMode = dto.EncryptionMode;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.SmtpSettings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SmtpConnectionTestResultDTO> TestConnectionAsync(SmtpSettingDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Host))
                return new SmtpConnectionTestResultDTO { Success = false, Message = "Please enter an SMTP host." };

            try
            {
                using var client = new TcpClient();
                var connectTask = client.ConnectAsync(dto.Host, dto.Port);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(8));

                var completed = await Task.WhenAny(connectTask, timeoutTask);
                if (completed == timeoutTask || !client.Connected)
                    return new SmtpConnectionTestResultDTO { Success = false, Message = $"Timed out connecting to {dto.Host}:{dto.Port}." };

                return new SmtpConnectionTestResultDTO { Success = true, Message = $"Successfully connected to {dto.Host}:{dto.Port}." };
            }
            catch (Exception ex)
            {
                return new SmtpConnectionTestResultDTO { Success = false, Message = ex.Message };
            }
        }
    }
}
