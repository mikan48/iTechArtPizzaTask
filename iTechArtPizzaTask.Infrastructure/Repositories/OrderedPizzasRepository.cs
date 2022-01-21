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
    public class OrderedPizzasRepository : IRepository<OrderedPizza>
    {
        private readonly PizzaDeliveryContext context;
        public OrderedPizzasRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(OrderedPizza orderedPizza)
        {
            await context.AddAsync(orderedPizza);
        }

        public async Task DeleteAsync(OrderedPizza orderedPizza)
        {
            context.OrderedPizzas.Remove(context.OrderedPizzas.Where(p => p.Id == orderedPizza.Id).FirstOrDefault());
            await context.SaveChangesAsync();
        }

        public async Task<OrderedPizza> FindItemByIdAsync(Guid id)
        {
            OrderedPizza orderedPizza = await context.OrderedPizzas.FindAsync(id);
            return orderedPizza;
        }

        public Task<OrderedPizza> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderedPizza>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderedPizza item)
        {
            throw new NotImplementedException();
        }
    }
}
