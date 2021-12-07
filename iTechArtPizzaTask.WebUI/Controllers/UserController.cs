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
    public class UserController : ControllerBase
    {
        private readonly IService<User> userService;

        public UserController(IService<User> userService)
        {
            this.userService = userService;
        }

        [HttpGet("async")]
        public async Task<List<User>> GetAllAsync()
        {
            return await userService.GetAllAsync();
        }

        [HttpPost("async")]
        public async Task<ActionResult<User>> AddAsync(User user)
        {
            await userService.AddAsync(user);
            return Ok();
        }
    }
}
