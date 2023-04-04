namespace HouseRentingSystem.Core.Services.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsById(string userId);
    }
}
