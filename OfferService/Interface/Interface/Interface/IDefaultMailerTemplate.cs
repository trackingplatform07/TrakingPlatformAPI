using Interface.DTOs;

namespace Interface.Interface
{
    public interface IDefaultMailerTemplate
    {
        Task<IEnumerable<DefaultMailerTemplateDTO>> GetAllAsync();

        Task<DefaultMailerTemplateDTO?> GetByKeyAsync(string templateKey);

        Task<bool> UpdateAsync(string templateKey, DefaultMailerTemplateDTO template);

        Task<DefaultMailerTemplateDTO?> ResetAsync(string templateKey);

        Task<IEnumerable<DefaultMailerTemplateDTO>> ResetAllAsync();
    }
}
