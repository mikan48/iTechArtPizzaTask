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
    public class IngridientController : ControllerBase
    {
        private readonly IIngridientsService ingridientsService;
        public IngridientController(IIngridientsService ingridientsService)
        {
            this.ingridientsService = ingridientsService;
        }

        [HttpPost("async")]
        public async Task<ActionResult<Ingridient>> AddIngridientAsync(string ingridientName)
        {
            await ingridientsService.AddIngridientAsync(ingridientName);
            return Ok();
        }
    }
}
