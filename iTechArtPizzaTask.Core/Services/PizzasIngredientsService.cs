using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class PizzasIngredientsService : IService<PizzasIngredient>
    {
        private readonly IRepository<PizzasIngredient> repository;
        public PizzasIngredientsService(IRepository<PizzasIngredient> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task AddAsync(PizzasIngredient pizzasIngredient)
        {
            await repository.AddAsync(pizzasIngredient);
        }

        public Task DeleteAsync(PizzasIngredient item)
        {
            throw new NotImplementedException();
        }

        public Task<PizzasIngredient> FindItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PizzasIngredient> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public List<PizzasIngredient> FindItemsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PizzasIngredient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PizzasIngredient item)
        {
            throw new NotImplementedException();
        }
    }
}
