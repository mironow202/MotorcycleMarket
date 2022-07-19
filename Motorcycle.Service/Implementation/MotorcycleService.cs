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

        public async Task<IBaseResponse<IEnumerable<Motorcycle>>> GetAllMotorcycle()
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
                    Description = $"GetMotorcycle : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }
    }
}
