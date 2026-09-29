using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IProductFeed
    {
        Task<IEnumerable<ProductFeedDTO>> GetAllAsync();

        Task<ProductFeedDTO?> GetByIdAsync(long id);

        Task<ProductFeedDTO> CreateAsync(ProductFeedDTO productFeed);

        Task<bool> UpdateAsync(long id, ProductFeedDTO productFeed);

        Task<bool> DeleteAsync(long id);
    }
}
