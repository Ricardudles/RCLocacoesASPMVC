using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntity(modelBuilder);
            DisableDeleteCascade(modelBuilder);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>().HasKey(p => p.Id);
            //modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar(100)");
            //modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Product>().Property(p => p.RentPrice).HasColumnType("decimal(18,2)").IsRequired();
            //modelBuilder.Entity<Product>().Property(p => p.ReplacementCost).HasColumnType("decimal(18,2)").IsRequired();
            //modelBuilder.Entity<Product>().Property(p => p.Inactive).HasColumnType("bit").IsRequired();
            //modelBuilder.Entity<Product>().Property(p => p.Picture).HasColumnType("varchar(MAX)");

            //modelBuilder.Entity<Category>().HasKey(p => p.Id);
            //modelBuilder.Entity<Category>().Property(p => p.Name).HasColumnType("varchar(100)");

            //modelBuilder.Entity<ProductCategory>().HasKey(p => p.Id);

            //modelBuilder.Entity<Local>().HasKey(p => p.Id);

            //modelBuilder.Entity<Client>().HasKey(p => p.Id);


            //modelBuilder.Entity<ClientType>().HasKey(p => p.Id);


            //modelBuilder.Entity<Order>().HasKey(p => p.Id);


            //modelBuilder.Entity<OrderProduct>().HasKey(p => new { p.ProductId, p.OrderId });
            //modelBuilder.Entity<OrderProduct>().Property(p => p.RentPrice).HasColumnType("decimal(18,2)").IsRequired();
            //modelBuilder.Entity<OrderProduct>().Property(p => p.ReplacementCost).HasColumnType("decimal(18,2)").IsRequired();

            //modelBuilder.Entity<Status>().HasKey(p => p.Id);

        }

        private void MapEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void DisableDeleteCascade(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }

}
