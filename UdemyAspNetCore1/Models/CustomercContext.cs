using System.Collections.Generic;

namespace UdemyAspNetCore1.Models
{
    public class CustomercContext
    {
        public static List<Customer> Customers = new()
        {
           new Customer {Id =1,FirstName="dilara",LastName="kahraman", Age=27 },
           new Customer {Id=2,FirstName="merve",LastName="kahraman", Age=20 }
         };


    }
}