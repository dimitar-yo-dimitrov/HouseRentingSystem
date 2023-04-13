namespace HouseRentingSystem.Core.Models.Houses
{
    public class HousesQueryModel
    {
        public int TotalHousesCount { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }
            = new HashSet<HouseServiceModel>();
    }
}
