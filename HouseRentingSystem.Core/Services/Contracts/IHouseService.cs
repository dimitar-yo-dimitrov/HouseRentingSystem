using HouseRentingSystem.Core.Models.Houses;

namespace HouseRentingSystem.Core.Services.Contracts
{
    public interface IHouseService
    {
        //Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(string categoryId);

        Task<int> CreateAsync(HouseInputModel model, string agentId);
    }
}
