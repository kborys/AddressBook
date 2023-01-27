namespace AddressBook.Api.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggerMiddleware> _logger;

        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var requestInfo = $"Incoming request: {httpContext.Request.Method}:{httpContext.Request.Path}";
            _logger.LogInformation(requestInfo);
            await _next(httpContext);
        }
    }
}
