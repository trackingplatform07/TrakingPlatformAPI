using Interface.DTOs;

namespace Interface.Interface
{
    public interface IChangeLog
    {
        Task<IEnumerable<ChangeLogDTO>> QueryAsync(ChangeLogQueryDTO query);

        Task<ChangeLogDTO> CreateAsync(ChangeLogDTO log);
    }
}
