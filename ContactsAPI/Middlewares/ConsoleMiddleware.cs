namespace ContactsAPI.Middlewares
{
    public class ConsoleMiddleware
    {
        private readonly RequestDelegate _next;

        public ConsoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await BeforePassing(httpContext);
            await _next(httpContext);
        }

        private async Task BeforePassing(HttpContext httpContext)
        {
            // Write your custom code

            // Now using it ONLY for debugging
            Console.WriteLine("Request time: " + DateTime.Now);
        }
    }
}
