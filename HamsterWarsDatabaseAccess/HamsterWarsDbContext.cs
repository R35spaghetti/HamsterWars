using Microsoft.EntityFrameworkCore;
using HamsterWarsApi.Models;

namespace HamsterWarsDatabaseAccess
{
    public class HamsterWarsDbContext : DbContext
    {

        public HamsterWarsDbContext(DbContextOptions<HamsterWarsDbContext> options) : base(options)
        { }

        //public HamsterWarsDbContext()
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Hamster>().HasData(new Hamster
            {
                Id = 1,
                Name = "Testhamster",
                Age = 1,
                FavFood = "Lime",
                Loves = "Ice skating",
                ImgName = "hamster-1.jpg",
                Wins = 5,
                Losses = 4,
                Games = 9



            });
            modelBuilder.Entity<Hamster>().HasData(new Hamster
            {
                Id = 2,
                Name = "Tam",
                Age = 1,
                FavFood = "raspberries",
                Loves = "scaring cats",
                ImgName = "hamster-2.jpg",
                Wins = 7,
                Losses = 3,
                Games = 10



            });
        }
        public DbSet<Hamster> Hamsters { get; set; } = null!;

    }
}
