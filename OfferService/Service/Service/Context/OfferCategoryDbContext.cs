using Interface.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Service.Context
{
    public class OfferCategoryDbContext : DbContext
    {
        public OfferCategoryDbContext(
            DbContextOptions<OfferCategoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<OfferCategory> OfferCategories { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<LandingPage> LandingPage { get; set; }
        public DbSet<TargetingRules> TargetingRules { get; set; }
        public DbSet<Creative> Creative { get; set; }
        public DbSet<CappingRule> CappingRules { get; set; }
        public DbSet<EventSetting> EventSettings { get; set; }
        public DbSet<PayoutRule> PayoutRules { get; set; }
        public DbSet<EventGoal> EventGoals { get; set; }
        public DbSet<FallbackIntegration> FallbackIntegrations { get; set; }
        public DbSet<AntiFraudSetting> AntiFraudSettings { get; set; }
        public DbSet<AutomationRule> AutomationRules { get; set; }
        public DbSet<SuppressionList> SuppressionLists { get; set; }
        public DbSet<RetargetingTag> RetargetingTags { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<OfferLinkingRule> OfferLinkingRules { get; set; }
        public DbSet<TopOffer> TopOffers { get; set; }
        public DbSet<TopOfferMailerLog> TopOfferMailerLogs { get; set; }
        public DbSet<ProductFeed> ProductFeeds { get; set; }
        public DbSet<MailerTemplate> MailerTemplates { get; set; }
        public DbSet<SmtpSetting> SmtpSettings { get; set; }
        public DbSet<MailerLog> MailerLogs { get; set; }
        public DbSet<DefaultMailerTemplate> DefaultMailerTemplates { get; set; }
        public DbSet<AutomationLog> AutomationLogs { get; set; }
        public DbSet<LinkTesterRule> LinkTesterRules { get; set; }
        public DbSet<LinkTestResult> LinkTestResults { get; set; }
        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<NetworkSetting> NetworkSettings { get; set; }
        public DbSet<BillingSubscription> BillingSubscriptions { get; set; }
        public DbSet<BillingPlanHistoryLog> BillingPlanHistoryLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OfferCategory>(entity =>
            {
                entity.ToTable("OfferCategory");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.OfferCategoryName)
                    .HasMaxLength(150);

                entity.Property(x => x.CreatedBy)
                    .HasMaxLength(100);

                entity.Property(x => x.ModifiedBy)
                    .HasMaxLength(100);
            });
        }
    }
}