using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class ReferralService : IReferral
    {
        private readonly OfferCategoryDbContext _context;
        private readonly ICompanyProfile _companyProfile;

        public ReferralService(OfferCategoryDbContext context, ICompanyProfile companyProfile)
        {
            _context = context;
            _companyProfile = companyProfile;
        }

        private async Task<ReferralSetting> EnsureExistsAsync()
        {
            var entity = await _context.ReferralSettings.FirstOrDefaultAsync();

            if (entity == null)
            {
                entity = new ReferralSetting
                {
                    AffiliateDashboardVisible = false,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true
                };

                _context.ReferralSettings.Add(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<ReferralSummaryDTO> GetSummaryAsync()
        {
            var setting = await EnsureExistsAsync();
            var profile = await _companyProfile.GetAsync();

            var referredAccounts = await _context.ReferredAccounts
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.SignedUpOn)
                .Select(x => new ReferredAccountDTO
                {
                    Id = x.Id,
                    AccountName = x.AccountName,
                    Email = x.Email,
                    SignedUpOn = x.SignedUpOn,
                    Status = x.Status,
                    Profit = x.Profit,
                    PaidAmount = x.PaidAmount,
                    DueAmount = x.DueAmount
                })
                .ToListAsync();

            return new ReferralSummaryDTO
            {
                ReferralCode = profile.AccountId,
                ReferralLink = $"https://www.offer18.com/signup?r={profile.AccountId}",
                AffiliateDashboardVisible = setting.AffiliateDashboardVisible,
                ReferredUsers = referredAccounts.Count,
                TotalProfit = referredAccounts.Sum(x => x.Profit),
                PaidAmount = referredAccounts.Sum(x => x.PaidAmount),
                DueAmount = referredAccounts.Sum(x => x.DueAmount),
                ReferredAccounts = referredAccounts
            };
        }

        public async Task<ReferralSummaryDTO> SetAffiliateDashboardVisibilityAsync(SetAffiliateDashboardVisibilityRequestDTO request)
        {
            var setting = await EnsureExistsAsync();

            setting.AffiliateDashboardVisible = request.Visible;
            setting.ModifiedOn = DateTime.UtcNow;
            setting.ModifiedBy = request.ModifiedBy;

            await _context.SaveChangesAsync();

            return await GetSummaryAsync();
        }
    }
}
