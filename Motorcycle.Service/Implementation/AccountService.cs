using AutoMapper;
using Microsoft.Extensions.Configuration;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Service.Interfaces;
using MotorcycleMarket.Domain.Helpers;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.Domain.ViewModels.Registration;
using MotorcycleMarket.Domain.Enum;

namespace MotorcycleMarket.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IBaseRepository<User> baseRepository, IConfiguration configuration/*, IMapper mapper*/)
        {
            _userRepository = baseRepository;   
            _configuration = configuration;
        }

        public async Task<BaseResponse<ClaimsIdentity>> LoginAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == registerViewModel.UserName);
                if (user == null && !HashPasswordHelper.VerifyPasswordHash(registerViewModel.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return new BaseResponse<ClaimsIdentity>() { Description = "Incorrect password or username entered incorrectly" };
                }

                var res = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = res,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {

                
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> RegisterAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Username == registerViewModel.UserName);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                    };
                }
                HashPasswordHelper.CreatePasswordHash(registerViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user = new User()
                {
                   Username = registerViewModel.UserName,
                   PasswordHash = passwordHash,
                   PasswordSalt = passwordSalt,
                   Role = Role.User
                };

                await _userRepository.Create(user);
                var auth = Authenticate(user);  

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = auth,
                    Description = "Registration good"
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.ServerError
                }; 
            }
           
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims);
        }

    }
}
