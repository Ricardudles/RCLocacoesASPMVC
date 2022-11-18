using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<Local> Locals { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<ClientType> ClientTypes { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderProduct> OrderProducts { get; set; }
        //public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar(100)");
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("varchar(250)");
            modelBuilder.Entity<Product>().Property(p => p.RentPrice).HasColumnType("decimal(18,2)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ReplacementCost).HasColumnType("decimal(18,2)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Inactive).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Picture).HasColumnType("varchar(MAX)");

            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().Property(p => p.Name).HasColumnType("varchar(100)");

            modelBuilder.Entity<ProductCategory>().HasKey(p => p.Id);

            modelBuilder.Entity<Local>().HasKey(p => p.Id);


            modelBuilder.Entity<Address>().HasKey(p => p.Id);


            modelBuilder.Entity<Client>().HasKey(p => p.Id);


            modelBuilder.Entity<ClientType>().HasKey(p => p.Id);


            modelBuilder.Entity<Order>().HasKey(p => p.Id);


            modelBuilder.Entity<OrderProduct>().HasKey(p => new { p.ProductId, p.OrderId });
            modelBuilder.Entity<OrderProduct>().Property(p => p.RentPrice).HasColumnType("decimal(18,2)").IsRequired();
            modelBuilder.Entity<OrderProduct>().Property(p => p.ReplacementCost).HasColumnType("decimal(18,2)").IsRequired();

            modelBuilder.Entity<Status>().HasKey(p => p.Id);


        }
    }

}
