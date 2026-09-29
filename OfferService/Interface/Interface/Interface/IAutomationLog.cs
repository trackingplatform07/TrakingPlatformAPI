using Interface.DTOs;

namespace Interface.Interface
{
    public interface IAutomationLog
    {
        Task<IEnumerable<AutomationLogDTO>> GetAllAsync(long? automationRuleId);

        Task<AutomationLogDTO?> GetByIdAsync(long id);

        Task<AutomationLogDTO> CreateAsync(AutomationLogDTO log);

        Task<bool> DeleteAsync(long id);
    }
}
