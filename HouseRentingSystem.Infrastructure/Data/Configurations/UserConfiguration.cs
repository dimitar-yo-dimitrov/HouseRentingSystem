using HouseRentingSystem.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(au => au.IsActive)
                .HasDefaultValue(true);

            builder.HasData(CreateUser());
        }

        private static IEnumerable<ApplicationUser> CreateUser()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "2D292230-3008-4480-B0AC-09262553439D",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "agent123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "AF724889-F204-4573-8D65-ED50557A9B71",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "guest123");

            users.Add(user);

            return users;
        }
    }
}
