using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace Session10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>()
            {
                ["Message"] = "Hello World from index action!"
            };

            return View(valuePairs);
        }
    }
}
