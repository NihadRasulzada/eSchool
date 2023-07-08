using Microsoft.AspNetCore.Mvc;

namespace Waitrose.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
