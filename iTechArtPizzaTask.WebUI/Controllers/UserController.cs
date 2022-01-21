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
    public class UserController : ControllerBase
    {
        private readonly IService<User> userService;

        public UserController(IService<User> userService)
        {
            this.userService = userService;
        }

        [HttpGet("async")]
        [Authorize(Roles = "Admin")]
        public async Task<List<User>> GetAllAsync(int page = 1, int pageSize = 2)
        {
            List<User> users = await userService.GetAllAsync();

            var items = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return items;
        }

        [HttpPost("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> AddAsync(string firstName, string lastName, string email)
        {
            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
            };
            await userService.AddAsync(user);
            return Ok();
        }

        [HttpDelete("async")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> DeleteAsync(Guid userId)
        {
            User user = await userService.FindItemByIdAsync(userId);
            if(user == null)
            {
                return BadRequest("User doesn't exist");
            }

            await userService.DeleteAsync(user);

            return Ok();
        }
    }
}
