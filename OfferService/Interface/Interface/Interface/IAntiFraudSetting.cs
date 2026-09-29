using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IAntiFraudSetting
    {
        Task<IEnumerable<AntiFraudSettingDTO>> GetAllAsync();

        Task<AntiFraudSettingDTO?> GetByOfferIdAsync(long offerId);

        Task<AntiFraudSettingDTO?> GetByIdAsync(long id);

        Task<AntiFraudSettingDTO> CreateAsync(AntiFraudSettingDTO antiFraudSetting);

        Task<bool> UpdateAsync(long id, AntiFraudSettingDTO antiFraudSetting);

        Task<bool> DeleteAsync(long id);
    }
}
