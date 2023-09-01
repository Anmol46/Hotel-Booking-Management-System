

// namespace API
// {
//     using Microsoft.AspNetCore.Hosting;
//     using Microsoft.Extensions.Hosting;
//     using System.Diagnostics.CodeAnalysis;
//     using Microsoft.AspNetCore;
//     using HotelManagementSystem;

//     [ExcludeFromCodeCoverage]
//     public class Program
//     {

//         public static void Main(string[] args)
//         {
//             BuildWebHost(args).Run();
//         }

//         public static IWebHost BuildWebHost(string[] args) =>
//             WebHost.CreateDefaultBuilder(args)
//                 .UseStartup<Startup>()
//                 .Build();
//     }
// }














using DAO;
using Data;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServeConnection"));
}, ServiceLifetime.Scoped);

builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

builder.Services.AddLogging(logging => logging.AddConsole());

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
