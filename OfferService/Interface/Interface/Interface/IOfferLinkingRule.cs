using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IOfferLinkingRule
    {
        Task<IEnumerable<OfferLinkingRuleDTO>> GetAllAsync();

        Task<OfferLinkingRuleDTO?> GetByIdAsync(long id);

        Task<OfferLinkingRuleDTO> CreateAsync(OfferLinkingRuleDTO rule);

        Task<bool> UpdateAsync(long id, OfferLinkingRuleDTO rule);

        Task<bool> DeleteAsync(long id);
    }
}
