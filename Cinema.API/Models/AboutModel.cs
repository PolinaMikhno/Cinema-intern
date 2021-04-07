using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Cinema.API.Models
{
    public class AboutModel: PageModel
    {
        private readonly ILogger _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation($"Message displayed: {Message}");
        }
    }
}
