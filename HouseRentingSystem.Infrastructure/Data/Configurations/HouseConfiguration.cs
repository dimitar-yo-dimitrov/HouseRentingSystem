using HouseRentingSystem.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configurations
{
    internal class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(CreateHouse());
        }

        private static IEnumerable<House> CreateHouse()
        {
            var houses = new[]
            {
                new House
                {
                    Id = "3C3A02DC-DF00-47DA-B053-FB81BB714A90",
                    Title = "Big House Marina",
                    Address = "North London, UK (near the border)",
                    Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                    ImageUrl =
                        "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                    PricePerMonth = 2100.00M,
                    CategoryId = "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179",
                    AgentId = "E305205E-A570-40AE-9644-D4E173B05D0D",
                    RenterId = "093E8F21-0CC1-4780-855D-1D221995A50F"
                },
                new House
                {
                    Id = "1DFB745D-E948-4375-81AC-3A86EBBFC237",
                    Title = "Family House Comfort",
                    Address = "Near the Sea Garden in Burgas, Bulgaria",
                    Description =
                        "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                    ImageUrl =
                        "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                    PricePerMonth = 1200.00M,
                    CategoryId = "B8B415F1-8441-47C3-9F72-E9645531B127",
                    AgentId = "F384529F-D095-41EF-8129-D2A76E20542E"
                },
                new House
                {
                    Id = "BF445967-EF66-41CC-BA39-462CBC7D24DE",
                    Title = "Grand House",
                    Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                    Description = "This luxurious house is everything you will need. It is just excellent.",
                    ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                    PricePerMonth = 2000.00M,
                    CategoryId = "6ED2D32C-8A59-4E8F-9F24-D8CC86BE5F2C",
                    AgentId = "99991ACC-C129-42A6-994F-B0E24EF03777"
                }
            };

            return houses;
        }
    }
}
