using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IEventSetting
    {
        Task<IEnumerable<EventSettingDTO>> GetAllAsync();

        Task<EventSettingDTO?> GetByOfferIdAsync(long offerId);

        Task<EventSettingDTO?> GetByIdAsync(long id);

        Task<EventSettingDTO> CreateAsync(EventSettingDTO eventSetting);

        Task<bool> UpdateAsync(long id, EventSettingDTO eventSetting);

        Task<bool> DeleteAsync(long id);
    }
}
