using Interface.DTOs;

namespace Interface.Interface
{
    public interface ICompanyProfile
    {
        Task<CompanyProfileDTO> GetAsync();

        Task<CompanyProfileDTO> UpdateAsync(CompanyProfileDTO request);

        Task<CompanyProfileDTO> ChangeEmailAsync(ChangeAccountEmailRequestDTO request);

        Task<CompanyProfileDTO> RegenerateSecretKeyAsync(string? regeneratedBy);
    }
}
