using Interface.DTOs;

namespace Interface.Interface
{
    public interface IMailerLog
    {
        Task<IEnumerable<MailerLogDTO>> GetAllAsync();

        Task<MailerLogDTO?> GetByIdAsync(long id);

        Task<MailerLogDTO> SendAsync(MailerLogDTO log);

        Task<bool> DeleteAsync(long id);
    }
}
