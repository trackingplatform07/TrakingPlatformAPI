using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class EmployeeAccessService : IEmployeeAccess
    {
        private static readonly string[] AvatarPalette =
        {
            "#2f9e44", "#1f78d1", "#1a2a5e", "#e64980", "#f2b705", "#7048e8", "#0c8599", "#e8590c"
        };

        private readonly OfferCategoryDbContext _context;

        public EmployeeAccessService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static EmployeeAccessDTO ToDto(EmployeeAccess x) => new EmployeeAccessDTO
        {
            Id = x.Id,

            Tag = x.Tag,

            Name = x.Name,
            Email = x.Email,

            LastLoginOn = x.LastLoginOn,

            PermissionsCount = x.PermissionsCount,

            Status = x.Status,

            AvatarColor = x.AvatarColor,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<EmployeeAccessDTO>> GetAllAsync()
        {
            return await _context.EmployeeAccesses
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<EmployeeAccessDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.EmployeeAccesses
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<EmployeeAccessDTO> CreateAsync(CreateEmployeeAccessRequestDTO request)
        {
            var random = new Random();
            var entity = new EmployeeAccess
            {
                Tag = "Custom",
                Email = request.Email.Trim(),
                Status = "Active",
                PermissionsCount = null,
                AvatarColor = AvatarPalette[random.Next(AvatarPalette.Length)],
                CreatedOn = DateTime.UtcNow,
                CreatedBy = request.CreatedBy,
                IsActive = true
            };

            _context.EmployeeAccesses.Add(entity);

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<bool> UpdateStatusAsync(long id, string status)
        {
            var entity = await _context.EmployeeAccesses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.Status = status;
            entity.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.EmployeeAccesses
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
