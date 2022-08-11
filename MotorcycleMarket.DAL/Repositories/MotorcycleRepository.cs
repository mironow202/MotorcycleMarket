using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL.Repositories
{
    public class MotorcycleRepository : IBaseRepository<Motorcycle>
    {
        private readonly ApplicationDbContext _context;
        public MotorcycleRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<bool> Create(Motorcycle entity)
        {
            await _context.Motorcycles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Motorcycle entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;    
        }

        public IQueryable<Motorcycle> GetAll()
        {
           return _context.Motorcycles;
        }

        public async Task<Motorcycle> Update(Motorcycle entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;  
        }
    }
}
