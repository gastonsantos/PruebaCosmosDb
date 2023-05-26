using Microsoft.AspNetCore.Mvc;

namespace PruebaMongo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
