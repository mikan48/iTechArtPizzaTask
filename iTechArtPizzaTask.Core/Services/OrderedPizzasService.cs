using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class OrderedPizzasService : IService<OrderedPizza>
    {
        private readonly IRepository<OrderedPizza> repository;
        public OrderedPizzasService(IRepository<OrderedPizza> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task AddAsync(OrderedPizza orderedPizza)
        {
            await repository.AddAsync(orderedPizza);
        }

        public async Task DeleteAsync(OrderedPizza orderedPizza)
        {
            await repository.DeleteAsync(orderedPizza);
        }

        public async Task<OrderedPizza> FindItemByIdAsync(Guid id)
        {
            return await repository.FindItemByIdAsync(id);
        }

        public Task<OrderedPizza> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public List<OrderedPizza> FindItemsById(Guid id)
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
