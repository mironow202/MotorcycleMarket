using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels;

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IMotorcycleService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();

        IBaseResponse<List<Motorcycle>> GetMotorcycles();

        Task<IBaseResponse<MotorcycleViewModel>> GetMotorcycle(int id);

        Task<BaseResponse<Dictionary<int, string>>> GetMotorcycle(string term);

        Task<IBaseResponse<Motorcycle>> Create(MotorcycleViewModel model, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteMotorcycle(int id);

        Task<IBaseResponse<Motorcycle>> Edit(int id, MotorcycleViewModel model);
    }
}
