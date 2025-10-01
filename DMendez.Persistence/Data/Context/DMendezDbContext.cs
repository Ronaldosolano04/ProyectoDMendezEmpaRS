using System;
using System.Data;
using DMendez.Domain.Entities.Auth;
using DMendez.Domain.Entities.Menu;
using DMendez.Domain.Entities.Notifications;
using DMendez.Domain.Entities.Orders;
using DMendez.Domain.Entities.Payments;
using DMendez.Persistence.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace DMendez.Persistence.Data.Context
{
    public class DMendezDbContext : DbContext
    {
        public DMendezDbContext(DbContextOptions<DMendezDbContext> options) : base(options)
        {
        }

        // DbSets - Tablas de la base de datos
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboProduct> ComboProducts { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar todas las configuraciones
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
