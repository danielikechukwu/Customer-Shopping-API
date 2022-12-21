using Microsoft.AspNetCore.Mvc;

namespace ConstumerShoppingMVC.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
