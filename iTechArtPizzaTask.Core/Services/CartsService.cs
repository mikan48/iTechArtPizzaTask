using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class CartsService : ICartService
    {
        private readonly IRepository<OrderedPizza> repository;
        public CartsService(IRepository<OrderedPizza> repository)
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

        public async Task<List<OrderedPizza>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task UpdateAsync(OrderedPizza orderedPizza)
        {
            await repository.UpdateAsync(orderedPizza);
        }
    }
}
