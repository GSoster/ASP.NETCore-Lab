using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace Practices.Middlewares{


    /**
    * Documentation to develop this: 
    * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2#write-middleware
    * https://gaunacode.com/asp.net/core/middleware/2017/04/14/AspNetCoreMiddleware.html
    * https://dzone.com/articles/customizing-aspnet-core-part-6-middleware
    * https://blog.dudak.me/2014/custom-middleware-with-dependency-injection-in-asp-net-core/
    * https://stackoverflow.com/questions/52124638/ilogger-and-dependencyinjection-in-asp-net-core-2
    * https://www.talkingdotnet.com/app-use-vs-app-run-asp-net-core-middleware/
     */


    /**
    * Method Extensions to make it easier to call the Middleware.
    * Instead of using app.UseMiddleware<RequestTimeLoggerMiddleware>();
    * We can use just: 
     */

    public static class RequestTimeLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeLoggerMiddleware>();
        }
        
    }


    /**
    * The class that does the actual work: 
     */
    public class RequestTimeLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private Stopwatch _stopwatch;
        private readonly ILogger _logger;

        public RequestTimeLoggerMiddleware(RequestDelegate next, ILogger<RequestTimeLoggerMiddleware> log)
        {
            _next = next;
            _stopwatch = new Stopwatch();
            _logger = log;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _stopwatch.Start();
            await _next(context);
            _stopwatch.Stop();
            _logger.LogInformation(" # [ RequestTimeLoggerMiddleware ] # => " + _stopwatch.ElapsedMilliseconds);
        }

    }
}