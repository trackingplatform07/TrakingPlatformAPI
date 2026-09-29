using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ICoupon
    {
        Task<IEnumerable<CouponDTO>> GetAllAsync();

        Task<IEnumerable<CouponDTO>> GetByOfferIdAsync(long offerId);

        Task<CouponDTO?> GetByIdAsync(long id);

        Task<CouponDTO> CreateAsync(CouponDTO coupon);

        Task<bool> UpdateAsync(long id, CouponDTO coupon);

        Task<bool> DeleteAsync(long id);
    }
}
