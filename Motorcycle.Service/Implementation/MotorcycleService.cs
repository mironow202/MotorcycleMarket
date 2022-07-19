using MotorcycleMarket.Service.Interfaces;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Enum;

namespace MotorcycleMarket.Service.Implementation
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        public MotorcycleService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }


        public async Task<IBaseResponse<Motorcycle>> GetCarByNameAsync(string name)
        {
            var baseResponse = new BaseResponse<Motorcycle>();
            try
            {
                var motorcycl = await _motorcycleRepository.GetByNameAsync(name);
                if (motorcycl == null)
                {
                    baseResponse.Description = "Data not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                }
                baseResponse.Data = motorcycl;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Motorcycle>()
                {
                    Description = $"GetCarByNameAsync : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }

        public async Task<IBaseResponse<Motorcycle>> GetCarAsync(int id)
        {
            var baseResponse = new BaseResponse<Motorcycle>();
            try
            {
                var motorcycl = await _motorcycleRepository.Get(id);
                if (motorcycl == null)
                {
                    baseResponse.Description = "Data not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                }
                baseResponse.Data = motorcycl;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Motorcycle>()
                {
                    Description = $"GetCarAsync : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Motorcycle>>> GetAllMotorcycleAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<Motorcycle>>(); 
            try
            {
                var motorcycle = await _motorcycleRepository.Select();
                if (motorcycle.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов.";
                    baseResponse.StatusCode =  StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = motorcycle;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Motorcycle>>()
                {
                    Description = $"GetAllMotorcycleAsync : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }
    }
}
