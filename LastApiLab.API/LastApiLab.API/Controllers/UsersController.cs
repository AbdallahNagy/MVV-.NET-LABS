using LastApiLab.BL;
using LastApiLab.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LastApiLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<Employee> userManager;
        private readonly IEmployeeManager employeeManager;

        // (IConfiguration service) to access appsettings.json
        // (UserManager service) to facilitate user operations like hashing password store it etc.. from package identity
        //      also you have to configure it first in program.cs
        public UsersController(
            IConfiguration configuration,
            UserManager<Employee> userManager,
            IEmployeeManager employeeManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.employeeManager = employeeManager;
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult<TokenDTO>> Register(RegisterAdminDTO register)
        {
            var emp = employeeManager.AdminDTOToEmpolyee(register);

            var empCreationResult = await userManager.CreateAsync(emp, register.Password);
            if (!empCreationResult.Succeeded) return BadRequest(empCreationResult.Errors);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, emp.Id),
                new Claim(ClaimTypes.Role, "Admin")
            };

            await userManager.AddClaimsAsync(emp, claims);
            var expiresIn = DateTime.Now.AddHours(1);

            var tokenString = employeeManager.GenerateToken(claims, expiresIn);

            return new TokenDTO(tokenString);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult<TokenDTO>> Register(RegisterUserDTO register)
        {
            var emp = employeeManager.UserDTOToEmpolyee(register);

            var empCreationResult = await userManager.CreateAsync(emp, register.Password);
            if (!empCreationResult.Succeeded) return BadRequest(empCreationResult.Errors);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, emp.Id),
                new Claim(ClaimTypes.Role, "User")
            };

            await userManager.AddClaimsAsync(emp, claims);
            var expiresIn = DateTime.Now.AddHours(1);

            var tokenString = employeeManager.GenerateToken(claims, expiresIn);

            return new TokenDTO(tokenString);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
        {
            var emp = await userManager.FindByEmailAsync(credentials.Email);
            if (emp is null) return BadRequest(new { Message = "user not found!" });

            var isPasswordCorrect = await userManager.CheckPasswordAsync(emp, credentials.Password);
            if (!isPasswordCorrect) return Unauthorized();

            var claims = await userManager.GetClaimsAsync(emp);
            var expiresIn = DateTime.Now.AddHours(1);

            var tokenString = employeeManager.GenerateToken(claims, expiresIn);
            return new TokenDTO(tokenString);
        }
    }
}
