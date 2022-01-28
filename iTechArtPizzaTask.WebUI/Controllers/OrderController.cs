using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
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
        private readonly IOrdersService ordersService;

        public OrderController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<List<OrderViewModel>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<OrderViewModel> orderVMs = await ordersService.GetAllAsync();

            var items = orderVMs.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPut("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Order>> Ordering(Guid id, Guid userId, DeliveryMethod deliveryMethod, Payment payment,
                                                        string adress, string commentary, string promocode)
        {
            await ordersService.Ordering(id, userId, deliveryMethod, payment, adress, commentary, promocode);
            return Ok();
        }
    }
}
