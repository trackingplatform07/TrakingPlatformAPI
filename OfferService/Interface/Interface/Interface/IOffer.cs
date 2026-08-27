using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IOffer
    {
        Task<List<OfferDto>> GetAllOffers();

        Task<OfferDto> GetOfferById(int id);

        Task<OfferDto> CreateOffer(OfferDto dto);

        Task<OfferDto> UpdateOffer(int id, OfferDto dto);

        Task<bool> DeleteOffer(int id);
    }
}
