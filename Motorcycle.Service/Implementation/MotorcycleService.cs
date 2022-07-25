using MotorcycleMarket.Service.Interfaces;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Enum;
using MotorcycleMarket.Domain.ViewModels.Motorcycle;

namespace MotorcycleMarket.Service.Implementation
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        public MotorcycleService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<IBaseResponse<bool>> Create(MotorcycleViewModel motorcycleViewModel)
        {
            var baseResponse = new BaseResponse<bool>() { Data = true };
            try
            {
    
                var motorcl = new Motorcycle()
                {
                    Description = motorcycleViewModel.Description,
                    Name = motorcycleViewModel.Name,
                    Speed = motorcycleViewModel.Speed,
                    Price = motorcycleViewModel.Price,
                    TypeMotorcycle = (TypeMotorcycle)Convert.ToInt32(motorcycleViewModel.TypeMotorcycle),
                };
                var result = await _motorcycleRepository.Create(motorcl);
                var response = result ? baseResponse.Data = true : baseResponse.Data = false;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"GetMotorcycleByNameAsync : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }


        public async Task<IBaseResponse<Motorcycle>> Edit(int id, MotorcycleViewModel model)
        {
            var baseResponse = new BaseResponse<Motorcycle>();
            try
            {
                var car = await _motorcycleRepository.Get(id);
                if (car == null)
                {
                    baseResponse.StatusCode = StatusCode.MotorcycleNotFound;
                    baseResponse.Description = "MotorcycleNotFound";
                    return baseResponse;
                }

                car.Description = model.Description;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DateCreate = model.DateCreate;
                car.Name = model.Name;

                await _motorcycleRepository.Update(car);


                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Motorcycle>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteMotorcycleAsync(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var motorcycle = await _motorcycleRepository.Get(id);
                if (motorcycle == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _motorcycleRepository.Delete(motorcycle);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeletMotorcycle] : {ex.Message}",
                    StatusCode = StatusCode.ServerEror
                };
            }
        }

        public async Task<IBaseResponse<Motorcycle>> GetMotorcycleByNameAsync(string name)
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

        public async Task<IBaseResponse<Motorcycle>> GetMotorcycleAsync(int id)
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
