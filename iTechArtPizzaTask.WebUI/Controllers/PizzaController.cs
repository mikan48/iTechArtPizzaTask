using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
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
        public async Task<List<Pizza>> GetAllAsync()
        {
            return await pizzasService.GetAllAsync();
        }

        [HttpPost("async")]
        public async Task<ActionResult<Pizza>> AddPizzaAsync(string pizzaName, double pizzaCost)
        {
            await pizzasService.AddPizzaAsync(pizzaName, pizzaCost);
            return Ok();
        }
    }
}
