using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Session10.MVC.Infrastructure;
using Session10.MVC.Models;

using System.Collections.Generic;
using System.Diagnostics;

namespace Session10.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UptimeService _uptimeService;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, UptimeService uptimeService)
        {
            _logger = logger;
            _configuration = configuration;
            _uptimeService = uptimeService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("index called");

            Dictionary<string, string> valuePairs = new Dictionary<string, string>()
            {
                ["Message"] = "Hello World from index action!",
                ["LogLevel"] = $"LogLevel is {_configuration.GetSection("Logging").GetSection("LogLevel").GetValue<string>("Default")}",
                ["Uptime"] = $"System uptime is {_uptimeService.Uptime / 10000000} seconds"
            };

            return View(valuePairs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
