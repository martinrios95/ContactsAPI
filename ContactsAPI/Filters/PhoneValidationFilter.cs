using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsAPI.Filters
{
    public class PhoneValidationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                HttpContext ctx = context.HttpContext;
                string json = JsonSerializer.Serialize(new { error = context.ModelState });

                ctx.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ctx.Response.ContentType = Application.Json;
                ctx.Response.WriteAsync(json);
            }
        }
    }
}
