using Interface.DTOs;

namespace Interface.Interface
{
    public interface IBillingInvoice
    {
        Task<IEnumerable<BillingInvoiceDTO>> GetAllAsync();

        Task<BillingInvoiceDTO?> MarkPaidAsync(long id);
    }
}
