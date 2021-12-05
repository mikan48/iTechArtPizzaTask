using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrderController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("async")]
        public async Task<List<Order>> GetAllAsync()
        {
            return await ordersService.GetAllAsync();
        }

        [HttpPost("async")]
        public async Task<ActionResult<Order>> AddAsync(Order order)
        {
            await ordersService.AddAsync(order);
            return Ok();
        }
    }
}
