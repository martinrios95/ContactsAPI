using ContactsAPI.Data;
using ContactsAPI.Filters;
using ContactsAPI.Middlewares;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Authorization Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

    // generate the XML docs that'll drive the swagger docs
    var xmlFile = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Add console debugging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add Health Status
builder.Services.AddHealthChecks();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Switch to a SQLite database
// Remember to add NuGet package (easy one...)
// builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Switch to a SQL Server LocalDB database
// Remember to add NuGet package (easy one...)
builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Set exception filter
// builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
builder.Services.AddControllers(options => options.Filters.Add(new PhoneValidationFilter()));

// TODO: Set Unit-of-Work and Services
builder.Services.AddTransient<UnitOfWork>();
builder.Services.AddTransient<StateService>();
builder.Services.AddTransient<CityService>();
builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<AuthService>();

var app = builder.Build();

// Use middleware
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Health Check endpoint
app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
