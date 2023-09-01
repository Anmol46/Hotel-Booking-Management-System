// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Data;
// using Models;
// using Interfaces;
// using DAO;

// namespace HotelManagementSystem
// {
//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddControllers();

//             services.AddDbContext<DataContext>(options =>
//                 options.UseSqlServer(Configuration.GetConnectionString("SqlServeConnection")));

//             services.AddIdentity<AppIdentityUser, IdentityRole>()
//                 .AddEntityFrameworkStores<DataContext>()
//                 .AddDefaultTokenProviders();

//             services.AddLogging(logging => logging.AddConsole());

//             services.AddEndpointsApiExplorer();
//             services.AddSwaggerGen();

//             services.AddMvc();
//             services.AddScoped<IUserRepository, UserRepository>();

//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             app.UseAuthentication();

//             if (env.IsDevelopment())
//             {
//                 app.UseSwagger();
//                 app.UseSwaggerUI();

//                 app.UseSwaggerUI(options =>
//                         {
//                             options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//                             options.RoutePrefix = string.Empty;
//                         });

//                 app.UseRouting();
//                 app.UseCors("CorsPolicy");

                
//             }
//         }
//     }
// }