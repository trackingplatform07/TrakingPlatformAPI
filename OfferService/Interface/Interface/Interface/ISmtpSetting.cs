using Interface.DTOs;

namespace Interface.Interface
{
    public interface ISmtpSetting
    {
        Task<IEnumerable<SmtpSettingDTO>> GetAllAsync();

        Task<SmtpSettingDTO?> GetByIdAsync(long id);

        Task<SmtpSettingDTO?> GetActiveAsync();

        Task<SmtpSettingDTO> CreateAsync(SmtpSettingDTO setting);

        Task<bool> UpdateAsync(long id, SmtpSettingDTO setting);

        Task<bool> DeleteAsync(long id);

        Task<SmtpConnectionTestResultDTO> TestConnectionAsync(SmtpSettingDTO setting);
    }
}
