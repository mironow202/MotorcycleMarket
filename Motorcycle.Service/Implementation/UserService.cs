using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Enum;
using MotorcycleMarket.Domain.Extensions;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels;
using MotorcycleMarket.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleMarket.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAll()
                    .Where(x => x.Role != Role.Admin)
                    .Select(x => new UserViewModel()
                    {
                        Id = x.Id,
                        UserName = x.Username,
                        Role = x.Role.GetDisplayName()
                    }).ToListAsync();

                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    StatusCode = StatusCode.ServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
