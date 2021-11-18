using iTechArtPizzaTask.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Context
{
    public class PizzaDeliveryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pizzadeliverydb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasMany(left => left.Ingridients)
                .WithMany(right => right.Pizzas)
                .UsingEntity<IngridientPizza>(
                    right => right.HasOne(e => e.Ingridient).WithMany().HasForeignKey(e => e.IngridientId),
                    left => left.HasOne(e => e.Pizza).WithMany().HasForeignKey(e => e.PizzaId),
                    join => join.ToTable("IngridientPizzas")
            );

            modelBuilder.Entity<Order>()
                .HasMany(left => left.Pizzas)
                .WithMany(right => right.Orders)
                .UsingEntity<OrderPizza>(
                    right => right.HasOne(e => e.Pizza).WithMany().HasForeignKey(e => e.PizzaId),
                    left => left.HasOne(e => e.Order).WithMany().HasForeignKey(e => e.OrderId),
                    join => join.ToTable("OrderPizzas")
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Anton"
                },
                new User
                {
                    UserId = 2,
                    Name = "Kate"
                }
            );
            modelBuilder.Entity<Pizza>().HasData(
                    new Pizza
                    {
                        PizzaId = 1,
                        PizzaName = "Carbonara"
                    },
                    new Pizza
                    {
                        PizzaId = 2,
                        PizzaName = "Pepperoni"
                    }
            );
            modelBuilder.Entity<Ingridient>().HasData(
                new Ingridient
                {
                    IngridientId = 1,
                    IngridientName = "Cheese"
                },
                new Ingridient
                {
                    IngridientId = 2,
                    IngridientName = "Bacon"
                },
                new Ingridient
                {
                    IngridientId = 3,
                    IngridientName = "Sauce"
                },
                new Ingridient
                {
                    IngridientId = 4,
                    IngridientName = "Pepperoni"
                },
                new Ingridient
                {
                    IngridientId = 5,
                    IngridientName = "Pineapple"
                }
            );
            modelBuilder.Entity<IngridientPizza>().HasData(
                new IngridientPizza { PizzaId = 1, IngridientId = 1 },
                new IngridientPizza { PizzaId = 1, IngridientId = 2 },
                new IngridientPizza { PizzaId = 1, IngridientId = 3 },
                new IngridientPizza { PizzaId = 2, IngridientId = 1 },
                new IngridientPizza { PizzaId = 2, IngridientId = 3 },
                new IngridientPizza { PizzaId = 2, IngridientId = 4 }
                );
        }

    }
}
