using HouseRentingSystem.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configurations
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(new Agent
            {
                Id = "E305205E-A570-40AE-9644-D4E173B05D0D",
                PhoneNumber = "+359888888888",
                UserId = "2D292230-3008-4480-B0AC-09262553439D"
            });
        }
    }
}
