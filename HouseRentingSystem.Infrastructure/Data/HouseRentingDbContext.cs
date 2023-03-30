using HouseRentingSystem.Infrastructure.Data.Entities;
using HouseRentingSystem.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data
{
    public class HouseRentingDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
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
            //builder.ApplyConfiguration(new HouseConfiguration());
            //builder.ApplyConfiguration(new AgentConfiguration());
            //builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }

        public virtual DbSet<House> Houses { get; init; } = null!;

        public virtual DbSet<Category> Categories { get; init; } = null!;

        public virtual DbSet<Agent> Agents { get; init; } = null!;
    }
}