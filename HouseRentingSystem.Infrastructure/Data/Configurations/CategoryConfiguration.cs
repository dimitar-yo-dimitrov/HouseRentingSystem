using HouseRentingSystem.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private static Category[] CreateCategories()
        {
            var categories = new Category[]
            {
                new Category()
                {
                    Id = "B3D23CE7-7A38-4E00-91E3-BD446A6C1033",
                    Name = "Cottage"
                },
                new Category()
                {
                    Id = "4FDD33D0-218F-4094-B1D4-707403A8ADD4",
                    Name = "Single-Family"
                },
                new Category()
                {
                    Id = "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179",
                    Name = "Duplex"
                }
            };

            return categories;
        }
    }
}
