using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System.Net.Http;
using System.Text;

namespace Service.Services
{
    public class LinkTestResultService : ILinkTestResult
    {
        private readonly OfferCategoryDbContext _context;

        public LinkTestResultService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static LinkTestResultDTO ToDto(LinkTestResult x) => new LinkTestResultDTO
        {
            Id = x.Id,

            RuleId = x.RuleId,

            Url = x.Url,
            OsDevice = x.OsDevice,
            Country = x.Country,

            FinalStatusCode = x.FinalStatusCode,
            RedirectCount = x.RedirectCount,
            ResultText = x.ResultText,

            Status = x.Status,

            StartedOn = x.StartedOn,
            FinishedOn = x.FinishedOn,

            CreatedBy = x.CreatedBy,
            IsActive = x.IsActive
        };

        public async Task<IEnumerable<LinkTestResultDTO>> GetAllAsync(long? ruleId)
        {
            var query = _context.LinkTestResults.Where(x => x.IsActive == true);

            if (ruleId.HasValue)
                query = query.Where(x => x.RuleId == ruleId.Value);

            return await query
                .OrderByDescending(x => x.StartedOn)
                .Select(x => ToDto(x))
                .ToListAsync();
        }

        public async Task<LinkTestResultDTO?> GetByIdAsync(long id)
        {
            var entity = await _context.LinkTestResults
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : ToDto(entity);
        }

        public async Task<LinkTestResultDTO> RunTestAsync(LinkTestRunRequestDTO request)
        {
            var startedOn = DateTime.UtcNow;
            var chain = new StringBuilder();
            var status = "Failed";
            int? finalStatusCode = null;
            var redirectCount = 0;
            var currentUrl = request.Url;

            using var handler = new HttpClientHandler { AllowAutoRedirect = false };
            using var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Offer18-LinkTester/1.0");

            try
            {
                for (var hop = 1; hop <= 10; hop++)
                {
                    using var httpResponse = await client.GetAsync(currentUrl);
                    finalStatusCode = (int)httpResponse.StatusCode;
                    chain.AppendLine($"{hop}. [{finalStatusCode}] {currentUrl}");

                    var isRedirect = finalStatusCode is >= 300 and < 400;
                    Uri? location = httpResponse.Headers.Location;

                    if (isRedirect && location != null)
                    {
                        Uri resolvedUri = location.IsAbsoluteUri ? location : new Uri(new Uri(currentUrl), location);
                        currentUrl = resolvedUri.AbsoluteUri;
                        redirectCount++;
                        continue;
                    }

                    break;
                }

                status = finalStatusCode is >= 200 and < 300 ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                chain.AppendLine($"Error: {ex.Message}");
                status = "Error";
            }

            var entity = new LinkTestResult
            {
                RuleId = request.RuleId,
                Url = request.Url,
                OsDevice = request.OsDevice,
                Country = request.Country,

                FinalStatusCode = finalStatusCode,
                RedirectCount = redirectCount,
                ResultText = chain.ToString().TrimEnd(),

                Status = status,

                StartedOn = startedOn,
                FinishedOn = DateTime.UtcNow,

                CreatedBy = request.CreatedBy,
                IsActive = true
            };

            _context.LinkTestResults.Add(entity);

            if (request.RuleId.HasValue)
            {
                var rule = await _context.LinkTesterRules.FirstOrDefaultAsync(x => x.Id == request.RuleId.Value);
                if (rule != null)
                {
                    rule.LastCheck = DateTime.UtcNow;
                    rule.Health = status == "Success" ? "Healthy" : "Unhealthy";
                    rule.ModifiedOn = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.LinkTestResults
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            entity.IsActive = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
