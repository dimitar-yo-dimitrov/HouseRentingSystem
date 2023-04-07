using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants.Category;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<House> Houses { get; set; }
            = new HashSet<House>();
    }
}
