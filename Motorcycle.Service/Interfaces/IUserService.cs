using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels;

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
        Task<BaseResponse<bool>> DeleteUser(long id);
    }
}
