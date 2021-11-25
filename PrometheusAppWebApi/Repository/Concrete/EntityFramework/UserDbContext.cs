using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace PrometheusAppWebApi.Repository.Concrete.EntityFramework
{
    // User modeli bu DbContext sınıfında veritabanına ekleniyor
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        // User'ın veritabanına eklendiği kısım.
        public DbSet<User> Users { get; set; }

        // Modele başlangıç değerlerini bu metod ile veriyoruz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "Mary",
                Surname = "Smith",
                Email = "marysmith@gmail.com",
                PhoneNumber = "5462356564",
                DateOfBirth = new DateTime(1982, 9, 23)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 2,
                Name = "Sara",
                Surname = "Longway",
                Email = "saralongway@gmail.com",
                PhoneNumber = "5612356452",
                DateOfBirth = new DateTime(1975, 12, 30)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 3,
                Name = "John",
                Surname = "Hastings",
                Email = "johnhastings@gmail.com",
                PhoneNumber = "5264589568",
                DateOfBirth = new DateTime(1991, 2, 14)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 4,
                Name = "Sam",
                Surname = "Galloway",
                Email = "samgalloway@gmail.com",
                PhoneNumber = "5145362585",
                DateOfBirth = new DateTime(1988, 10, 18)
            });
        }
    }
}
