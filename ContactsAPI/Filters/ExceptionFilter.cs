using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsAPI.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            HttpContext ctx = context.HttpContext;
            string json = JsonSerializer.Serialize(new { error = context.Exception.Message });

            ctx.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            ctx.Response.ContentType = Application.Json;
            ctx.Response.WriteAsync(json);
        }
    }
}
