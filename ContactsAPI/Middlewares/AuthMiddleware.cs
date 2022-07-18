using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsAPI.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    // Get JWT string
                    token = token.Split(" ").Last();

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var user = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

                    // Set e-mail on valid JWT token
                    if (string.IsNullOrEmpty(user))
                    {
                        await HandleErrorAsync(context, HttpStatusCode.BadRequest, "Invalid JWT string!");
                    }
                    else
                    {
                        await _next(context);
                    }
                }
                catch (Exception error)
                {
                    await HandleErrorAsync(context, HttpStatusCode.Unauthorized, error.Message);
                }
            } else
            {
                await _next(context);
            }
        }

        public async Task HandleErrorAsync(HttpContext context, HttpStatusCode code, string message)
        {
            var response = context.Response;
            response.ContentType = Application.Json;
            response.StatusCode = (int) code;

            var result = JsonSerializer.Serialize(new { message = message });
            await response.WriteAsync(result);
        }
    }
}
