using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.Services;
using iTechArtPizzaTask.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace iTechArtPizzaTask.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IService<Pizza> pizzasService;
        private readonly IService<Ingredient> ingredientService;
        private readonly IService<PizzasIngredient> pizzasIngredientService;

        public PizzaController(IService<Pizza> pizzasService, IService<Ingredient> ingredientService,
                                IService<PizzasIngredient> pizzasIngredientService)
        {
            this.pizzasService = pizzasService;
            this.ingredientService = ingredientService;
            this.pizzasIngredientService = pizzasIngredientService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<List<Pizza>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<Pizza> pizzas = await pizzasService.GetAllAsync();            

            var items = pizzas.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPost("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Pizza>> AddAsync(string pizzaName)
        {
            Pizza pizza = new Pizza()
            {
                PizzaName = pizzaName
            };
            await pizzasService.AddAsync(pizza);

            return Ok();
        }

        [HttpPut("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Pizza>> AddIngredientsAsync(string pizzaName, string[] ingridientNames)
        {
            Pizza pizza;

            pizza = await pizzasService.FindItemByNameAsync(pizzaName);
            if(pizza == null)
            {
                return BadRequest("Pizza doesn't exist");
            }

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

            for(int i = 0; i < ingridientNames.Length; i++)
            {
                ingredient = await ingredientService.FindItemByNameAsync(ingridientNames[i]);
                if(ingredient != null)
                {
                    ingredients.Add(ingredient);
                }
            }
            foreach (Ingredient ingred in ingredients)
            {
                cost += ingred.IngredientCost;
                pizzasIngredient = new PizzasIngredient
                {
                    PizzaId = pizza.Id,
                    IngredientId = ingred.Id,
                    ingredientCost = ingred.IngredientCost
                };
                await pizzasIngredientService.AddAsync(pizzasIngredient);
                pizzasIngredients.Add(pizzasIngredient);
            }

            pizza.PizzaName = pizzaName;
            pizza.PizzaCost = cost;
            pizza.PizzasIngridients = pizzasIngredients;

            await pizzasService.UpdateAsync(pizza);

            return Ok();
        }

        [HttpDelete("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Pizza>> DeleteAsync(string pizzaName)
        {
            await pizzasService.DeleteAsync(new Pizza()
            {
                PizzaName = pizzaName
            }
                );
            return Ok();
        }
    }
}
