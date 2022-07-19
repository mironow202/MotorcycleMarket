using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MotorcycleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Create(Motorcycle entity)
        {
            await _applicationDbContext.Motorcycle.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Motorcycle entity)
        {
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return true;    
        }

        public async Task<Motorcycle> Get(int id)
        {
            return await _applicationDbContext.Motorcycle.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Motorcycle> GetByNameAsync(string name)
        {
            return await _applicationDbContext.Motorcycle.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Motorcycle>> Select()
        {
            return await _applicationDbContext.Motorcycle.ToListAsync();
        }
    }
}
