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
    public class OrdersRepository : IRepository<Order>
    {
        private readonly PizzaDeliveryContext context;
        public OrdersRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> FindItemByIdAsync(Guid id)
        {
            Order order = await context.Orders.FindAsync(id);
            return order;
        }

        public Task<Order> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
