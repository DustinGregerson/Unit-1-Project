using Microsoft.AspNetCore.Mvc;
using Unit_1_Project.Models;
namespace Unit_1_Project.Controllers
{
    //Author: Dustin Gregerson
    //Date: 9/16/22
    //Description:
    //This controler handels the routing between the index page and the results page
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
