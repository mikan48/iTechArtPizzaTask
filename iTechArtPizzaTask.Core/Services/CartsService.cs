using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class CartsService : IService<Order>
    {
        private readonly IRepository<Order> repository;
        public CartsService(IRepository<Order> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task AddAsync(Order order)
        {
            await repository.AddAsync(order);
        }

        public async Task DeleteAsync(Order order)
        {
            await repository.DeleteAsync(order);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            await repository.UpdateAsync(order);
        }
    }
}
