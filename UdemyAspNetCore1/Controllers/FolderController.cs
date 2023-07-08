using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace UdemyAspNetCore1.Controllers
{
    public class FolderController :Controller
    {
        public IActionResult list()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
            var folders=directoryInfo.GetDirectories();
                return View(folders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string foldername)
        {
            DirectoryInfo info =new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", foldername));
            if (!info.Exists)
            {
                info.Create();
            }
            return RedirectToAction("List");
        }
        public IActionResult Remove(string foldername)
        {
            DirectoryInfo info = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", foldername));
            if (!info.Exists)
            {
                info.Delete(true);
            }
            return RedirectToAction("List");
        }
            
    }
}
