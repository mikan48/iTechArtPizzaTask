using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        }
        //wip
        public Task AddOrderAsync()
        {
            throw new NotImplementedException();
        }
        //wip
        public Task AddPromoCodeToOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await ordersRepository.GetAllOrdersAsync();
        }
    }
}
