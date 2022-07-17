using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Motorcycle> Motorcycle { get; set; }

    }
}