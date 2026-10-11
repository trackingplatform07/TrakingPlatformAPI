using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Security.Cryptography;

namespace Service.Services
{
    public class AffiliateInvoiceService : IAffiliateInvoice
    {
        private readonly OfferCategoryDbContext _context;

        public AffiliateInvoiceService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static AffiliateInvoiceDTO ToDto(AffiliateInvoice x) => new AffiliateInvoiceDTO
        {
            Id = x.Id,
            InvoiceNumber = x.InvoiceNumber,
            AffiliateId = x.AffiliateId,
            AffiliateName = x.AffiliateName,
            PeriodStart = x.PeriodStart,
            PeriodEnd = x.PeriodEnd,
            InvoiceDate = x.InvoiceDate,
            DueDate = x.DueDate,
            PaymentDate = x.PaymentDate,
            TimezoneOffset = x.TimezoneOffset,
            TotalAmount = x.TotalAmount,
            Currency = x.Currency,
            Status = x.Status,
            Note = x.Note
        };

        private static string GenerateInvoiceNumber(DateTime invoiceDate)
        {
            var suffix = RandomNumberGenerator.GetInt32(1000, 9999);
            return $"INV-{invoiceDate:yyyyMMdd}-{suffix}";
        }

        public async Task<IEnumerable<AffiliateInvoiceDTO>> GetAllAsync()
        {
            return await _context.AffiliateInvoices
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.InvoiceDate)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<AffiliateInvoiceDTO> CreateAsync(CreateAffiliateInvoiceRequestDTO request)
        {
            var now = DateTime.UtcNow;

            var entity = new AffiliateInvoice
            {
                InvoiceNumber = GenerateInvoiceNumber(now),
                AffiliateId = request.AffiliateId,
                AffiliateName = request.AffiliateName,
                PeriodStart = request.PeriodStart,
                PeriodEnd = request.PeriodEnd,
                InvoiceDate = now,
                DueDate = request.DueDate,
                TimezoneOffset = string.IsNullOrWhiteSpace(request.TimezoneOffset) ? "+0:00" : request.TimezoneOffset,
                TotalAmount = request.TotalAmount,
                Currency = string.IsNullOrWhiteSpace(request.Currency) ? "USD" : request.Currency,
                Status = "Pending",
                Note = request.Note,
                CreatedOn = now,
                CreatedBy = request.CreatedBy,
                IsActive = true
            };

            _context.AffiliateInvoices.Add(entity);
            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<AffiliateInvoiceDTO> MarkPaidAsync(long id, string? modifiedBy)
        {
            var entity = await _context.AffiliateInvoices.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("Invoice not found.");

            entity.Status = "Paid";
            entity.PaymentDate = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<AffiliateInvoiceDTO> UpdateNoteAsync(long id, UpdateAffiliateInvoiceNoteRequestDTO request)
        {
            var entity = await _context.AffiliateInvoices.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("Invoice not found.");

            entity.Note = request.Note;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = request.ModifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.AffiliateInvoices.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("Invoice not found.");

            entity.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
