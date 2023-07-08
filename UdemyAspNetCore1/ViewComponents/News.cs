using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAspNetCore1.Models;

namespace UdemyAspNetCore1.ViewComponents
{
    public class News :ViewComponent
    {
        public IViewComponentResult Invoke(string color="Default")
        {
             var list= NewsContext.List;
            if (color == "default")
                return View(list);
            else if (color == "Red")

                return View("Red", list);
            else return View("Blue",list);
        }
    }
}
