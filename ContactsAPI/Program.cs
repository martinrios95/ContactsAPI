using ContactsAPI.Data;
using ContactsAPI.Data.Interfaces;
using ContactsAPI.Filters;
using ContactsAPI.Services;
using ContactsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add console debugging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Switch to a SQLite database
// Remember to add NuGet package (easy one...)
// builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Switch to a SQL Server LocalDB database
// Remember to add NuGet package (easy one...)
builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Set exception filter
builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
builder.Services.AddControllers(options => options.Filters.Add(new ModelValidationFilter()));

// TODO: Set Services
// builder.Services.AddTransient<IService, CustomService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
