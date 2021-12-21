using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IService<Ingredient> ingridientsService;
        public IngredientController(IService<Ingredient> ingridientsService)
        {
            this.ingridientsService = ingridientsService;
        }

        [HttpGet("async")]
        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await ingridientsService.GetAllAsync();
        }

        [HttpPost("async")]
        public async Task<ActionResult<Ingredient>> AddAsync(string ingridientName, double ingridientCost)
        {
            await ingridientsService.AddAsync( new Ingredient()
            {
                IngredientName = ingridientName,
                IngredientCost = ingridientCost
            }
                );
            return Ok();
        }
    }
}
