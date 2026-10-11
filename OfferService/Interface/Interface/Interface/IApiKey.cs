using Interface.DTOs;

namespace Interface.Interface
{
    public interface IApiKey
    {
        Task<IEnumerable<ApiKeyDTO>> GetAllAsync();

        Task<ApiKeyDTO> CreateAsync(string? createdBy);

        Task<bool> UpdateWhitelistIpAsync(long id, string? whitelistIp);

        Task<bool> RevokeAsync(long id);
    }
}
