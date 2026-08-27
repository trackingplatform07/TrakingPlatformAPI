using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ITargetingRule
    {
        Task<IEnumerable<TargetingRuleDTO>> GetAllAsync();

        Task<TargetingRuleDTO?> GetByIdAsync(long id);

        Task<TargetingRuleDTO> CreateAsync(TargetingRuleDTO targetingRule);

        Task<bool> UpdateAsync(long id, TargetingRuleDTO targetingRule);

        Task<bool> DeleteAsync(long id);
    }
}
