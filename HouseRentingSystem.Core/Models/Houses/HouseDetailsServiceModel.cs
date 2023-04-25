using HouseRentingSystem.Core.Models.Agents;

namespace HouseRentingSystem.Core.Models.Houses
{
    public class HouseDetailsServiceModel : HouseServiceModel
    {
        public string Description { get; init; } = null!;

        public string Category { get; init; } = null!;

        public AgentServiceModel Agent { get; init; } = null!;
    }
}
