using Lab4.BL;
using Lab4.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// all configurations for the dbContext that may change (provider, connection string)
var connectionStr = builder.Configuration.GetConnectionString("ticketConStr");
builder.Services.AddDbContext<TicketContext>(options
    => options.UseSqlServer(connectionStr));

// we do that to be able to inject the interface anywhere to apply the IOC and Dep Inversion
// higher classes shouldn't depend on lower classes. both should depend on abstraction
// when anyone want to access ITicketsRepo give him TicketRepo

// will create object on every http request
builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<ITicketsManager, TicketsManager>();

// will create only one object for all the http requests
// EF can't handle concurrent requests
//builder.Services.AddSingleton<ITicketsRepo, TicketsRepo>();

// will create object on every 
//builder.Services.AddTransient<ITicketsRepo, TicketsRepo>();

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
    pattern: "{controller=Ticket}/{action=Index}/{id?}");

app.Run();
