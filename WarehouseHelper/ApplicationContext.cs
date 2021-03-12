using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shipment> Shipments { get; set; }


        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "server=localhost;user=root;password=admin;database=WarehouseDB;";
            optionsBuilder.UseMySql(connection)
                .EnableDetailedErrors();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = new Product[]
            {
                new Product { Id = 1, Name = "HP Pavilion", Count = 5, MaxCount = 10 },
                new Product { Id = 2, Name = "Mac", Count = 7, MaxCount = 15 },
                new Product { Id = 3, Name = "Lenovo notebook", Count = 24, MaxCount = 30 },
            };

            modelBuilder.Entity<Product>().HasData(products);


            var clients = new Client[]
            {
                new Client { Id = 1, Name = "Tom", Email = "tom@mail.ru" },
                new Client { Id = 2, Name = "Mark", Email = "mark@ya.ru" },
                new Client { Id = 3, Name = "Leonardo" },
            };

            modelBuilder.Entity<Client>().HasData(clients);
        }
    }
}
