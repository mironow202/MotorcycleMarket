using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
 
 

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IMotorcycleService
    {
        Task<IBaseResponse<IEnumerable<Motorcycle>>> GetAllMotorcycle();
    }
}
