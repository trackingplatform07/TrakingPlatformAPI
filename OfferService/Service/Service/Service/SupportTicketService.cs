using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class SupportTicketService : ISupportTicket
    {
        private readonly OfferCategoryDbContext _context;

        public SupportTicketService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static SupportTicketDTO ToDto(SupportTicket x) => new SupportTicketDTO
        {
            Id = x.Id,
            TicketNumber = x.TicketNumber,
            Subject = x.Subject,
            Type = x.Type,
            Query = x.Query,
            AttachmentFileName = x.AttachmentFileName,
            Status = x.Status,
            CreatedBy = x.CreatedBy,
            CreatedOn = x.CreatedOn,
            UpdatedOn = x.UpdatedOn
        };

        public async Task<IEnumerable<SupportTicketDTO>> GetAllAsync()
        {
            return await _context.SupportTickets
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<SupportTicketDTO> CreateAsync(CreateSupportTicketRequestDTO request)
        {
            var existingCount = await _context.SupportTickets.CountAsync();

            var entity = new SupportTicket
            {
                TicketNumber = 1000 + existingCount,
                Subject = request.Subject,
                Type = request.Type,
                Query = request.Query,
                AttachmentFileName = request.AttachmentFileName,
                Status = "Open",
                CreatedBy = string.IsNullOrWhiteSpace(request.CreatedBy) ? "Administrator" : request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            _context.SupportTickets.Add(entity);
            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
