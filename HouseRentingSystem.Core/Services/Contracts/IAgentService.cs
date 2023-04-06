using HouseRentingSystem.Infrastructure.Data.Entities;

namespace HouseRentingSystem.Core.Services.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsById(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);

        Task<bool> UserHasRents(string userId);

        Task Create(string userId, string phoneNumber);

        Task<Agent?> GetAgentIdAsync(string userId);
    }
}
