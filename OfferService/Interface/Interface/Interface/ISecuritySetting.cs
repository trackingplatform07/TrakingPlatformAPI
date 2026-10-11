using Interface.DTOs;

namespace Interface.Interface
{
    public interface ISecuritySetting
    {
        Task<SecuritySettingDTO> GetAsync();

        Task<bool> ChangePasswordAsync(ChangePasswordRequestDTO request);

        Task<SecuritySettingDTO> SetTwoFactorAsync(bool enabled, string? modifiedBy);
    }
}
