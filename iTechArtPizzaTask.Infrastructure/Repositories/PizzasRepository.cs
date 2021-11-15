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
        public async Task<List<Pizza>> GetAllAsync()
        {
            return await context.Pizzas.ToListAsync();
        }
    }
}
