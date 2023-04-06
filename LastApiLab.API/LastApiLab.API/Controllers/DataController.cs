using LastApiLab.BL;
using LastApiLab.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastApiLab.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly UserManager<Employee> userManager;
    private readonly IEmployeeManager employeeManager;

    public DataController(UserManager<Employee> userManager, IEmployeeManager employeeManager)
    {
        this.userManager = userManager;
        this.employeeManager = employeeManager;
    }

    [HttpGet]
    [Route("GetUserInfo")]
    [Authorize]
    public async Task<ActionResult<ReadUserInfoDTO>> GetUserInfo()
    {
        var emp = await userManager.GetUserAsync(User);
        if (emp is null) return BadRequest(new { Message = "User not found" });

        return employeeManager.EmployeeToReadUserInfoDTO(emp);
    }

    [HttpGet]
    [Route("GetInfoForManager")]
    [Authorize(Policy = "AllowAdminsOnly")]
    public ActionResult GetInfoForManager()
    {
        return Ok(new {Message = "Done"});
    }

    [HttpGet]
    [Route("GetInfoForUsersOrAdmins")]
    [Authorize(Policy = "AllowUsersOrAdmins")]
    public ActionResult GetInfoForUserOrAdmin()
    {
        return Ok(new { Message = "Done" });
    }
}
