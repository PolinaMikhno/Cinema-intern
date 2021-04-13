using System;
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
        }

        [HttpGet("{id}")]
        //TODO :
        public async Task<ActionResult> GetTodoItem(Guid id)
        {
            SomeItem item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}