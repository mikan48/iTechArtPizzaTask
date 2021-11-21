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
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await ordersService.GetAllOrdersAsync();
        }
    }
}
