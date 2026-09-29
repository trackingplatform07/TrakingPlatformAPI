using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IRetargetingTag
    {
        Task<IEnumerable<RetargetingTagDTO>> GetAllAsync();

        Task<RetargetingTagDTO?> GetByIdAsync(long id);

        Task<RetargetingTagDTO> CreateAsync(RetargetingTagDTO retargetingTag);

        Task<bool> UpdateAsync(long id, RetargetingTagDTO retargetingTag);

        Task<bool> DeleteAsync(long id);
    }
}
