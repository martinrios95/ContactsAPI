using System.Net;

namespace ContactsAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            // Generate custom response with HTTP 503 error code
        }
    }
}
