using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.DAL.Repositories;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Service.Implementation;
using MotorcycleMarket.Service.Interfaces;

namespace MotorcycleMarket
{
    public static class InitializerServices
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Motorcycle>, MotorcycleRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IMotorcycleService, MotorcycleService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
