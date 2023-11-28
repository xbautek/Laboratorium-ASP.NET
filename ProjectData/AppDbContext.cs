using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "photos.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //tworzenie użytkownika
            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "test",
                NormalizedUserName = "TEST",
                Email = "test@wsei.edu.pl",
                NormalizedEmail = "TEST@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

            user.PasswordHash = passwordHasher.HashPassword(user, "1234Ab!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(user);

            //tworzenie roli

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;

            //nadanie użytkownikowi roli

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    }
                );

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);


            modelBuilder.Entity<PhotoEntity>()
                .HasOne(e => e.Author)
                .WithMany(o => o.Photos)
                .HasForeignKey(k => k.AuthorId);

            modelBuilder.Entity<AuthorEntity>()
               .HasData(
                   new AuthorEntity()
                   {
                       Id = 101,
                       Name = "Max",
                       Surname = "Cuttler",
                       Email = "maxcut@gmail.com"
                   },
                   new AuthorEntity()
                   {
                       Id = 102,
                       Name = "Daniel",
                       Surname = "Tarka",
                       Email = "danieltarka1994@o2.com"
                   }
               );

            modelBuilder.Entity<PhotoEntity>().HasData(
                new PhotoEntity()
                {
                    Id = 1,
                    AuthorId = 101,
                    Camera = "Nikon",
                    DateAndTime = new DateTime(2022, 12, 22),
                    Description = "My best photo from the Kryspinów lake",
                    Format = "_16x9",
                    Resolution = "_2560x1440"
                },
                new PhotoEntity()
                {
                    Id = 2,
                    AuthorId = 102,
                    Camera = "Sony",
                    DateAndTime = new DateTime(2023, 10, 31),
                    Description = "Halloween party photo",
                    Format = "_21x9",
                    Resolution = "_3840x2160"
                }
                );
        }
    }
}
