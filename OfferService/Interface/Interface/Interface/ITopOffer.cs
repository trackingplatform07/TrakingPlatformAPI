using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ITopOffer
    {
        Task<IEnumerable<TopOfferDTO>> GetAllAsync();

        Task<TopOfferDTO?> GetByIdAsync(long id);

        Task<TopOfferDTO> CreateAsync(TopOfferDTO topOffer);

        Task<bool> UpdateAsync(long id, TopOfferDTO topOffer);

        Task<bool> DeleteAsync(long id);
    }
}
