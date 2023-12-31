﻿using CarServiceWebConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceWebConsole.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<Worker>()
                .Property(w => w.Position)
                .HasConversion<string>();

            var workerParticipation = modelBuilder.Entity<WorkerParticipation>();
            workerParticipation.Property(wp => wp.Status)
                .HasConversion<string>();
            workerParticipation.Property(wp => wp.Comment)
                .HasDefaultValue(String.Empty);

            var order = modelBuilder.Entity<Order>();
            order.Property(o => o.Status)
                 .HasConversion<string>()
                 .HasDefaultValue(Status.NotViewed);
            order.Property(o => o.CreationDate)
                .HasDefaultValueSql("NOW()");
            order.Property(o => o.CompletionDate)
                .HasDefaultValue(null);

            var car = modelBuilder.Entity<Car>();
            car.Property(c => c.Brand)
                .HasMaxLength(10)
                .HasDefaultValue(null);
            car.Property(c => c.Model)
                .HasMaxLength(30)
                .HasDefaultValue(null);
            car.Property(c => c.ManufactureYear)
                .HasDefaultValue(null);
            car.Property(c => c.Vin).HasColumnType("char(17)");
            car.Property(c => c.StateNumber).HasColumnType("varchar(9)");
            car.HasIndex(c => c.StateNumber).IsUnique();
            car.HasIndex(c => c.Vin).IsUnique();

            var customer = modelBuilder.Entity<Customer>();
            customer.Property(c => c.Name).HasMaxLength(20);
            customer.Property(c => c.Patronymic).HasMaxLength(20);
            customer.Property(c => c.Surname).HasMaxLength(20);
            customer.Property(c => c.PhoneNumber).HasMaxLength(20);
            customer.Property(c => c.TelegramAlias)
                .HasMaxLength(20)
                .HasDefaultValue(null);
            customer.Property(c => c.VkAlias)
                .HasMaxLength(20)
                .HasDefaultValue(null);
            customer.HasIndex(c => c.PhoneNumber).IsUnique();
            customer.HasIndex(c => c.TelegramAlias).IsUnique();
            customer.HasIndex(c => c.VkAlias).IsUnique();

            var product = modelBuilder.Entity<Product>();
            product.Property(p => p.Name).HasMaxLength(50);
            var productPosition = modelBuilder.Entity<ProductPosition>();
            productPosition.Property(p => p.Name).HasMaxLength(50);

            var material = modelBuilder.Entity<Material>();
            material.Property(m => m.Name).HasMaxLength(50);
            var materialPosition = modelBuilder.Entity<MaterialPosition>();
            materialPosition.Property(m => m.Name).HasMaxLength(50);

            var service = modelBuilder.Entity<Service>();
            service.Property(s => s.Name).HasMaxLength(100);
            var servicePosition = modelBuilder.Entity<ServicePosition>();
            servicePosition.Property(s => s.Name).HasMaxLength(50);

            var worker = modelBuilder.Entity<Worker>();
            worker.Property(w => w.Name).HasMaxLength(20);
            worker.Property(w => w.Patronymic).HasMaxLength(20);
            worker.Property(w => w.Surname).HasMaxLength(20);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialPosition> MaterialPositions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPosition> ProductPositions { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicePosition> ServicePositions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerParticipation> WorkerParticipations { get; set; }
    }
}
