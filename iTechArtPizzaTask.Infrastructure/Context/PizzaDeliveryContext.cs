using iTechArtPizzaTask.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Context
{
    public class PizzaDeliveryContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<OrderedPizza> OrderedPizzas { get; set; }
        public DbSet<PizzasIngredient> PizzasIngredients { get; set; }

        public PizzaDeliveryContext(DbContextOptions<PizzaDeliveryContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasMany(n => n.OrderedPizzas).WithOne(n => n.Order);
            modelBuilder.Entity<Pizza>().HasMany(n => n.OrderedPizzas).WithOne(n => n.Pizza);
            modelBuilder.Entity<Pizza>().HasMany(n => n.PizzasIngridients).WithOne(n => n.Pizza);
            modelBuilder.Entity<Ingredient>().HasMany(n => n.PizzasIngredients).WithOne(n => n.Ingredient);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });
        }
    }
}
