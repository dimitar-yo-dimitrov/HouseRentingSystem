using HouseRentingSystem.Infrastructure.Common.Repositories;

namespace HouseRentingSystem.Infrastructure.Data.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(HouseRentingDbContext context)
        {
            this.Context = context;
        }
    }
}
