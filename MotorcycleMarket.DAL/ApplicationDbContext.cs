using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        private ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        
        {
             
        }

        public DbSet<Motorcycle> Motorcycle { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Motorcycle>().HasData(new Motorcycle
            {
                Id = 5,
                Name = "Yamaha R13",
                Description = "Очень быстрая",
                Model = "Yamaha",
                Speed = 250,
                Price = 1500000,
                DateCreate = DateTime.Now,
                TypeMotorcycle = Domain.Enum.TypeMotorcycle.Sport
            });
        }

    }
}