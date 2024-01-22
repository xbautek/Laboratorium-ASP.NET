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
        public DbSet<CommentEntity> Comments { get; set; }


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
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@wsei.edu.pl",
                NormalizedEmail = "ADMIN@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            var user1 = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            var user2 = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@wsei.edu.pl",
                NormalizedEmail = "GUEST@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            var adamk01 = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adamk01",
                NormalizedUserName = "ADAMK01",
                Email = "adamk01@gmail.com",
                NormalizedEmail = "ADAMK01@GMAIL.COM",
                EmailConfirmed = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

            user.PasswordHash = passwordHasher.HashPassword(user, "1234Ab!"); // admin
            user1.PasswordHash = passwordHasher.HashPassword(user1, "1928@AB"); // user
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Abc123#"); // guest
            adamk01.PasswordHash = passwordHasher.HashPassword(adamk01, "Adam123@"); // adam/user


            modelBuilder.Entity<IdentityUser>()
                .HasData(user, user1, user2, adamk01);

            //tworzenie roli

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "user",
                NormalizedName = "USER"
            };

            var guestRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "guest",
                NormalizedName = "GUEST"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            userRole.ConcurrencyStamp = userRole.Id;
            guestRole.ConcurrencyStamp = guestRole.Id;

            //nadanie użytkownikowi roli

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = userRole.Id,
                        UserId = user1.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = guestRole.Id,
                        UserId = user2.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = userRole.Id,
                        UserId = adamk01.Id
                    }
                );

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole, userRole, guestRole);


            modelBuilder.Entity<PhotoEntity>()
                .HasOne(e => e.Author)
                .WithMany(o => o.Photos)
                .HasForeignKey(k => k.AuthorId);

            modelBuilder.Entity<CommentEntity>()
                .HasOne(e => e.Photo)
                .WithMany(p => p.Comments)
                .HasForeignKey(k => k.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);

            


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
                },
                new AuthorEntity()
                {
                    Id = 103,
                    Name = "John",
                    Surname = "Doe",
                    Email = "john.doe@example.com"
                },
                new AuthorEntity()
                {
                    Id = 104,
                    Name = "Alice",
                    Surname = "Johnson",
                    Email = "alice.johnson@example.com"
                },
                new AuthorEntity()
                {
                    Id = 105,
                    Name = "Bob",
                    Surname = "Smith",
                    Email = "bob.smith@example.com"
                },
                new AuthorEntity()
                {
                    Id = 106,
                    Name = "Eva",
                    Surname = "Brown",
                    Email = "eva.brown@example.com"
                },
                new AuthorEntity()
                {
                    Id = 107,
                    Name = "Mike",
                    Surname = "Anderson",
                    Email = "mike.anderson@example.com"
                },
                new AuthorEntity()
                {
                    Id = 108,
                    Name = "Sophia",
                    Surname = "Miller",
                    Email = "sophia.miller@example.com"
                },
                new AuthorEntity()
                {
                    Id = 109,
                    Name = "David",
                    Surname = "Clark",
                    Email = "david.clark@example.com"
                },
                new AuthorEntity()
                {
                    Id = 110,
                    Name = "Olivia",
                    Surname = "Wilson",
                    Email = "olivia.wilson@example.com"
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
            },
            new PhotoEntity()
            {
                Id = 3,
                AuthorId = 103,
                Camera = "Samsung",
                DateAndTime = new DateTime(2022, 5, 15),
                Description = "Sunny day at the beach",
                Format = "_16x9",
                Resolution = "_2560x1440"
            },
            new PhotoEntity()
            {
                Id = 4,
                AuthorId = 104,
                Camera = "iPhone",
                DateAndTime = new DateTime(2023, 2, 8),
                Description = "Snowy mountains adventure",
                Format = "_21x9",
                Resolution = "_3840x2160"
            },
            new PhotoEntity()
            {
                Id = 5,
                AuthorId = 105,
                Camera = "Huawei",
                DateAndTime = new DateTime(2022, 8, 3),
                Description = "Sunset over the city",
                Format = "_16x9",
                Resolution = "_2560x1440"
            },
            new PhotoEntity()
            {
                Id = 6,
                AuthorId = 106,
                Camera = "LG",
                DateAndTime = new DateTime(2023, 11, 20),
                Description = "City lights at night",
                Format = "_21x9",
                Resolution = "_3840x2160"
            },
            new PhotoEntity()
            {
                Id = 7,
                AuthorId = 107,
                Camera = "Google Pixel",
                DateAndTime = new DateTime(2022, 4, 12),
                Description = "Cherry blossom in the park",
                Format = "_16x9",
                Resolution = "_2560x1440"
            },
            new PhotoEntity()
            {
                Id = 8,
                AuthorId = 108,
                Camera = "OnePlus",
                DateAndTime = new DateTime(2023, 9, 5),
                Description = "Majestic mountain view",
                Format = "_21x9",
                Resolution = "_3840x2160"
            },
            new PhotoEntity()
            {
                Id = 9,
                AuthorId = 109,
                Camera = "Xiaomi",
                DateAndTime = new DateTime(2022, 7, 18),
                Description = "Aerial view of the coastline",
                Format = "_16x9",
                Resolution = "_2560x1440"
            },
            new PhotoEntity()
            {
                Id = 10,
                AuthorId = 110,
                Camera = "Motorola",
                DateAndTime = new DateTime(2023, 1, 30),
                Description = "Night sky full of stars",
                Format = "_21x9",
                Resolution = "_3840x2160"
            }
        );

                    modelBuilder.Entity<CommentEntity>().HasData(
            new CommentEntity()
            {
                Id = 1,
                Comment = "Amazing shot!",
                PhotoId = 1,
                UserId = adamk01.Id
            },
            new CommentEntity()
            {
                Id = 2,
                Comment = "Spooky atmosphere!",
                PhotoId = 2,
                UserId = user1.Id
            },
            new CommentEntity()
            {
                Id = 3,
                Comment = "Beautiful beach day!",
                PhotoId = 3,
                UserId = user2.Id
            },
            new CommentEntity()
            {
                Id = 4,
                Comment = "Adventurous journey!",
                PhotoId = 4,
                UserId = user1.Id
            },
            new CommentEntity()
            {
                Id = 5,
                Comment = "Stunning sunset!",
                PhotoId = 5,
                UserId = user2.Id
            },
            new CommentEntity()
            {
                Id = 6,
                Comment = "City lights are magical!",
                PhotoId = 6,
                UserId = user.Id
            },
            new CommentEntity()
            {
                Id = 7,
                Comment = "Cherry blossoms are my favorite!",
                PhotoId = 7,
                UserId = user.Id
            },
            new CommentEntity()
            {
                Id = 8,
                Comment = "Impressive mountain view!",
                PhotoId = 8,
                UserId = user1.Id
            },
            new CommentEntity()
            {
                Id = 9,
                Comment = "Aerial views are mesmerizing!",
                PhotoId = 9,
                UserId = adamk01.Id
            },
            new CommentEntity()
            {
                Id = 10,
                Comment = "Starry night, truly magical!",
                PhotoId = 10,
                UserId = user2.Id
            }
        );


        }
    }
}
