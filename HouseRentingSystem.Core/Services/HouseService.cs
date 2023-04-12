using HouseRentingSystem.Core.Models.Houses;
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
    }
}
