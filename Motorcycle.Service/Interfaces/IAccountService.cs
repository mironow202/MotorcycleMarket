using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;

namespace MotorcycleMarket.Service.Interfaces
{
    public interface IAccountService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(User userModel);
    }
}
