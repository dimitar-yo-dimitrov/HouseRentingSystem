using HouseRentingSystem.Core.Models;
using HouseRentingSystem.Core.Models.Houses;

namespace HouseRentingSystem.Core.Services.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();

        Task<IEnumerable<HouseCategoryServiceModel>> AllHouses();
    }
}
