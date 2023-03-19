using Lab4.BL;
using Lab4.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.MVC.Controllers;

public class TicketController : Controller
{
    private readonly ITicketsManager _ticketsManager;
    public TicketController(ITicketsManager tichetsManager)
    {
        this._ticketsManager = tichetsManager;
    }
    public IActionResult Index()
    {
        return View(_ticketsManager.GetAll());
    }

    [HttpGet]
    public IActionResult AddRoute()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddTicketVM ticket)
    {
        _ticketsManager.Add(ticket);
        Console.WriteLine("added");

        return Redirect(nameof(Index));
    }

    [HttpGet]
    public IActionResult EditRoute(int id)
    {
        var ticket =  _ticketsManager.GetToEdit(id);
        Console.WriteLine(id);
        return View(ticket);
    }

    [HttpPost]
    public IActionResult Edit(EditTicketVM ticket)
    {
        _ticketsManager.Edit(ticket);
        return RedirectToAction(nameof(Index));
    }
}
