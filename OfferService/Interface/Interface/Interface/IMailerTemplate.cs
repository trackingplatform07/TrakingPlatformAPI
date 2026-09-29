using Interface.DTOs;

namespace Interface.Interface
{
    public interface IMailerTemplate
    {
        Task<IEnumerable<MailerTemplateDTO>> GetAllAsync();

        Task<MailerTemplateDTO?> GetByIdAsync(long id);

        Task<MailerTemplateDTO> CreateAsync(MailerTemplateDTO template);

        Task<bool> UpdateAsync(long id, MailerTemplateDTO template);

        Task<bool> DeleteAsync(long id);
    }
}
