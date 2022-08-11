using AutoMapper;
using Microsoft.Extensions.Configuration;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Service.Interfaces;

namespace MotorcycleMarket.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountService(IBaseRepository<User> baseRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = baseRepository;   
            _configuration = configuration; 
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = _configuration.gene
        }

        public async Task<AuthenticateResponse> Register(User userModel)
        {
            var user = _mapper.Map<User>(userModel);
            await _userRepository.Create(userModel);

            var response = 
        }
    }
}
