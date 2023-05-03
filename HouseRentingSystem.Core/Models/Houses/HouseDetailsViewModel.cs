namespace HouseRentingSystem.Core.Models.Houses
{
    public class HouseDetailsViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;
    }
}
