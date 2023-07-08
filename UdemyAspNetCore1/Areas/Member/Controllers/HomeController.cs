using Microsoft.AspNetCore.Mvc;

namespace UdemyAspNetCore1.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        [Area("Member")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
