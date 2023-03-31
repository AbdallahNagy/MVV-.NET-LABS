using Microsoft.EntityFrameworkCore;
using Tickets.BL;
using Tickets.DAL;

var builder = WebApplication.CreateBuilder(args);

// database
var connStr = builder.Configuration.GetConnectionString("TicketDbConn");
builder.Services.AddDbContext<TicketDbContext>(options => options.UseSqlServer(connStr));

// add services
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IDeveloperRepo, DeveloperRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<ITicketManager, TicketManager>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
