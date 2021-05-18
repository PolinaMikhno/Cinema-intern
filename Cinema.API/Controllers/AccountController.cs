using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.DAL.Auth;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.Services.Models;
using Cinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Cinema.API.Controllers
{
    public class AccountController : Controller
    {
        private Service<UserModel, UserEntity> _userService;

        public AccountController(IRepository<UserEntity> repository, IMapper mapper,
            IWebHostEnvironment environment)
        {
            _userService = new Service<UserModel, UserEntity>(repository, mapper, environment);
        }


        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(string username, string password, string confirmPassword)
        {
            if (!password.Equals(confirmPassword))
            {
                return BadRequest("Passwords are not same");
            }

            IEnumerable<UserModel> possibleExistingUserEnumerable =
                await _userService.GetAsync(u => u.Name.Equals(username));

            if (possibleExistingUserEnumerable.Any())
            {
                return BadRequest("This username is already exists");
            }

            await _userService.CreateAsync(new UserModel(username, password));

            return Ok("Ok");
        }

        [HttpPost("/token")]
        public async Task<ActionResult> Token(string name, string password)
        {
            ClaimsIdentity identity = await GetIdentity(name, password);
            if (identity == null)
            {
                return BadRequest(new {errorText = "Invalid username or password."});
            }

            DateTime now = DateTime.UtcNow;
            JwtSecurityToken jwt = new JwtSecurityToken(
                AuthOptions.Issuer,
                AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        [Authorize(Roles = "User")]
        [HttpPost("/tokentest")]
        public ActionResult TokenTest()
        {
            return Ok("Ok(Ok)");
        }

        private async Task<ClaimsIdentity> GetIdentity(string name, string password)
        {
            IEnumerable<UserModel> userEnumerable =
                await _userService.GetAsync(u => u.Name.Equals(name) && u.CheckPassword(password));
            /*Console.WriteLine(
                $"Found user with specified name and password: {userEnumerable.Any()} ({name} {password})");*/
            UserModel userModel = userEnumerable.FirstOrDefault();
            if (userModel != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userModel.Role)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}