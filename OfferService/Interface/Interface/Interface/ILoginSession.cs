using Interface.DTOs;

namespace Interface.Interface
{
    public interface ILoginSession
    {
        Task<IEnumerable<LoginSessionDTO>> GetAllAsync();

        Task<LoginSessionDTO> RecordAsync(string? userAgent, string? loginIp);

        Task LogoutAllAsync();
    }
}
