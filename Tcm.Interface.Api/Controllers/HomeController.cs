using Microsoft.AspNetCore.Mvc;

namespace Tcm.Interface.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}