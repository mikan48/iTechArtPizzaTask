using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly IService<PromoCode> promocodeService;
        private readonly IService<Order> ordersService;

        public PromoCodeController(IService<PromoCode> promocodeService, IService<Order> ordersService)
        {
            this.promocodeService = promocodeService;
            this.ordersService = ordersService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin")]
        public async Task<List<PromoCode>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<PromoCode> promoCodes = await promocodeService.GetAllAsync();

            var items = promoCodes.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPost("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PromoCode>> AddAsync(string code, double discount, DateTime start, DateTime end)
        {
            PromoCode promoCode = new PromoCode()
            {
                Code = code,
                Discount = discount,
                StartDate = start,
                EndDate = end
            };
            await promocodeService.AddAsync(promoCode);

            return Ok();
        }

        [HttpPut("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<PromoCode>> AddPromoCodeToOrder(Guid orderId, string code)
        {
            Order order = await ordersService.FindItemByIdAsync(orderId);
            if(order == null)
            {
                return BadRequest("Order doesn't exist");
            }

            PromoCode promoCode = await promocodeService.FindItemByNameAsync(code);
            if (promoCode == null)
            {
                return BadRequest("Promo Code doesn't exist");
            }

            order.OrderCost *= (1 - promoCode.Discount);
            await ordersService.UpdateAsync(order);

            return Ok();
        }
    }
}
