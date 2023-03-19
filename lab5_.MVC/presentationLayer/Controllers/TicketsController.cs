using BusinessLayer;
using BusinessLayer.Managers.DepartmentsManager;
using BusinessLayer.Managers.DevelopersManager;
using BusinessLayer.ViewModels;
using DataAccessLayer.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager TicketsManager;
        private readonly IDeptManager DepartmentsManager;
        private readonly IDevManager DevelopersManager;

        public TicketsController(ITicketsManager ticketsManager, IDeptManager deptManager, IDevManager devManager)
        {
            TicketsManager = ticketsManager;
            DepartmentsManager = deptManager;
            DevelopersManager = devManager;
        }
        public IActionResult Index()
        {
            IEnumerable<ReadTicketsVM> AllTickets = TicketsManager.GetTicketsDeptDev();
            return View(AllTickets);
        }
        public IActionResult Details(Guid id)
        {
            ReadTicketsVM Ticket = TicketsManager.GetTicketDeptDevById(id);
            return View(Ticket);
        }
        public IActionResult Delete(Guid id)
        {
            TicketsManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Add() 
        {
            ViewBag.Departments = DepartmentsManager.GetAllDepartments();
            ViewBag.Developers = DevelopersManager.GetAllDevelopers();
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddTicketsVM ticket)
        {
            TicketsManager.AddNewTicket(ticket);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            EditTicketsVM? Ticket = TicketsManager.GetTicketForEdit(id);
            ViewBag.Departments = DepartmentsManager.GetAllDepartments();
            ViewBag.Developers = DevelopersManager.GetAllDevelopers();

            return View(Ticket);
        }
        [HttpPost]
        public IActionResult Edit(EditTicketsVM ticket) 
        {
            TicketsManager.UpdateTicket(ticket);
            return RedirectToAction(nameof(Index));
        }
    }
}
