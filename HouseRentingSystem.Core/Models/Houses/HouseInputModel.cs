using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.GlobalConstants.ExceptionMessages;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants.House;

namespace HouseRentingSystem.Core.Models.Houses
{
    public class HouseInputModel
    {
        public HouseInputModel()
        {
            HouseCategories = new HashSet<HouseCategoryServiceModel>();
        }

        public int Id { get; init; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; init; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; init; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; init; } = null!;

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinLength, PriceMaxLength,
            ErrorMessage = PricePerMonthMessage)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<HouseCategoryServiceModel> HouseCategories { get; set; }
    }
}
