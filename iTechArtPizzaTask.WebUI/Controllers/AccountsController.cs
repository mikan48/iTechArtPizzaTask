using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.WebUI.Models;
using Microsoft.AspNetCore.Identity;
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
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("/register")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
                Name = model.Name
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        //wip

        [HttpGet("/login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if(user == null)
            {
                return Unauthorized("No such user");
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized("Wrong password");
            }

            //wip

            //var roles = await _userManager.GetRolesAsync(user);
            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim("id", user.Id.ToString()),
            //    new Claim("name", user.Name),
            //    new Claim("role", roles.FirstOrDefault() ?? "")
            //};




            return Ok();
        }
    }
}
