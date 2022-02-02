using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
using iTechArtPizzaTask.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class PizzasService : IPizzasService
    {
        private readonly IRepository<Pizza> pizzaRepository;
        private readonly IRepository<Ingredient> ingredientRepository;
        private readonly IRepository<PizzasIngredient> pizzaIngredientRepository;
        public PizzasService(IRepository<Pizza> pizzaRepository, IRepository<Ingredient> ingredientRepository, IRepository<PizzasIngredient> pizzaIngredientRepository)
        {
            this.pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            this.ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
            this.pizzaIngredientRepository = pizzaIngredientRepository ?? throw new ArgumentNullException(nameof(pizzaIngredientRepository));
        }

        public async Task AddPizzaAsync(string pizzaName)
        {
            Pizza pizza = new Pizza()
            {
                PizzaName = pizzaName
            };
            await pizzaRepository.AddAsync(pizza);
        }

        public async Task DeletePizzaAsync(string pizzaName)
        {
            Pizza pizza;

            pizza = await pizzaRepository.FindItemByNameAsync(pizzaName);
            if (pizza != null)
            {
                await pizzaRepository.DeleteAsync(pizza);
            }
        }

        public async Task AddPizzasIngredientsAsync(string pizzaName, string[] ingridientNames)
        {
            Pizza pizza;

            pizza = await pizzaRepository.FindItemByNameAsync(pizzaName);
            if (pizza != null)
            {
                Ingredient ingredient;
                List<Ingredient> ingredients = new();
                List<PizzasIngredient> pizzasIngredients = new();
                PizzasIngredient pizzasIngredient;

                double cost;
                if (pizza.PizzaCost != 0)
                {
                    cost = pizza.PizzaCost;
                }
                else
                {
                    cost = 0;
                }

                for (int i = 0; i < ingridientNames.Length; i++)
                {
                    ingredient = await ingredientRepository.FindItemByNameAsync(ingridientNames[i]);
                    if (ingredient != null)
                    {
                        ingredients.Add(ingredient);
                    }
                }
                foreach (Ingredient ingr in ingredients)
                {
                    cost += ingr.IngredientCost;
                    pizzasIngredient = new PizzasIngredient
                    {
                        PizzaId = pizza.Id,
                        IngredientId = ingr.Id,
                        ingredientCost = ingr.IngredientCost
                    };
                    await pizzaIngredientRepository.AddAsync(pizzasIngredient);
                    pizzasIngredients.Add(pizzasIngredient);
                }

                pizza.PizzaName = pizzaName;
                pizza.PizzaCost = cost;
                pizza.PizzasIngridients = pizzasIngredients;

                await pizzaRepository.UpdateAsync(pizza);
            }
        }

        public async Task<List<PizzaViewModel>> GetAllPizzasAsync()
        {
            List<Pizza> pizzas = await pizzaRepository.GetAllAsync();
            List<PizzaViewModel> pizzasVM = new List<PizzaViewModel>();
            foreach(Pizza pizza in pizzas)
            {
                pizzasVM.Add(new PizzaViewModel { PizzaName = pizza.PizzaName, PizzaCost = pizza.PizzaCost});
            }
            return pizzasVM;
        }

        public async Task<PizzaInfoViewModel> GetPizzaInfoAsync(string pizzaName)
        {
            Pizza pizza = await pizzaRepository.FindItemByNameAsync(pizzaName);
            if(pizza != null)
            {
                List<PizzasIngredient> pizzasIngredients = pizzaIngredientRepository.FindItemsById(pizza.Id);
                List<IngredientViewModel> ingredients = new();
                Ingredient ingredient;
                foreach(PizzasIngredient pizzasIngredient in pizzasIngredients)
                {
                    ingredient = await ingredientRepository.FindItemByIdAsync(pizzasIngredient.IngredientId);
                    if(ingredient != null)
                    {
                        ingredients.Add(new IngredientViewModel { IngredientName = ingredient.IngredientName });
                    }
                }
                PizzaInfoViewModel pizzaInfo = new PizzaInfoViewModel { PizzaName = pizza.PizzaName, PizzaCost = pizza.PizzaCost, Ingredients = ingredients };

                return pizzaInfo;
            }

            return null;
        }
    }
}
