using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UdemyAspNetCore1.Middlewares;

namespace UdemyAspNetCore1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddRazorPages();
     
            services.AddControllers();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules"))

            }) ;

            var firstName = configuration.GetSection("Person:FirstName").Value;
            var lastName = configuration.GetSection("Person:LastName").Value;
            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("/Home/Status","?code={0}");

            app.UseRouting();
            app.UseSession();
           
           //pp.UseMiddleware<RequestEditingMiddleware>();
           //pp.UseMiddleware<ResponseEditingMiddleware>();


            app.UseAuthorization();
            
           app.UseEndpoints(endpoints =>
            {
                /* endpoints.MapControllerRoute(
                      name: "productRoute",
                      pattern: "dilara/{action}",
                      defaults: new { controller = "home" }
                      );*/
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}"
                     
                     );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{Action}/{id?}",
                    defaults: new { Controller = "home", Action = "index" }
                    );
            });
        }
    }
}
