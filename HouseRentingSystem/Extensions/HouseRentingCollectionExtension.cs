using HouseRentingSystem.Data;
using Houses.Infrastructure.Data.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Extensions
{
    public static class HouseRentingCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<HouseRentingDbContext>(options
                => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
