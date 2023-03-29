using HouseRentingSystem.Infrastructure.Data;
using HouseRentingSystem.Infrastructure.Data.Repositories;
using Houses.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Extensions
{
    public static class HouseRentingCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();

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
