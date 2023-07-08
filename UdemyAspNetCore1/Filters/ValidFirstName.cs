using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Xml.Serialization;
using UdemyAspNetCore1.Models;

namespace UdemyAspNetCore1.Filters
{
    public class ValidFirstName :ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext context)
        {
     
            var dictionary= context.ActionArguments.FirstOrDefault(I => I.Key == "customer");
            var customer = dictionary.Value as Customer;

            if (customer.FirstName== "dilara")
            {
                context.Result= new RedirectResult("/Home/Index");
            }

          
        }      

    }
}
