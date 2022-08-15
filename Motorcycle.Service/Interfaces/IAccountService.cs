using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels.Registration;
using System.Security.Claims;

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> RegisterAsync(RegisterViewModel userModel);
    }
}
