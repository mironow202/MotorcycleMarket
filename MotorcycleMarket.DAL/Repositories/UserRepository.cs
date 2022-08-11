using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL.Repositories
{
    internal class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users; 
        }

        public async Task<User> Update(User entity)
        {
            await Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
