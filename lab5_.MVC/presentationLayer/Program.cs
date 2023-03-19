using BusinessLayer;
using BusinessLayer.Managers.DepartmentsManager;
using BusinessLayer.Managers.DevelopersManager;
using DataAccessLayer.Context;
using DataAccessLayer.DomainModels;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.DepartmentsRepo;
using DataAccessLayer.Repositories.DevelopersRepo;
using Microsoft.EntityFrameworkCore;

namespace presentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            ///////////////////////////
            
            var connectionString = builder.Configuration.GetConnectionString("tickets2");
            builder.Services.AddDbContext<myContext>(options
                => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDeptRepo, DeptRepo>();
            builder.Services.AddScoped<IDevRepo, DevRepo>();
            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<IDeptManager, DeptManager>();
            builder.Services.AddScoped<IDevManager, DevManager>();

            ///////////////////////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}