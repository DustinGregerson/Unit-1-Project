using Microsoft.AspNetCore.Mvc;

namespace Unit_1_Project.Controllers
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
