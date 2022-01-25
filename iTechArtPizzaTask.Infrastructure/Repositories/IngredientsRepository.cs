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
    public class IngredientsRepository : IRepository<Ingredient>
    {
        private readonly PizzaDeliveryContext context;
        public IngredientsRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Ingredient ingridient)
        {
            if(context.Ingredients.Where(b => b.IngredientName == ingridient.IngredientName).Count() == 0)
            {
                await context.Ingredients.AddAsync(new Ingredient 
                { 
                    IngredientName = ingridient.IngredientName,
                    IngredientCost = ingridient.IngredientCost
                });
                await context.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> FindItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ingredient> FindItemByNameAsync(string name)
        {
            Ingredient ingredient = await context.Ingredients.FirstOrDefaultAsync(b => b.IngredientName == name);
                
            return ingredient; 
        }

        public List<Ingredient> FindItemsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await context.Ingredients.ToListAsync();
        }

        public Task UpdateAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }
    }
}
