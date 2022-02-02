using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [HttpPost("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> AddAsync(Guid userId)
        {
            await cartService.AddAsync(userId);
            return Ok();
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<List<PizzaViewModel>> GetAllPizzasInCartAsync(Guid cartId, int page = 1, int pageSize = 2)
        {
            List<PizzaViewModel> pizzaVM = await cartService.GetAllPizzasInCartAsync(cartId);

            var items = pizzaVM.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }


        [HttpPut("async")]
        //[Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> AddPizzaInCartAsync(string pizzaName, int quantity, Guid cartId)
        {
            await cartService.AddPizzaInCartAsync(pizzaName, quantity, cartId);

            return Ok();
        }

        [HttpPatch("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> EditPizzasInCartAsync(string pizzaName, int quantity, Guid cartId)
        {
            await cartService.EditPizzasInCartAsync(pizzaName, quantity, cartId);

            return Ok();
        }

        [HttpDelete("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> DeletePizzaFromCartAsync(string pizzaName, Guid cartId)
        {
            var res = await cartService.DeletePizzaFromCartAsync(pizzaName, cartId);
            if(res != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
