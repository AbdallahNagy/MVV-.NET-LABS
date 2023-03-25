using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace API_day1;

public class CarTypeFilter: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var regex = new Regex(
            "^[Electric|Gas|Diesel|Hybrid]$",
            RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(2));

        Car? car = context.ActionArguments["car"] as Car;

        if (car is null || !regex.IsMatch(car.Type))
        {
            context.Result = new BadRequestObjectResult(new {Message= "InValid type"});
        }
    }
}
