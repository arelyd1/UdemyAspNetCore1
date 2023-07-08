using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UdemyAspNetCore1.Middlewares
{
    public class RequestEditingMiddleware
    {
     private RequestDelegate  _requestDelegate;
        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }   

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString() == "/dilara")
              await  context.Response.WriteAsync("hosgeldin dilara");
            else
               await  _requestDelegate.Invoke(context);

        }
    }
}
