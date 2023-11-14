using Microsoft.EntityFrameworkCore;
using ProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class AppDbContext : DbContext
    {
        public DbSet<PhotoEntity> Photos { get; set; }
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
            modelBuilder.Entity<PhotoEntity>().HasData(
                new PhotoEntity() { Id = 1, Author = "Max Pietrucha", Camera = "Nikon", DateAndTime= new DateTime(2022,12,22), Description = "My best photo from the Kryspinów lake", Format = "_16x9", Resolution = "_2560x1440" },
                new PhotoEntity() { Id = 2, Author = "Alex Sulek", Camera = "Sony", DateAndTime = new DateTime(2023, 10, 31), Description = "Halloween party photo", Format = "_21x9", Resolution = "_3840x2160" }
                );
        }
    }
}
