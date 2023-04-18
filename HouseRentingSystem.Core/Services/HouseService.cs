using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Core.Models.Houses.Enums;
using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Infrastructure.Data.Entities;
using HouseRentingSystem.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IApplicationDbRepository _repository;

        public HouseService(IApplicationDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
            => await _repository
                .All<House>()
                .Where(h => h.IsActive)
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .Take(3)
                .ToListAsync();

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        => await _repository
            .AllReadonly<Category>()
            .Select(c => new HouseCategoryServiceModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

        public async Task<HousesQueryModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var result = new HousesQueryModel();
            var houses = _repository.AllReadonly<House>(h => h.IsActive);

            if (string.IsNullOrWhiteSpace(category) == false)
            {
                houses = _repository
                    .AllReadonly<House>()
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrWhiteSpace(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                houses = _repository
                    .AllReadonly<House>()
                    .Where(h => h.Title.ToLower().Contains(searchTerm) ||
                                h.Address.ToLower().Contains(searchTerm) ||
                                h.Description.ToLower().Contains(searchTerm));
            }

            houses = sorting switch
            {
                HouseSorting.Price => houses
                    .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => houses
                    .OrderBy(h => h.RenterId != null)
                    .ThenByDescending(h => h.Id),
                _ => houses.OrderByDescending(h => h.Id)
            };

            result.Houses = await houses
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth
                })
                .ToListAsync();

            result.TotalHousesCount = await houses.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
            => await _repository
                .AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();

        public async Task<bool> CategoryExistsAsync(int categoryId)
            => await _repository
                .AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);

        public async Task<int> CreateAsync(HouseInputModel model, int agentId)
        {
            var house = new House
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Address = model.Address,
                Description = model.Description,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId,
                AgentId = agentId
            };

            await _repository.AddAsync(house);
            await _repository.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            var houses = await _repository.AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(a => a.AgentId == agentId)
                .Select(h => new HouseServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Address = h.Address

                })
                .ToListAsync();

            return houses;
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
        {
            var houses = await _repository.AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(a => a.RenterId == userId)
                .Select(h => new HouseServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Address = h.Address

                })
                .ToListAsync();

            return houses;
        }
    }
}
