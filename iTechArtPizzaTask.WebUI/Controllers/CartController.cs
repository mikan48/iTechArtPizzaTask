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
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("async")]
        public async Task<List<OrderedPizza>> GetAllAsync()
        {
            return await cartService.GetAllAsync();
        }

        [HttpPost("async")]
        public async Task<ActionResult<OrderedPizza>> AddAsync(OrderedPizza orderedPizza)
        {
            await cartService.AddAsync(orderedPizza);
            return Ok();
        }

        [HttpDelete("async")]
        public async Task<ActionResult<OrderedPizza>> DeleteAsync(OrderedPizza orderedPizza)
        {
            await cartService.DeleteAsync(orderedPizza);
            return Ok();
        }

        //[HttpPut("async")]
        //public async Task<ActionResult<Pizza>> UpdateAsync(OrderedPizza orderedPizza)
        //{
        //    await cartService.UpdateAsync(orderedPizza);
        //    return Ok();
        //}
    }
}
