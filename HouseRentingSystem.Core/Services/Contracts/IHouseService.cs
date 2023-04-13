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
    }
}
