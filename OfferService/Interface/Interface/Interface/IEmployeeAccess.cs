using Interface.DTOs;

namespace Interface.Interface
{
    public interface IEmployeeAccess
    {
        Task<IEnumerable<EmployeeAccessDTO>> GetAllAsync();

        Task<EmployeeAccessDTO?> GetByIdAsync(long id);

        Task<EmployeeAccessDTO> CreateAsync(CreateEmployeeAccessRequestDTO request);

        Task<bool> UpdateStatusAsync(long id, string status);

        Task<bool> DeleteAsync(long id);
    }
}
