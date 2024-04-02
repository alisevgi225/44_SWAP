using Microsoft.AspNetCore.Mvc;

namespace _44_SWAP.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.home = "current-menu-item";
            return View();
        }
        public IActionResult Banner()
        {
            return PartialView();
        }
        public IActionResult MarketMenu()
        {
            return PartialView();
        }
		public IActionResult CoinList()
		{
			return PartialView();
		}
	}
}
