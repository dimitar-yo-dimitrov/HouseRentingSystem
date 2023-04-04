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

        public Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasRents(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Create(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
