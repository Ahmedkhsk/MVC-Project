using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
