﻿using HouseRentingSystem.Common.GlobalConstants;
using HouseRentingSystem.Core.Models.Agents;
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
            var houses = await _repository
                .AllReadonly<House>(h => h.IsActive)
                .Where(a => a.AgentId == agentId)
                .ToListAsync();

            return ProjectToModel(houses);
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
        {
            var houses = await _repository
                .AllReadonly<House>(h => h.IsActive)
                .Where(a => a.RenterId == userId)
                .ToListAsync();

            return ProjectToModel(houses);
        }

        public async Task<bool> ExistsAsync(int id)
            => await _repository
                .AllReadonly<House>()
                .AnyAsync(h => h.Id == id);

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            if (id == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.IdIsNull));
            }

            var houseDetails = await _repository
                .AllReadonly<House>(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                    Address = h.Address,
                    Description = h.Description,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                    Category = h.Category.Name,
                    Agent = new AgentServiceModel
                    {
                        PhoneNumber = h.Agent.PhoneNumber,
                        Email = h.Agent.User.Email
                    }
                })
                .FirstOrDefaultAsync();

            return houseDetails!;
        }

        public async Task EditAsync(int houseId, HouseInputModel model)
        {
            var house = await GetHouseByIdAsync(houseId);

            house.Title = model.Title;
            house.ImageUrl = model.ImageUrl;
            house.Address = model.Address;
            house.Description = model.Description;
            house.PricePerMonth = model.PricePerMonth;
            house.CategoryId = model.CategoryId;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> HasAgentWithId(int houseId, string currentUserId)
        {
            bool result = false;

            var house = await _repository
                .All<House>(h => h.IsActive)
                .Where(h => h.Id == houseId)
                .FirstOrDefaultAsync();

            if (house?.Agent != null &&
                house.Agent.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<int> GetHouseCategoryId(int houseId)
        {
            var houseCategoryId = await GetHouseByIdAsync(houseId);

            return houseCategoryId.CategoryId;
        }

        public async Task DeleteAsync(int houseId)
        {
            var house = await GetHouseByIdAsync(houseId);

            house.IsActive = false;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IsRentedAsync(int houseId)
            => (await _repository.GetByIdAsync<House>(houseId)).RenterId != null;

        public async Task<bool> IsRentedByUserIdAsync(int houseId, string currentUserId)
        {
            var house = await _repository
                .AllReadonly<House>(h => h.IsActive)
                .Where(h => h.Id == houseId)
                .FirstOrDefaultAsync();

            return house != null || house!.RenterId == currentUserId;
        }

        public async Task RentAsync(int houseId, string userId)
        {
            var house = await GetHouseByIdAsync(houseId);

            house.RenterId = userId;
            await _repository.SaveChangesAsync();
        }

        public async Task Leave(int houseId)
        {
            var house = await GetHouseByIdAsync(houseId);

            house.RenterId = null;
            await _repository.SaveChangesAsync();
        }

        private static IEnumerable<HouseServiceModel> ProjectToModel(IEnumerable<House> houses)
        {
            var resultHouses = houses
                .Select(h => new HouseServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Address = h.Address

                })
                .ToList();

            return resultHouses;
        }

        private async Task<House> GetHouseByIdAsync(int houseId)
        {
            return await _repository.GetByIdAsync<House>(houseId);
        }
    }
}
