using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ILandingPage
    {
        Task<IEnumerable<LandingPageDTO>> GetAllAsync();

        Task<LandingPageDTO?> GetByIdAsync(long id);

        Task<LandingPageDTO> CreateAsync(LandingPageDTO dto);

        Task<bool> UpdateAsync(long id, LandingPageDTO dto);

        Task<bool> DeleteAsync(long id);
    }
}
