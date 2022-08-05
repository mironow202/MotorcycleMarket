using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.DAL.Repositories;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Service.Implementation;
using MotorcycleMarket.Service.Interfaces;

namespace MotorcycleMarket
{
    public  static class InitializerServices
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Motorcycle>, MotorcycleRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IMotorcycleService, MotorcycleService>();
        }
    }
}
