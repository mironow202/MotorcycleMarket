using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<User>>> GetUsers();
    }
}
