using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UdemyAspNetCore1.Controllers
{
    public class SessionController: Controller
    {
        public  IActionResult Index()
        {
            SetSession();
            ViewBag.Session=GetSession();
            return View();  
        }
        private void SetSession()
        {
            HttpContext.Session.SetString("Course", "Asp Net Core");

        }
        private string GetSession()
        {

            return HttpContext.Session.GetString("Course");
        }
    }
}
