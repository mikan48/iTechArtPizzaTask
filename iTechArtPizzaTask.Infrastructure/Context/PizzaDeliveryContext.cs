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
        public DbSet<IngridientPizza> IngridientPizzas { get; set; }
        public DbSet<OrderPizza> OrderPizzas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pizzadeliverydb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngridientPizza>().HasKey(t => new { t.IngridientId, t.PizzaId });

            modelBuilder.Entity<OrderPizza>().HasKey(t => new { t.OrderId, t.PizzaId });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "Anton"
                },
                new User
                {
                    UserId = 2,
                    UserName = "Kate"
                }
            );
            modelBuilder.Entity<Pizza>().HasData(
                    new Pizza(1, "Carbonara"),
                    new Pizza(2, "Pepperoni")
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
                new { PizzaId = 1, IngridientId = 1 },
                new { PizzaId = 1, IngridientId = 2 },
                new { PizzaId = 1, IngridientId = 3 },
                new { PizzaId = 2, IngridientId = 1 },
                new { PizzaId = 2, IngridientId = 3 },
                new { PizzaId = 2, IngridientId = 4 }
                );

        }

    }
}
