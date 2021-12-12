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
    public class CartController : ControllerBase
    {
        private readonly IService<Order> cartService;

        public CartController(IService<Order> cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("async")]
        public async Task<List<Order>> GetAllAsync()
        {
            return await cartService.GetAllAsync();
        }

        [HttpPost("async")]
        public async Task<ActionResult<Order>> AddAsync(Order order)
        {
            await cartService.AddAsync(order);
            return Ok();
        }

        [HttpDelete("async")]
        public async Task<ActionResult<Order>> DeleteAsync(Order order)
        {
            await cartService.DeleteAsync(order);
            return Ok();
        }

        [HttpPut("async")]
        public async Task<ActionResult<Pizza>> UpdateAsync(Order order)
        {
            await cartService.UpdateAsync(order);
            return Ok();
        }
    }
}
