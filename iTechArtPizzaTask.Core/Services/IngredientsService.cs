using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IRepository<Ingredient> ingredientRepository;
        public IngredientsService(IRepository<Ingredient> ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }

        public async Task<List<IngredientViewModel>> GetAllAsync()
        {
            List<Ingredient> ingredients = await ingredientRepository.GetAllAsync();
            List<IngredientViewModel> ingredientVMs = new();
            if (ingredients != null)
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredientVMs.Add(new IngredientViewModel { IngredientName = ingredient.IngredientName });
                }
            }
            return ingredientVMs;
        }

        public async Task AddAsync(string ingridientName, double ingridientCost)
        {
            await ingredientRepository.AddAsync(new Ingredient()
            {
                IngredientName = ingridientName,
                IngredientCost = ingridientCost
            }
                );
        }
    }
}
