using Interface.DTOs;

namespace Interface.Interface
{
    public interface ISupportTicket
    {
        Task<IEnumerable<SupportTicketDTO>> GetAllAsync();

        Task<SupportTicketDTO> CreateAsync(CreateSupportTicketRequestDTO request);
    }
}
