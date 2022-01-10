using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class IngredientsService : IService<Ingredient>
    {
        private readonly IRepository<Ingredient> repository;
        public IngredientsService(IRepository<Ingredient> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            await repository.AddAsync(ingredient);
        }

        //
        public Task UpdateAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }

        public async Task<Ingredient> FindItemByNameAsync(string name)
        {
            return await repository.FindItemByNameAsync(name);
        }

        public Task<Ingredient> FindItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
