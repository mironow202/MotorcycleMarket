using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels.Motorcycle;

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IMotorcycleService
    {
        Task<IBaseResponse<IEnumerable<Motorcycle>>> GetAllMotorcycleAsync();
        Task<IBaseResponse<Motorcycle>> GetMotorcycleByNameAsync(string name);
        Task<IBaseResponse<Motorcycle>> GetMotorcycleAsync(int id);
        Task<IBaseResponse<bool>> DeleteMotorcycleAsync(int id);
        Task<IBaseResponse<Motorcycle>> Edit(int id, MotorcycleViewModel model);
        Task<IBaseResponse<bool>> Create(MotorcycleViewModel model);
    }
}
