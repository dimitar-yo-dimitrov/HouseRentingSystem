using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Core.Models.Houses.Enums;

namespace HouseRentingSystem.Core.Services.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

        Task<HousesQueryModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(HouseInputModel model, int agentId);

        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);

        Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int id);

        Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);

        Task EditAsync(int houseId, HouseInputModel model);

        Task<bool> HasAgentWithId(int houseId, string currentUserId);
    }
}
