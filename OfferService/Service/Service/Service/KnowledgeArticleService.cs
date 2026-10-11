using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class KnowledgeArticleService : IKnowledgeArticle
    {
        private readonly OfferCategoryDbContext _context;

        public KnowledgeArticleService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static KnowledgeArticleDTO ToDto(KnowledgeArticle x) => new KnowledgeArticleDTO
        {
            Id = x.Id,
            Category = x.Category,
            Title = x.Title,
            Summary = x.Summary,
            Content = x.Content,
            CreatedOn = x.CreatedOn
        };

        private async Task EnsureSeededAsync()
        {
            if (await _context.KnowledgeArticles.AnyAsync()) return;

            var now = DateTime.UtcNow;

            _context.KnowledgeArticles.AddRange(
                new KnowledgeArticle
                {
                    Category = "Getting Started",
                    Title = "Creating your first offer",
                    Summary = "Step-by-step guide to creating and publishing an offer.",
                    Content = "Go to Offers > Create Offer, fill in the offer name, category, payout rules and targeting, then save to publish it. You can track its performance from Offers - Live.",
                    CreatedOn = now,
                    IsActive = true
                },
                new KnowledgeArticle
                {
                    Category = "Billing",
                    Title = "Understanding your subscription plan",
                    Summary = "How to view usage, change your plan, and manage addons.",
                    Content = "Open Billing > Subscription Plan to see your current plan, conversion/click/impression limits, and active addons. Use Change Plan to upgrade or downgrade, and Manage Addons to add extra services.",
                    CreatedOn = now,
                    IsActive = true
                },
                new KnowledgeArticle
                {
                    Category = "Billing",
                    Title = "Setting up bank transfer (NEFT/RTGS) details",
                    Summary = "Add your bank account details so invoices can be paid via bank transfer.",
                    Content = "From the Billing page, click Bank Transfer (NEFT/RTGS) Details and enter your bank name, account holder, account number and IFSC/SWIFT code.",
                    CreatedOn = now,
                    IsActive = true
                },
                new KnowledgeArticle
                {
                    Category = "Account",
                    Title = "Managing employee access",
                    Summary = "Invite employees and control their access.",
                    Content = "Go to Account > Employee and click + Create Employee to invite a teammate by email. You can activate, deactivate or remove an employee from the row's options menu.",
                    CreatedOn = now,
                    IsActive = true
                },
                new KnowledgeArticle
                {
                    Category = "Security",
                    Title = "Creating and revoking API keys",
                    Summary = "Generate API keys, whitelist IPs, and revoke access.",
                    Content = "Visit Account > Security > Access Keys to create a new API key, edit its whitelisted IPs, view the secret key, or revoke access when it's no longer needed.",
                    CreatedOn = now,
                    IsActive = true
                },
                new KnowledgeArticle
                {
                    Category = "Support",
                    Title = "Raising a support ticket",
                    Summary = "Use the Tickets page to raise a request and track replies.",
                    Content = "Go to Support > Tickets and click + Raise a Ticket. Fill in the subject, type and your query, attach a file if needed, and submit. You can track its status in the tickets table.",
                    CreatedOn = now,
                    IsActive = true
                }
            );

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KnowledgeArticleDTO>> SearchAsync(string? search, string? category)
        {
            await EnsureSeededAsync();

            var articles = _context.KnowledgeArticles.Where(x => x.IsActive == true);

            if (!string.IsNullOrWhiteSpace(category))
                articles = articles.Where(x => x.Category == category);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                articles = articles.Where(x => EF.Functions.ILike(x.Title, $"%{term}%") || EF.Functions.ILike(x.Summary, $"%{term}%"));
            }

            return await articles
                .OrderBy(x => x.Category)
                .ThenBy(x => x.Title)
                .Select(x => ToDto(x))
                .ToListAsync();
        }
    }
}
