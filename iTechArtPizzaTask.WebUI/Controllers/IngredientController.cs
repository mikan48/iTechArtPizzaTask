using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IIngredientsService ingridientsService;
        public IngredientController(IIngredientsService ingridientsService)
        {
            this.ingridientsService = ingridientsService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin")]
        public async Task<List<IngredientViewModel>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<IngredientViewModel> IngredientViewModel = await ingridientsService.GetAllAsync();

            var items = IngredientViewModel.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPost("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Ingredient>> AddAsync(string ingridientName, double ingridientCost)
        {
            await ingridientsService.AddAsync(ingridientName, ingridientCost);
            return Ok();
        }
    }
}
