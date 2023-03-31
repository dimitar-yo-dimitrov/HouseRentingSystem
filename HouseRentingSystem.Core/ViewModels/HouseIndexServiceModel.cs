namespace HouseRentingSystem.Core.ViewModels
{
    public class HouseIndexServiceModel
    {
        public HouseIndexServiceModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; init; }

        public string Title { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;
    }
}
