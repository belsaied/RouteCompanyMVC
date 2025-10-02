using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteCompany.BLL.Mappings;
using RouteCompany.BLL.Services.Classes;
using RouteCompany.BLL.Services.Interfaces;
using RouteCompany.DAL.Data.Contexts;
using RouteCompany.DAL.Data.Reposatories.Classes;
using RouteCompany.DAL.Data.Reposatories.Interfaces;

namespace RouteCompany.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region DI Container.
            // Add services to the container.
            // To Enable AntiForgeryToken automatically on every post method .
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
           
            // builder.Services.AddScoped<AppDbContext>(); // Scoped: one instance per request
            // it is better to use AddDbContext because it will configure the DbContextOptions for you
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));  // success only if the section is ConnectionStrings.
            });
            builder.Services.AddScoped<IDepartmentReposatory, DepartmentReposatory>();
            builder.Services.AddScoped<IEmployeeReposatory, EmployeeReposatory>();
            builder.Services.AddScoped<IEmployeeServices,EmployeeServices>();
            builder.Services.AddScoped<IDepartmentService,DepartmentService>();
            // Allow Dependency Injection for the Auto Mapper  (if i have a single mapping profile if i have more than 1 i must use AddProfiles with syntax changing)
            builder.Services.AddAutoMapper(Mapping => Mapping.AddProfile(new MappingProfile()));
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();  // Middleware to make sure the all Requests on other environments are redirected (secured) to HTTPS
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();          // for better performance, we use this middleware to serve static files (css, js, images, etc) without going through the whole pipeline
            app.UseRouting();

            //app.UseAuthentication();   // Login
            //app.UseAuthorization();     // Role  (order is important as i can't define your role without you login)

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
