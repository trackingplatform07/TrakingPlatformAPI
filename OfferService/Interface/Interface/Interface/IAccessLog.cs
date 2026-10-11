using Interface.DTOs;

namespace Interface.Interface
{
    public interface IAccessLog
    {
        Task<IEnumerable<AccessLogDTO>> QueryAsync(AccessLogQueryDTO query);
        Task<AccessLogDTO> CreateAsync(AccessLogDTO log);
    }
}
