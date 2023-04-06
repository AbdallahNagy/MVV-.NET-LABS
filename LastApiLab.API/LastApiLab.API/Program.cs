using LastApiLab.BL;
using LastApiLab.DAL;
using LastApiLab.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// config db context
var connectionString = builder.Configuration.GetConnectionString("CompanyConnectionString");
builder.Services.AddDbContext<CompanyDbContext>(options => options.UseSqlServer(connectionString));

// config employeeManager
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// config user manager
builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<CompanyDbContext>();


// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "AuthSchema"; // if he passed, return data from endpoint
    options.DefaultChallengeScheme = "AuthSchema";    // if unAuthenticated -> 401 unAuthorized
})                                                    // if i know u but u don't have access -> 403 forbidden
    .AddJwtBearer("AuthSchema", options =>
    {
        var secretKey = builder.Configuration.GetValue<string>("SecretKey") ?? String.Empty;
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey); // ! -> will never be null
        var securityKey = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = securityKey,
            ValidateIssuer = false,   // made token (api)
            ValidateAudience = false  // recieves token (api also in this case)
        };
    });

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "AllowUsersOnly",
        options => options.RequireClaim(ClaimTypes.Role, "User")
        );

    options.AddPolicy(
        "AllowAdminsOnly",
        options => options.RequireClaim(ClaimTypes.Role, "Admin")
        );

    options.AddPolicy(
        "AllowUsersOrAdmins",
        options => options.RequireClaim(ClaimTypes.Role, "User", "Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
