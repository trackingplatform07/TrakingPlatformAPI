using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ISuppressionList
    {
        Task<IEnumerable<SuppressionListDTO>> GetAllAsync();

        Task<IEnumerable<SuppressionListDTO>> GetByOfferIdAsync(long offerId);

        Task<SuppressionListDTO?> GetByIdAsync(long id);

        Task<SuppressionListDTO> CreateAsync(SuppressionListDTO suppressionList);

        Task<bool> UpdateAsync(long id, SuppressionListDTO suppressionList);

        Task<bool> DeleteAsync(long id);
    }
}
