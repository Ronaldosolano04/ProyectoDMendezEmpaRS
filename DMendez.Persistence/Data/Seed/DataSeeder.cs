using System.Data;
using DMendez.Domain.Entities.Auth;
using DMendez.Domain.Entities.Menu;
using DMendez.Domain.Entities.Orders;
using DMendez.Domain.Entities.Payments;
using DMendez.Persistence.Data.Context;

namespace DMendez.Persistence.Data.Seed
{
    public static class DataSeeder
    {
        public static void SeedData(DMendezDbContext context)
        {
            // Seed Roles
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Administrador", Description = "Administrador del sistema" },
                    new Role { Name = "Cliente", Description = "Cliente regular" }
                };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            // Seed Categories
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Empanadas", Description = "Deliciosas empanadas" },
                    new Category { Name = "Bebidas", Description = "Bebidas refrescantes" },
                    new Category { Name = "Combos", Description = "Combos especiales" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            // Seed Products
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Empanada de Pollo",
                        Description = "Empanada rellena de pollo",
                        Price = 50.00m,
                        IsAvailable = true,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Name = "Empanada de Res",
                        Description = "Empanada rellena de res",
                        Price = 60.00m,
                        IsAvailable = true,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Name = "Coca Cola",
                        Description = "Bebida gaseosa 500ml",
                        Price = 30.00m,
                        IsAvailable = true,
                        CategoryId = 2
                    }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // Seed Order Statuses
            if (!context.OrderStatuses.Any())
            {
                var statuses = new List<OrderStatus>
                {
                    new OrderStatus { Name = "Pendiente", Description = "Pedido pendiente" },
                    new OrderStatus { Name = "Confirmado", Description = "Pedido confirmado" },
                    new OrderStatus { Name = "En Preparación", Description = "Pedido en preparación" },
                    new OrderStatus { Name = "Listo", Description = "Pedido listo" },
                    new OrderStatus { Name = "En Entrega", Description = "Pedido en camino" },
                    new OrderStatus { Name = "Entregado", Description = "Pedido entregado" },
                    new OrderStatus { Name = "Cancelado", Description = "Pedido cancelado" }
                };
                context.OrderStatuses.AddRange(statuses);
                context.SaveChanges();
            }

            // Seed Payment Methods
            if (!context.PaymentMethods.Any())
            {
                var methods = new List<PaymentMethod>
                {
                    new PaymentMethod { Name = "Efectivo", Description = "Pago en efectivo" },
                    new PaymentMethod { Name = "Tarjeta", Description = "Pago con tarjeta" },
                    new PaymentMethod { Name = "Stripe", Description = "Pago con Stripe" },
                    new PaymentMethod { Name = "PayPal", Description = "Pago con PayPal" },
                    new PaymentMethod { Name = "Azul", Description = "Pago con Azul" }
                };
                context.PaymentMethods.AddRange(methods);
                context.SaveChanges();
            }

            // Seed Payment Statuses
            if (!context.PaymentStatuses.Any())
            {
                var statuses = new List<PaymentStatus>
                {
                    new PaymentStatus { Name = "Pendiente", Description = "Pago pendiente" },
                    new PaymentStatus { Name = "Aprobado", Description = "Pago aprobado" },
                    new PaymentStatus { Name = "Rechazado", Description = "Pago rechazado" },
                    new PaymentStatus { Name = "Reembolsado", Description = "Pago reembolsado" }
                };
                context.PaymentStatuses.AddRange(statuses);
                context.SaveChanges();
            }
        }
    }
}