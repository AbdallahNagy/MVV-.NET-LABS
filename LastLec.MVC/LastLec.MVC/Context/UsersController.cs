using LastLec.MVC.DTOs;
using LastLec.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LastLec.MVC.Context;

public class UsersController : Controller
{
    private readonly UserManager<Employee> userManager;
    private readonly SignInManager<Employee> signInManager;

    public UsersController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDTO register)
    {
        var emp = new Employee
        {
            UserName = register.username,
            Email = register.email,
            DateBirth = register.birthDate
        };

        var creationResult = await userManager.CreateAsync(emp, register.password);
        if (!creationResult.Succeeded)
        {
            ModelState.AddModelError(String.Empty, creationResult.Errors.First().Description);
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, emp.Id),
            new(ClaimTypes.Email, emp.Email),
            new(ClaimTypes.Role, "User")
        };

        await userManager.AddClaimsAsync(emp, claims);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO credentials)
    {
        var emp = await userManager.FindByNameAsync(credentials.username);
        if (emp is null)
        {
            // error route
            return View();
        }

        var isAuthenticated = await userManager.CheckPasswordAsync(emp, credentials.password);
        if(!isAuthenticated)
        {
            // not authenticated
            return View();
        }

        await signInManager.SignInAsync(emp, true);

        return RedirectToAction("Index", "Home");
    }
     
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
