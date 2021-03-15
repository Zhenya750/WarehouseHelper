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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Loading> Loadings { get; set; }


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
                new Product
                {
                    Id = 1,
                    Name = "HP Pavilion",
                    Count = 5, MaxCount = 10,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed " +
                    "do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad min" +
                    "im veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea co" +
                    "mmodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit es" +
                    "se cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat " +
                    "non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },

                new Product
                {
                    Id = 2,
                    Name = "Lenovo",
                    Count = 1, MaxCount = 15,
                    Description = "Fermentum et sollicitudin ac orci phasellus. Viverra accumsan in" +
                    " nisl nisi scelerisque eu ultrices. Elementum facilisis leo vel fringilla. A i" +
                    "aculis at erat pellentesque adipiscing. Quam vulputate dignissim suspendisse i" +
                    "n est ante in nibh."
                },

                new Product
                {
                    Id = 3,
                    Name = "Acer notebook",
                    Count = 0, MaxCount = 25
                },
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
