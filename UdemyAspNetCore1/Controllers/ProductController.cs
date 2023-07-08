using Microsoft.AspNetCore.Mvc;
using System;

namespace UdemyAspNetCore1.Controllers
{
    public class ProductController :Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

    }
}
