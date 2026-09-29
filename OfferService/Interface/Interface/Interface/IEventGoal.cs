using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IEventGoal
    {
        Task<IEnumerable<EventGoalDTO>> GetAllAsync();

        Task<IEnumerable<EventGoalDTO>> GetByOfferIdAsync(long offerId);

        Task<EventGoalDTO?> GetByIdAsync(long id);

        Task<EventGoalDTO> CreateAsync(EventGoalDTO eventGoal);

        Task<bool> UpdateAsync(long id, EventGoalDTO eventGoal);

        Task<bool> DeleteAsync(long id);
    }
}
