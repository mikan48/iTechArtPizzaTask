using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Repositories
{
    public class PizzasIngredientsRepository : IRepository<PizzasIngredient>
    {
        private readonly PizzaDeliveryContext context;
        public PizzasIngredientsRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(PizzasIngredient pizzasIngredient)
        {
            await context.PizzasIngredients.AddAsync(pizzasIngredient);
            await context.SaveChangesAsync();
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
