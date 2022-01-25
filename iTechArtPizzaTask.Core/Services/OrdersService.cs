using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class OrdersService : IService<Order>
    {
        private readonly IRepository<Order> repository;
        public OrdersService(IRepository<Order> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task AddAsync(Order order)
        {
            await repository.AddAsync(order);
        }

        public Task DeleteAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> FindItemByIdAsync(Guid id)
        {
            return await repository.FindItemByIdAsync(id);
        }

        public Task<Order> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public List<Order> FindItemsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
