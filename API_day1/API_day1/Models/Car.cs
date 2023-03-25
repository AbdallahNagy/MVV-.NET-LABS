namespace API_day1;

public class Car
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string? Type { get; set; }

    [ValidateProductionDate]
    public DateTime? ProductionDate { get; set; }

    public static List<Car> _cars = new List<Car>()
    {
        new Car{Id=1, Company="BMW", Model="X1"},
        new Car{Id=2, Company="SEAT", Model="s1"},
        new Car{Id=3, Company="FIAT", Model="X5"},
        new Car{Id=4, Company="MERC", Model="X3"},
    };
    public static List<Car> GetCars() { return _cars; }
}
