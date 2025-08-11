namespace StorageProject.Api.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Log the request details
            _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);
            // Call the next middleware in the pipeline
            await next(context);
            // Log the response details
            _logger.LogInformation("Finished handling request. Response status code: {StatusCode}", context.Response.StatusCode);
        }
    }
}

