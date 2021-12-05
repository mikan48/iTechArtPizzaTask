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
    public class CartsRepository : IRepository<OrderedPizza>
    {
        private readonly PizzaDeliveryContext context;
        public CartsRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public Task AddAsync(OrderedPizza orderedPizza)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(OrderedPizza orderedPizza)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderedPizza>> GetAllAsync()
        {
            return await context.OrderedPizzas.ToListAsync();
        }

        public Task UpdateAsync(OrderedPizza orderedPizza)
        {
            throw new NotImplementedException();
        }
    }
}
