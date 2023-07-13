using Microsoft.AspNetCore.Mvc;

namespace Waitrose.Controllers
{
    public class SyllabusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
