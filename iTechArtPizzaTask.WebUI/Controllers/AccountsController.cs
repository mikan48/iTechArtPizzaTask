﻿using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private IConfiguration _configuration;

        public AccountsController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("/register")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return BadRequest("User already exists");
            }
            user = new User
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

        [HttpPost("/login")]
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

            var roles = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("role", roles.FirstOrDefault() ?? "")
            };

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
            );
        }
    }
}
