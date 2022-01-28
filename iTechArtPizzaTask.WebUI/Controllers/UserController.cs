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
    public class UserController : ControllerBase
    {
        private readonly IUsersService userService;

        public UserController(IUsersService userService)
        {
            this.userService = userService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin")]
        public async Task<List<UserViewModel>> GetAllUsersWithOrdersAsync(int page = 1, int pageSize = 2)
        {
            List<UserViewModel> users = await userService.GetAllUsersWithOrdersAsync();

            var items = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpDelete("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> DeleteAsync(Guid userId)
        {
            await userService.DeleteAsync(userId);

            return Ok();
        }
    }
}
