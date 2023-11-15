using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }

        private string Path { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(k => k.OrganizationId);// withone - skalar, withmany - kolekcja

            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 101,
                        Name = "WSEI",
                        Description = "Uczelnia wyższa"
                    },
                    new OrganizationEntity()
                    {
                        Id = 102,
                        Name = "Koło studenckie spacecraft",
                        Description = "Robia se spacecrafta"
                    }
                );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "baartek@o2.pl", Phone = "123123123", OrganizationId = 102 },
                new ContactEntity() { Id = 2, Name = "Michal", Email = "michal@o2.pl", Phone = "325476666", OrganizationId = 101 },
                new ContactEntity() { Id = 3, Name = "Jakub", Email = "kubuniu@o2.pl", Phone = "897895473", OrganizationId = 101 });

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new
                    {
                        OrganizationEntityId = 101,
                        City = "Kraków",
                        Street = "św. Filipa 17",
                        PostalCode = "31-150"
                    },
                    new
                    {
                        OrganizationEntityId = 102,
                        City = "Kraków",
                        Street = "św. Filipa 17",
                        PostalCode = "31-150"
                    }
                );
        }
    }
}
