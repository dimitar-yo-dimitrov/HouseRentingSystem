using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
