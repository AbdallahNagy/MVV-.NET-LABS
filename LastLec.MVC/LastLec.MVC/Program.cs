using LastLec.MVC.Context;
using LastLec.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//context
var connectionString = builder.Configuration.GetConnectionString("dbConStr");
builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<SystemContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Users/Login";
    options.Cookie.Name = "AuthCookie";
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "coolCookie";
//    options.DefaultChallengeScheme = "coolCookie"; // redirect to login page
//    options.DefaultSignInScheme = "coolCookie";
//})
//    .AddCookie("coolCookie", options =>
//    {
//        options.LoginPath = "/Users/Login";
//    });

// any service must be before builder.build();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
