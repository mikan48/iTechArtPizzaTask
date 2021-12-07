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
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<OrderedPizza> OrderedPizzas { get; set; }
        public DbSet<PizzasIngredient> PizzasIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pizzadeliverydb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(n => n.OrderedPizzas).WithOne(n => n.Order);
            modelBuilder.Entity<Pizza>().HasMany(n => n.OrderedPizzas).WithOne(n => n.Pizza);
            modelBuilder.Entity<Pizza>().HasMany(n => n.PizzasIngridients).WithOne(n => n.Pizza);
            modelBuilder.Entity<Ingredient>().HasMany(n => n.PizzasIngredients).WithOne(n => n.Ingredient);
        }

    }
}
