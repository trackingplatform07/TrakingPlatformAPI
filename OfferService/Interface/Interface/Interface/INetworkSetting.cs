using Interface.DTOs;

namespace Interface.Interface
{
    public interface INetworkSetting
    {
        Task<NetworkSettingDTO> GetAsync();

        Task<NetworkSettingDTO> UpdateAsync(NetworkSettingDTO settings);
    }
}
