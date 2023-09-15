using Microsoft.AspNetCore.Mvc;
using Unit_1_Project.Models;
namespace Unit_1_Project.Controllers
{
    public class Cube : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Results(CubeModel model)
        {
            return View(model);
        }
    }
}
