using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL.Repositories
{
    public class MotorcycleRepository : IBaseRepository<Motorcycle>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MotorcycleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Create(Motorcycle entity)
        {
            await _applicationDbContext.Motorcycles.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Motorcycle entity)
        {
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return true;    
        }

        public IQueryable<Motorcycle> GetAll()
        {
           return _applicationDbContext.Motorcycles;
        }

        public async Task<Motorcycle> Update(Motorcycle entity)
        {
            _applicationDbContext.Update(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;  
        }
    }
}
