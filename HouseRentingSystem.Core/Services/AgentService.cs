using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Infrastructure.Data.Entities;
using HouseRentingSystem.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IApplicationDbRepository _repository;

        public AgentService(IApplicationDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExistsById(string userId)
         => await _repository
                .AllReadonly<Agent>()
                .AnyAsync(a => a.UserId == userId);

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
            => await _repository
                .AllReadonly<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

        public async Task<bool> UserHasRents(string userId)
            => await _repository
                .AllReadonly<House>()
                .AnyAsync(h => h.RenterId == userId);

        public async Task Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await _repository.AddAsync(agent);
            await _repository.SaveChangesAsync();
        }

        public async Task<Agent?> GetAgentIdAsync(string userId)
            => await _repository
                .AllReadonly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId);
    }
}
