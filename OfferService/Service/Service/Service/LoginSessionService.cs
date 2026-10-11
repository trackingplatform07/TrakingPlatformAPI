using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Security.Cryptography;

namespace Service.Services
{
    public class LoginSessionService : ILoginSession
    {
        private readonly OfferCategoryDbContext _context;

        public LoginSessionService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static LoginSessionDTO ToDto(LoginSession x) => new LoginSessionDTO
        {
            Id = x.Id,

            SessionId = x.SessionId,
            Status = x.Status,

            UserAgent = x.UserAgent,
            LoginIp = x.LoginIp,
            LoginOn = x.LoginOn,
            SignInCount = x.SignInCount,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<LoginSessionDTO>> GetAllAsync()
        {
            return await _context.LoginSessions
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.LoginOn)
                .Take(100)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<LoginSessionDTO> RecordAsync(string? userAgent, string? loginIp)
        {
            var existing = await _context.LoginSessions
                .Where(x => x.IsActive == true && x.Status == "Active" && x.UserAgent == userAgent && x.LoginIp == loginIp)
                .OrderByDescending(x => x.LoginOn)
                .FirstOrDefaultAsync();

            if (existing != null && existing.LoginOn > DateTime.UtcNow.AddMinutes(-30))
            {
                existing.SignInCount += 1;
                await _context.SaveChangesAsync();
                return ToDto(existing);
            }

            var entity = new LoginSession
            {
                SessionId = Convert.ToHexString(RandomNumberGenerator.GetBytes(16)).ToLowerInvariant(),
                Status = "Active",
                UserAgent = userAgent,
                LoginIp = loginIp,
                LoginOn = DateTime.UtcNow,
                SignInCount = 1,
                IsActive = true
            };

            _context.LoginSessions.Add(entity);

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task LogoutAllAsync()
        {
            var sessions = await _context.LoginSessions
                .Where(x => x.IsActive == true && x.Status == "Active")
                .ToListAsync();

            foreach (var session in sessions)
            {
                session.Status = "Logged Out";
            }

            await _context.SaveChangesAsync();
        }
    }
}
