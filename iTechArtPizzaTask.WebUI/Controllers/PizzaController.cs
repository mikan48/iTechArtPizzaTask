using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.Services;
using iTechArtPizzaTask.Infrastructure.Context;
using iTechArtPizzaTask.WebUI.Models;
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
        private readonly IPizzasService pizzasService;

        public PizzaController(IPizzasService pizzasService)
        {
            this.pizzasService = pizzasService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<List<PizzaViewModel>> GetAllPizzasAsync(int page = 1, int pageSize = 2)
        {
            List<PizzaViewModel> pizzas = await pizzasService.GetAllPizzasAsync();            

            var items = pizzas.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPost("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Pizza>> AddPizzaAsync(string pizzaName)
        {
            await pizzasService.AddPizzaAsync(pizzaName);

            return Ok();
        }

        [HttpPut("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Pizza>> AddPizzasIngredientsAsync(string pizzaName, string[] ingridientNames)
        {
            await pizzasService.AddPizzasIngredientsAsync(pizzaName, ingridientNames);

            return Ok();
        }

        [HttpDelete("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Pizza>> DeleteAsync(string pizzaName)
        {
            await pizzasService.DeletePizzaAsync(pizzaName);
            return Ok();
        }
    }
}
