using Interface.DTOs;

namespace Interface.Interface
{
    public interface ILinkTestResult
    {
        Task<IEnumerable<LinkTestResultDTO>> GetAllAsync(long? ruleId, string? source);

        Task<LinkTestResultDTO?> GetByIdAsync(long id);

        Task<LinkTestResultDTO> RunTestAsync(LinkTestRunRequestDTO request);

        Task<bool> DeleteAsync(long id);
    }
}
