using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Repositories
{
    public class IngridientsRepository : IIngridientsRepository
    {
        private readonly PizzaDeliveryContext context;
        public IngridientsRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }
        public async Task AddIngridientAsync(string ingridientName)
        {
            await context.Ingridients.AddAsync(new Ingridient { IngridientName = ingridientName });
            await context.SaveChangesAsync();
        }
    }
}
