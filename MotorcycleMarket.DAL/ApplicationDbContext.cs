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
        public DbSet<User> Profiles { get; set; }

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

                HashPasswordHelper.CreatePasswordHash("321", out byte[] passwordHash, out byte[] passwordSalt);
                builder.HasData(new User
                {
                    Id = 1,
                    Username = "Mironow",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.PasswordSalt).IsRequired();
                builder.Property(x => x.PasswordHash).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);
            });
        }
    } 
}