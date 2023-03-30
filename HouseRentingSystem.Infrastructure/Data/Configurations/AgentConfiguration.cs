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
                Id = "D00DD0BB-783B-4766-AF26-5958608A96FE",
                PhoneNumber = "+359888888888",
                UserId = "E305205E-A570-40AE-9644-D4E173B05D0D"
            });
        }
    }
}
