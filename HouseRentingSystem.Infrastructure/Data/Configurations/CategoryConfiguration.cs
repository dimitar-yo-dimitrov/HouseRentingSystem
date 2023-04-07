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

        private static IEnumerable<Category> CreateCategories()
        {
            var categories = new[]
            {
                new Category
                {
                    Id = 1,
                    Name = "Cottage"
                },
                new Category
                {
                    Id = 2,
                    Name = "Single-Family"
                },
                new Category
                {
                    Id = 3,
                    Name = "Duplex"
                }
            };

            return categories;
        }
    }
}
