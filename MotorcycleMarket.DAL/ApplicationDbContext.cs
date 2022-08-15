using Microsoft.EntityFrameworkCore;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Enum;
using MotorcycleMarket.Domain.Helpers;

namespace MotorcycleMarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { Database.EnsureCreated(); }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Motorcycle>().HasData(new Motorcycle
            {
                Id = 1,
                Name = "Yamaha R1",
                Description = "Очень быстрая",
                Model = "Yamaha",
                Speed = 250,
                Price = 1500000,
                DateCreate = DateTime.Now,
                TypeMotorcycle = TypeMotorcycle.Sport
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.Id);

                builder.HasData(new User
                {
                    Id = 1,
                    UserName = "Mironow",
                    FirstName = "Герыч",
                    Password = HashPasswordHelper.HashPassowrd("123456"),
                    LastName = "Kilan",
                    Email = "1212",
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();

            });
        }
    } 
}