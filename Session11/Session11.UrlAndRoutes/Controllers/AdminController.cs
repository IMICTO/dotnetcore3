using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRoutes.Models;

namespace Session11.UrlAndRoutes.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            });
        }
    }
}
