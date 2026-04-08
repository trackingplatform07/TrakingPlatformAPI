using Interface.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Service.Context
{
    public class AffiliateDbContext : DbContext
    {
        public AffiliateDbContext(DbContextOptions<AffiliateDbContext> options)
            : base(options)
        {
        }

        public DbSet<AffiliateDto> Affiliates { get; set; }
        public DbSet<AffiliatePostbackDto> AffiliatePostbacks { get; set; }


    }
}
