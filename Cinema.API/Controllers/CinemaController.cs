using System.Linq;
using System.Threading.Tasks;
using Cinema.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly CinemaContext _context;

        public CinemaController(CinemaContext context)
        {
            _context = context;

            if (!_context.Items.Any())
            {
                _context.Items.Add(new SomeItem {Name = "umni golub"});
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SomeItem>> GetTodoItem(long id)
        {
            SomeItem item = await _context.Items.FindAsync(id);
            if (item == null)
                return NotFound();
            return item;
        }
    }
}