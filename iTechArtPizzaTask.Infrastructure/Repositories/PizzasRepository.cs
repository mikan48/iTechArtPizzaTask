using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Repositories
{
    public class PizzasRepository : IRepository<Pizza>
    {
        private readonly PizzaDeliveryContext context;
        public PizzasRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await context.Pizzas.ToListAsync();
        }

        public async Task AddAsync(Pizza pizza)
        {
            if (context.Pizzas.Where(b => b.PizzaName == pizza.PizzaName).Count() == 0)
            {
                await context.Pizzas.AddAsync(new Pizza
                {
                    PizzaName = pizza.PizzaName,
                    PizzaCost = pizza.PizzaCost
                }
                );
                await context.SaveChangesAsync();
            }               
        }
        
        public async Task DeleteAsync(Pizza pizza)
        {
            context.Pizzas.Remove(context.Pizzas.Where(b => b.PizzaName == pizza.PizzaName).FirstOrDefault());
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pizza item)
        {
            throw new NotImplementedException();
        }
    }
}
