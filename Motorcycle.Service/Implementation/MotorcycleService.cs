using MotorcycleMarket.Service.Interfaces;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels.Motorcycle;
using MotorcycleMarket.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace MotorcycleMarket.Service.Implementation
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IBaseRepository<Motorcycle> _motorcycleRepository;
        public MotorcycleService(IBaseRepository<Motorcycle> motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<IBaseResponse<Motorcycle>> Create(MotorcycleViewModel model, byte[] imageData)
        {
            try
            {
                var motorcycle = new Motorcycle()
                {
                    Name = model.Name,
                    Model = model.Model,
                    Description = model.Description,
                    DateCreate = DateTime.Now,
                    Speed = model.Speed,
                    TypeMotorcycle = (TypeMotorcycle)Convert.ToInt32(model.TypeMotorcycle),
                    Price = model.Price,
                    Avatar = imageData
                };
                await _motorcycleRepository.Create(motorcycle);

                return new BaseResponse<Motorcycle>()
                {
                    Data = motorcycle,
                    StatusCode = Domain.Enum.StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Motorcycle>()
                {
                    Description = "MotorcycleService  - Create " + ex.Message,
                    StatusCode = StatusCode.ServerError
                };
                throw;
            }
        }

        public async Task<IBaseResponse<bool>> DeleteMotorcycle(int id)
        {
            try
            {
                var motorcycle = await _motorcycleRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (motorcycle == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "DeleteMotorcycle",
                        StatusCode = StatusCode.MotorcycleNotFound,
                        Data = false
                    };
                }

                await _motorcycleRepository.Delete(motorcycle);

                return new BaseResponse<bool>()
                {
                    Description = "DeleteMotorcycle",
                    StatusCode = StatusCode.MotorcycleNotFound,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = "MotorcycleService  - Create " + ex.Message,
                    StatusCode = StatusCode.ServerError,
                    Data = false
                };
            }
        }

        public async Task<IBaseResponse<Motorcycle>> Edit(int id, MotorcycleViewModel model)
        {
            try
            {
                var mototrcycle = await _motorcycleRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (mototrcycle == null)
                {
                    return new BaseResponse<Motorcycle>()
                    {
                        Description = "Edit",
                        Data = mototrcycle,
                        StatusCode = StatusCode.MotorcycleNotFound
                    };
                }

                mototrcycle.Id = model.ID;
                mototrcycle.Name = model.Name;
                mototrcycle.Description = model.Description;
                mototrcycle.Price = model.Price;
                mototrcycle.DateCreate = model.DateCreate;
                mototrcycle.Avatar = mototrcycle.Avatar;

                await _motorcycleRepository.Update(mototrcycle);

                return new BaseResponse<Motorcycle>()
                {
                    Description = "Edit",
                    Data = mototrcycle,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Motorcycle>()
                {
                    Description = ex.Message + "Edit",
                    StatusCode = StatusCode.ServerError;
            };
        }

        public async Task<IBaseResponse<MotorcycleViewModel>> GetMotorcycle(int id)
        {
            try
            {
                var motorcycle = await _motorcycleRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (motorcycle == null)
                {
                    return new BaseResponse<Motorcycle>()
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<BaseResponse<Dictionary<int, string>>> GetMotorcycle(string term)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<List<Motorcycle>> GetMotorcycles()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            throw new NotImplementedException();
        }
    }

}
    
    
 
