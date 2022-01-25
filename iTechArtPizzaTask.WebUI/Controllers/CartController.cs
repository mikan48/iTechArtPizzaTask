using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
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
        private readonly IService<Order> cartService;
        private readonly IService<Pizza> pizzasService;
        private readonly IService<OrderedPizza> orderedPizzasService;

        public CartController(IService<Order> cartService, IService<Pizza> pizzasService, IService<OrderedPizza> orderedPizzasService)
        {
            this.cartService = cartService;
            this.pizzasService = pizzasService;
            this.orderedPizzasService = orderedPizzasService;
        }


        [HttpPost("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> AddAsync(Guid userId)
        {
            Order order = new Order
            {
                UserId = userId,
                Status = OrderStatuses.INCOMPLETE
            };
            await cartService.AddAsync(order);
            return Ok();
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<List<Pizza>> GetAllPizzasInCartAsync(Guid cartId, int page = 1, int pageSize = 2)
        {
            Order order = await cartService.FindItemByIdAsync(cartId);

            List<OrderedPizza> orderedPizzas = orderedPizzasService.FindItemsById(order.Id);
            List<Pizza> pizzas = new();
            Pizza pizza;
            foreach(OrderedPizza orderedPizza in orderedPizzas)
            {
                pizza = await pizzasService.FindItemByIdAsync(orderedPizza.PizzaId);
                pizzas.Add(pizza);
            }

            var items = pizzas.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }


        [HttpPut("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> AddPizzaInCartAsync(string pizzaName, int quantity, Guid cartId)
        {
            Order order = await cartService.FindItemByIdAsync(cartId);
            if(order == null)
            {
                return BadRequest("Cart doesn't exist");
            }

            Pizza pizza;

            pizza = await pizzasService.FindItemByNameAsync(pizzaName);
            if (pizza == null)
            {
                return BadRequest("Pizza doesn't exist");
            }

            double cost = pizza.PizzaCost * quantity;

            OrderedPizza orderedPizza = new OrderedPizza()
            {
                PizzaId = pizza.Id,
                Quantity = quantity,
                OrderId = order.Id
            };

            await orderedPizzasService.AddAsync(orderedPizza);

            List<OrderedPizza> orderedPizzas = new();
            orderedPizzas.Add(orderedPizza);

            order.OrderCost = cost;
            order.OrderedPizzas = orderedPizzas;
            order.Status = OrderStatuses.INCOMPLETE;

            await cartService.UpdateAsync(order);

            return Ok();
        }

        [HttpPatch("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> EditPizzasInCartAsync(string pizzaName, int quantity, Guid cartId)
        {
            Order order = await cartService.FindItemByIdAsync(cartId);
            if (order == null)
            {
                return BadRequest("Cart doesn't exist");
            }

            Pizza pizza;

            pizza = await pizzasService.FindItemByNameAsync(pizzaName);
            if (pizza == null)
            {
                return BadRequest("Pizza doesn't exist");
            }

            int oldQuantity = 0;

            List<OrderedPizza> orderedPizzas = orderedPizzasService.FindItemsById(cartId);
            foreach(OrderedPizza orderedPizza in orderedPizzas)
            {
                if(orderedPizza.PizzaId == pizza.Id)
                {
                    oldQuantity = orderedPizza.Quantity;
                    orderedPizza.Quantity = quantity;
                    await orderedPizzasService.UpdateAsync(orderedPizza);
                }
            }

            order.OrderCost += (quantity - oldQuantity) * pizza.PizzaCost;
            await cartService.UpdateAsync(order);

            return Ok();
        }

        [HttpDelete("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> DeletePizzaFromCartAsync(string pizzaName, Guid cartId)
        {
            Order order = await cartService.FindItemByIdAsync(cartId);
            if (order == null)
            {
                return BadRequest("Cart doesn't exist");
            }

            Pizza pizza = await pizzasService.FindItemByNameAsync(pizzaName);
            if (pizza == null)
            {
                return BadRequest("Pizza doesn't exist");
            }

            int quantity = 0;

            List<OrderedPizza> orderedPizzas = orderedPizzasService.FindItemsById(cartId);
            foreach (OrderedPizza orderedPizza in orderedPizzas)
            {
                if (orderedPizza.PizzaId == pizza.Id)
                {
                    quantity = orderedPizza.Quantity;
                    await orderedPizzasService.DeleteAsync(orderedPizza);
                }
            }

            order.OrderCost -= quantity * pizza.PizzaCost;
            await cartService.UpdateAsync(order);

            return Ok();
        }
    }
}
