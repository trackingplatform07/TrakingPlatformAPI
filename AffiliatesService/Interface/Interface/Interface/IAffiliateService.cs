using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.DTOs;


namespace Interface.Interface
{
    public interface IAffiliateService
    {
        Task<List<AffiliateDto>> GetAllAffiliates();
        Task<AffiliateDto?> GetAffiliateById(int id);
        Task<AffiliateDto> CreateAffiliate(AffiliateDto dto);
        Task<UpdateAffiliateDto?> UpdateAffiliate(int id, UpdateAffiliateDto dto);
        Task<UpdateAffiliateStausDto?> UpdateAffiliateStaus(int id, UpdateAffiliateStausDto dto);
        Task<bool> DeleteAffiliate(int id);
    }
}
