using Interface.DTOs;

namespace Interface.Interface
{
    public interface IAffiliateInvoice
    {
        Task<IEnumerable<AffiliateInvoiceDTO>> GetAllAsync();

        Task<AffiliateInvoiceDTO> CreateAsync(CreateAffiliateInvoiceRequestDTO request);

        Task<AffiliateInvoiceDTO> MarkPaidAsync(long id, string? modifiedBy);

        Task<AffiliateInvoiceDTO> UpdateNoteAsync(long id, UpdateAffiliateInvoiceNoteRequestDTO request);

        Task DeleteAsync(long id);
    }
}
