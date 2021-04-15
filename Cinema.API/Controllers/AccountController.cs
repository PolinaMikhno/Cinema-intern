using System;
using System.Security.Claims;
using Cinema.DAL.Auth;
using Cinema.DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    public class AccountController : Controller
    {
        private Repository<User> users;

        public AccountController()
        {
            users = new Repository<User>();
        }

        [HttpPost("/token")]
        public ActionResult Token()
        {
            throw new NotImplementedException();
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}