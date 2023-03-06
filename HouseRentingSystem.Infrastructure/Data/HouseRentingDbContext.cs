using HouseRentingSystem.Infrastructure.Data.Configurations;
using HouseRentingSystem.Infrastructure.Data.Entities;
using HouseRentingSystem.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data
{
    public class HouseRentingDbContext : IdentityDbContext<ApplicationUser>
    {
        public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new HouseConfiguration());

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Agent> Agents { get; init; } = null!;

        public virtual DbSet<Category> Categories { get; init; } = null!;

        public virtual DbSet<House> Houses { get; init; } = null!;
    }
}