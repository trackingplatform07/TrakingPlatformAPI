using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class BillingInvoiceService : IBillingInvoice
    {
        private readonly OfferCategoryDbContext _context;

        public BillingInvoiceService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static BillingInvoiceDTO ToDto(BillingInvoice x) => new BillingInvoiceDTO
        {
            Id = x.Id,

            InvoiceNumber = x.InvoiceNumber,
            Type = x.Type,
            InvoiceDate = x.InvoiceDate,

            Status = x.Status,
            Amount = x.Amount,

            PaymentDate = x.PaymentDate,
            PaymentMethod = x.PaymentMethod,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            IsActive = x.IsActive
        };

        public async Task<IEnumerable<BillingInvoiceDTO>> GetAllAsync()
        {
            return await _context.BillingInvoices
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.InvoiceDate)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<BillingInvoiceDTO?> MarkPaidAsync(long id)
        {
            var entity = await _context.BillingInvoices
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return null;

            entity.Status = "Paid";
            entity.PaymentDate = DateTime.UtcNow;
            entity.PaymentMethod = "Manual";

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
