using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IAutomationRule
    {
        Task<IEnumerable<AutomationRuleDTO>> GetAllAsync();

        Task<IEnumerable<AutomationRuleDTO>> GetByOfferIdAsync(long offerId);

        Task<AutomationRuleDTO?> GetByIdAsync(long id);

        Task<AutomationRuleDTO> CreateAsync(AutomationRuleDTO automationRule);

        Task<bool> UpdateAsync(long id, AutomationRuleDTO automationRule);

        Task<bool> DeleteAsync(long id);
    }
}
