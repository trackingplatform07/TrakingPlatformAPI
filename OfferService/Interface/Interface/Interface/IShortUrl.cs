using Interface.DTOs;

namespace Interface.Interface
{
    public interface IShortUrl
    {
        Task<IEnumerable<ShortUrlDTO>> GetAllAsync();

        Task<ShortUrlDTO?> GetByIdAsync(long id);

        Task<ShortUrlDTO?> GetByCodeAsync(string code);

        Task<ShortUrlDTO> CreateAsync(CreateShortUrlDTO request);

        Task<bool> UpdateStatusAsync(long id, string status);

        Task<bool> DeleteAsync(long id);
    }
}
