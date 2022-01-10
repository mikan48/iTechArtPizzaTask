using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IService<Order> ordersService;

        public OrderController(IService<Order> ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<List<Order>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<Order> orders = await ordersService.GetAllAsync();

            var items = orders.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPut("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> Ordering(Guid id, Guid userId, DeliveryMethod deliveryMethod, Payment payment,
                                                        string adress, string commentary)
        {
            Order order = await ordersService.FindItemByIdAsync(id);
            if (order == null)
            {
                return BadRequest("Order doesn't exist");
            }

            order.UserId = userId;
            order.DeliveryMethod = deliveryMethod;
            order.Payment = payment;
            order.DestinationAddress = adress;
            order.OrderCommentary = commentary;
            order.Status = OrderStatuses.ORDERED;

            await ordersService.AddAsync(order);
            return Ok();
        }
    }
}
