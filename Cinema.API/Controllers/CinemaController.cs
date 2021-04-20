using System;
using System.Linq;
using Cinema.DAL.Auth;
using Cinema.DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly CinemaContext _context;

        private Repository<User> _users;

        public CinemaController(CinemaContext context)
        {
            _context = context;
            _users = new Repository<User>(context);
           
        }
    }
}