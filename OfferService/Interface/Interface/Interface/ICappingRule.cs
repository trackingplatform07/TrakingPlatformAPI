using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ICappingRule
    {
        Task<IEnumerable<CappingRuleDTO>> GetAllAsync();

        Task<IEnumerable<CappingRuleDTO>> GetByOfferIdAsync(long offerId);

        Task<CappingRuleDTO?> GetByIdAsync(long id);

        Task<CappingRuleDTO> CreateAsync(CappingRuleDTO cappingRule);

        Task<bool> UpdateAsync(long id, CappingRuleDTO cappingRule);

        Task<bool> DeleteAsync(long id);
    }
}
