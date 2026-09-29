using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IFallbackIntegration
    {
        Task<IEnumerable<FallbackIntegrationDTO>> GetAllAsync();

        Task<FallbackIntegrationDTO?> GetByOfferIdAsync(long offerId);

        Task<FallbackIntegrationDTO?> GetByIdAsync(long id);

        Task<FallbackIntegrationDTO> CreateAsync(FallbackIntegrationDTO fallbackIntegration);

        Task<bool> UpdateAsync(long id, FallbackIntegrationDTO fallbackIntegration);

        Task<bool> DeleteAsync(long id);
    }
}
