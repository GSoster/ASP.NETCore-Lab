using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Practices.Services;
using Microsoft.Extensions.Configuration;

namespace Practices
{
    public class Startup
    {


        public IConfiguration Configuration{get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;  
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IItemService, LocalItemService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }        
            
            /* //Playing with Middlewares
            app.Use(async (context, next)=>{
                await context.Response.WriteAsync("1: before");
                await next();
                await context.Response.WriteAsync("1: after");
            });

            app.Use(async (context, next)=>{
                await context.Response.WriteAsync("2: before");
                await next();
                await context.Response.WriteAsync("2: after");
            });

            app.Run(async(context)=>{
                await context.Response.WriteAsync("Ending request");
            });*/

            /* app.UseMvc(routes => {
                routes.MapRoute("default",
                template: "{controller=Items}/{action=Index}/{id?}");
            });*/

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
    }
}
