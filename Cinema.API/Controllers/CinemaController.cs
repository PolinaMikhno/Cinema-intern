using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.API.Models;
using Microsoft.Extensions.Logging;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly CinemaContext _context;
        private readonly ILogger _logger;

        public CinemaController(CinemaContext context, ILogger<CinemaController> logger)
        {
            
            _context = context;
            _logger = logger;

            if (!_context.Items.Any())
            {
                _context.Items.Add(new SomeItem{Name = "atmta"});
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SomeItem>> GetTodoItem(long id)
        {
            _logger.LogInformation("GETTODOITEM CALLED ALIO");
            SomeItem item = await _context.Items.FindAsync(id);
            if (item == null)
                return NotFound();
            return item;
        }
    }
}