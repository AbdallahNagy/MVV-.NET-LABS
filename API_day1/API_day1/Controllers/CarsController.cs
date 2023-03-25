using API_day1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_day1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ILogger<CarsController> _logger;

    public CarsController(ILogger<CarsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetAllCars()
    {
        _logger.LogInformation(" you're about to get all the cars in our garage!");
        return Car.GetCars();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Car> Get(int id)
    {
        var car = Car.GetCars().FirstOrDefault(c => c.Id == id);
        if (car is null) return NotFound(new { Message = "this car is not here" });
        _logger.LogInformation($"here's your car model: {car.Model}");
        return car;
    }

    [HttpPost]
    [Route("v1")]
    public ActionResult Add(Car car)
    {
        car.Type = "Gas";
        Car._cars.Add(car);
        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { car.Id },
            value: new { Message = "done" }
            );
    }

    [HttpPost]
    [Route("v2")]
    [ServiceFilter(typeof(CarTypeFilter))]
    public ActionResult AddV2(Car car)
    {
        Car._cars.Add(car);
        return Ok();
    }


    [HttpPut]
    public ActionResult Update(Car car)
    {
        var targetCar = Car.GetCars().FirstOrDefault(c => c.Id == car.Id);
        if (targetCar is null) return NotFound();

        targetCar.Model = car.Model;
        targetCar.Company = car.Company;

        return Ok(new { Message = "updated successfully" });
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var targetCar = Car.GetCars().FirstOrDefault(c => c.Id == id);
        if (targetCar is null) return NotFound();

        Car._cars.Remove(targetCar);
        return Ok(new { Message = "deleted successfully" });
    }
}
