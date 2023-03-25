using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_day1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    [HttpGet]
    public ActionResult GetNumberOfRequests()
    {
        Globals.Counter--; // cuz this req doesn't count
        return Ok(new { NumberOfRequests = Globals.Counter });
    }
}
