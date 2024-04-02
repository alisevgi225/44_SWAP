using Microsoft.AspNetCore.Mvc;

namespace _44_SWAP.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Head()
        {
            return PartialView();
        }
        public IActionResult Navbar()
        {
            return PartialView();
        }
        public IActionResult Footer()
        {
            return PartialView();
        }
        public IActionResult Script()
        {
            return PartialView();  
        }
    }
}
