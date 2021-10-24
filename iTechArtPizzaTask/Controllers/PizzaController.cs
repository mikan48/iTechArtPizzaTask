using iTechArtPizzaTask.Interfaces;
using iTechArtPizzaTask.Models;
using iTechArtPizzaTask.Repositories.Fakes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace iTechArtPizzaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        PizzasRepository pizzasRepository = new PizzasRepository();

        [HttpGet]
        public List<Pizza> GetAll()
        {
            return pizzasRepository.GetPizzas();
        }
    }
}
