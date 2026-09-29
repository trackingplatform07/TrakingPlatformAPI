using Interface.DTOs;

namespace Interface.Interface
{
    public interface ILinkTesterRule
    {
        Task<IEnumerable<LinkTesterRuleDTO>> GetAllAsync();

        Task<LinkTesterRuleDTO?> GetByIdAsync(long id);

        Task<LinkTesterRuleDTO> CreateAsync(LinkTesterRuleDTO rule);

        Task<bool> UpdateAsync(long id, LinkTesterRuleDTO rule);

        Task<bool> DeleteAsync(long id);
    }
}
