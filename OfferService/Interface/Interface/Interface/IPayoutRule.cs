using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IPayoutRule
    {
        Task<IEnumerable<PayoutRuleDTO>> GetAllAsync();

        Task<IEnumerable<PayoutRuleDTO>> GetByOfferIdAsync(long offerId);

        Task<PayoutRuleDTO?> GetByIdAsync(long id);

        Task<PayoutRuleDTO> CreateAsync(PayoutRuleDTO payoutRule);

        Task<bool> UpdateAsync(long id, PayoutRuleDTO payoutRule);

        Task<bool> DeleteAsync(long id);
    }
}
