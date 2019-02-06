using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Practices.Middlewares
{

    public static class DeveloperInfoMiddlewareExtensions
    {
        public static IApplicationBuilder UseDeveloperInfoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DeveloperInfoMiddleware>();
        }
    }

    public class DeveloperInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public DeveloperInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("x-Developed-By","Gsoster");
            await _next(context);
        }

    }
}