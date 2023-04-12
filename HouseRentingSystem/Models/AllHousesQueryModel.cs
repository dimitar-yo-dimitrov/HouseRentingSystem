using HouseRentingSystem.Core.Models.Houses;

namespace HouseRentingSystem.Models
{
    public class AllHousesQueryModel
    {
        public int TotalHousesCount { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }
            = new HashSet<HouseServiceModel>();
    }
}
