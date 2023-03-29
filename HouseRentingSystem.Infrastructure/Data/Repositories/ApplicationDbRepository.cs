using HouseRentingSystem.Infrastructure.Common.Repositories;
using Houses.Infrastructure.Data.Repositories;

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
