using Cinema.DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly DatabaseContext _context;

        public CinemaController(DatabaseContext context)
        {
            _context = context;
        }
        
    }
}