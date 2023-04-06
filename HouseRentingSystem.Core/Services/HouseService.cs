using HouseRentingSystem.Core.Models;
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

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
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

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategories()
        => await _repository
            .AllReadonly<Category>()
            .Select(c => new HouseCategoryServiceModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

    }
}
