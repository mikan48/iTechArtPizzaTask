﻿using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Repositories.Fakes;
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
        PizzaRepository pizzasRepository = new PizzaRepository();

        [HttpGet]
        public List<Pizza> GetAll()
        {
            return pizzasRepository.GetPizzas();
        }
    }
}
