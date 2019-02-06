using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
namespace Practices.Middlewares{
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