using Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ITopOfferMailerLog
    {
        Task<IEnumerable<TopOfferMailerLogDTO>> GetAllAsync();

        Task<TopOfferMailerLogDTO?> GetByIdAsync(long id);

        Task<TopOfferMailerLogDTO> CreateAsync(TopOfferMailerLogDTO mailerLog);

        Task<bool> DeleteAsync(long id);
    }
}
