using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ICreative
    {
        Task<IEnumerable<CreativeDTO>> GetAllAsync();

        Task<CreativeDTO?> GetByIdAsync(long id);

        Task<CreativeDTO> CreateAsync(CreativeDTO dto);

        Task<bool> UpdateAsync(long id, CreativeDTO dto);

        Task<bool> DeleteAsync(long id);
    }
}
