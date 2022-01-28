using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
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
        private readonly IPromoCodesService promocodeService;

        public PromoCodeController(IPromoCodesService promocodeService)
        {
            this.promocodeService = promocodeService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin")]
        public async Task<List<PromoCodeViewModel>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<PromoCodeViewModel> promoCodes = await promocodeService.GetAllAsync();

            var items = promoCodes.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPost("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PromoCode>> AddAsync(string code, double discount, DateTime start, DateTime end)
        {
            await promocodeService.AddAsync(code, discount, start, end);

            return Ok();
        }

        [HttpPut("async")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<PromoCode>> AddPromoCodeToOrder(Guid orderId, string code)
        {
            await promocodeService.AddPromoCodeToOrder(orderId, code);

            return Ok();
        }
    }
}
