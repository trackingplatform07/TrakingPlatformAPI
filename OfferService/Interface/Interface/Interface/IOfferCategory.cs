using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IOfferCategory
    {
        Task<List<OfferCategoryDto>> GetAllOfferCategories();

        Task<OfferCategoryDto> GetOfferCategoryById(int id);

        Task<OfferCategoryDto> CreateOfferCategory(OfferCategoryDto dto);

        Task<OfferCategoryDto> UpdateOfferCategory(int id, OfferCategoryDto dto);

        Task<bool> DeleteOfferCategory(int id);
    }
}
