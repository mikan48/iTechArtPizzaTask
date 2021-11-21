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
    public class OrdersRepository : IOrdersRepository
    {
        private readonly PizzaDeliveryContext context;
        public OrdersRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await context.Orders.ToListAsync();
        }
    }
}
