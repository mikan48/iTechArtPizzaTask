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
    public class PizzasRepository : IPizzasRepository
    {
        private readonly PizzaDeliveryContext context;
        public PizzasRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public async Task<List<Pizza>> GetAllPizzasAsync()
        {
            return await context.Pizzas.ToListAsync();
        }

        //wip
        public async Task AddPizzaAsync(string pizzaName, double pizzaCost)
        {
            await context.Pizzas.AddAsync(new Pizza
            {
                PizzaName = pizzaName,
                PizzaCost = pizzaCost
                //Ingridients = ingridients
            }
                );
            await context.SaveChangesAsync();
        }
        
        public async Task DeletePizzaAsync(string pizzaName)
        {
            context.Pizzas.Remove(context.Pizzas.Where(b => b.PizzaName == pizzaName).FirstOrDefault());
            await context.SaveChangesAsync();
        }
    }
}
