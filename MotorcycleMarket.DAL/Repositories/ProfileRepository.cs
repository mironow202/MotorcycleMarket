using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly ApplicationDbContext _context;
        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Profile entity)
        {
            await _context.Profiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Profile entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Profile> GetAll()
        {
            return _context.Profiles;
        }

        public async Task<Profile> Update(Profile entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
