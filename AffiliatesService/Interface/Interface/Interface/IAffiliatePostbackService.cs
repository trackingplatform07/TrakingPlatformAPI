using Interface.DTOs;

namespace Interface.Interface
{
    public interface IAffiliatePostbackService
    {
        // 🔹 Get All
        Task<List<AffiliatePostbackDto>> GetAllPostbacks();

        // 🔹 Get By Id
        Task<AffiliatePostbackDto?> GetPostbackById(int id);

        // 🔹 Create
        Task<AffiliatePostbackDto> CreatePostback(CreateAffiliatePostbackDto dto);

        // 🔹 Update
        Task<AffiliatePostbackDto?> UpdatePostback(int id, UpdateAffiliatePostbackDto dto);

        // 🔹 Update Status
        Task<UpdatePostbackStatusDto?> UpdatePostbackStatus(UpdatePostbackStatusDto dto);

        // 🔹 Delete (Soft Delete)
        Task<bool> DeletePostback(int id);
    }
}