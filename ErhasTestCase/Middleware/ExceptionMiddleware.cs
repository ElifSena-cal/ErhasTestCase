namespace ErhasTestCase.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next=next;
        private readonly ILogger<ExceptionMiddleware> _logger=logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var errorResponse = new { message = "An unexpected error occurred." };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
