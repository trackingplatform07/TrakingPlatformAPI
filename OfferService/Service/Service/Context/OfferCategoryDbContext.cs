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