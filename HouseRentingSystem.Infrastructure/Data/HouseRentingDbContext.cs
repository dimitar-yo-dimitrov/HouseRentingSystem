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
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        public virtual DbSet<Agent> Agents { get; init; }

        public virtual DbSet<Category> Categories { get; init; }

        public virtual DbSet<House> Houses { get; init; }
    }
}