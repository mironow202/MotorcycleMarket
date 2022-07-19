using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL.Interfaces
{
    public interface IMotorcycleRepository : IBaseRepository<Motorcycle>
    {
       Task<Motorcycle> GetByNameAsync(string name);

    }
}
