using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UdemyAspNetCore1.Filters;
using UdemyAspNetCore1.Models;

namespace UdemyAspNetCore1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            /* ITest test = new Test();
             ITest test2= new Test2();

             var  Values = RouteData.Values;
             ViewBag.names = "dilara";
             ViewData["names"] = "merve";
             TempData["names"] = "kahraman";

             Customer customer = new() { Age = 27, FirstName = "dilara merve", LastName = "kahraman" };
             return View(customer);*/
            var customers = CustomercContext.Customers;
            
            
            return View(customers);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View( new Customer());
        }
        [HttpPost]
        [ValidFirstName]
        public IActionResult Create(Customer customer)
        {
            //var Firstname =HttpContext.Request.Form["firstname"].ToString();
            // var Lastname = HttpContext.Request.Form["lastname"].ToString();
            // var age =int.Parse(HttpContext.Request.Form["age"].ToString());

            //var control = ModelState.IsValid;
            //var errors = ModelState.Values.SelectMany(I => I.Errors.Select
            //( I=> I.ErrorMessage));
            ModelState.Remove("Id");
            if (customer.FirstName=="dilara")
            {
                ModelState.AddModelError(" ", "Firstname dilara olamaz");
            }
            if (ModelState.IsValid)
            {       
                Customer lastCustomer =null;        
                if (CustomercContext.Customers.Count > 0)           
                {
               lastCustomer=  CustomercContext.Customers.Last();           
                }           
                customer.Id=1;           
                if (lastCustomer!=null)        
                {
                customer.Id = lastCustomer.Id + 1;
                }
                CustomercContext.Customers.Add(customer);         
                try        
                {          
                    return RedirectToAction("Index");   
                }
                catch 
                {    
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Remove( int id)
        {
            //var id= int.Parse(RouteData.Values["id"].ToString());
            var removeCustomer= CustomercContext.Customers.Find(I => I.Id == id);
            CustomercContext.Customers.Remove(removeCustomer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            //var id = int.Parse(RouteData.Values["id"].ToString());
            var updatedCustomer= CustomercContext.Customers.FirstOrDefault(a => a.Id == id);
                return View(updatedCustomer);
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
           //var id= int.Parse(HttpContext.Request.Form["id"].ToString());

            var uptatedCustomer = CustomercContext.Customers.FirstOrDefault(I=>I.Id==customer.Id);
           // uptatedCustomer.FirstName = HttpContext.Request.Form["firstname"].ToString();
           // uptatedCustomer.LastName = HttpContext.Request.Form["lastname"].ToString();
            //uptatedCustomer.Age = int.Parse(HttpContext.Request.Form["age"].ToString());

            uptatedCustomer.FirstName   =customer.FirstName;
            uptatedCustomer.LastName =customer.LastName;
            uptatedCustomer.Age = customer.Age;

            return RedirectToAction("Index");
        }

       public IActionResult Status(int ? code)
        {
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature=
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //serilog nlog
            //11-02-2020_11-02
            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "log");
            var logFileName = DateTime.Now.ToString();
            logFileName = logFileName.Replace(" ", "-");
            logFileName = logFileName.Replace(";", "-");
            logFileName = logFileName.Replace("/", "-");
            logFileName += ".txt";
            var logFilePath =Path.Combine(logFolderPath,logFileName);
            DirectoryInfo directoryInfo=new DirectoryInfo(logFolderPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();

            }
            FileInfo fileInfo=new FileInfo(logFolderPath);
            var writer= fileInfo.CreateText();
            writer.WriteLine("Hatanın gerçekleştiği yer:"+
                exceptionHandlerPathFeature.Path);
            writer.WriteLine("hata mesajı:"+
                exceptionHandlerPathFeature.Error.Message);
            writer.Close();
            
            return View();
        }
        public IActionResult Hata()
        {
            throw new System.Exception("Sistemsel bir hata oluştu");
            
        }

        
    }
    
}
