using BusinessLayer.ViewModels;
using DataAccessLayer.DomainModels;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.DepartmentsRepo;
using DataAccessLayer.Repositories.DevelopersRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo TicketsRepo;
    private readonly IDeptRepo DeptRepo;
    private readonly IDevRepo DevRepo;

    public TicketsManager(ITicketsRepo _TicketsRepo, IDevRepo devRepo, IDeptRepo deptRepo)
    {
        TicketsRepo = _TicketsRepo;
        DeptRepo = deptRepo;
        DevRepo = devRepo;
    }

    public IEnumerable<ReadTicketsVM> GetTicketsDeptDev()
    {
        var Tickets = TicketsRepo.GetTicketsDeptDev();
        return Tickets.Select(t => new ReadTicketsVM(t.Id, t.Title, t.Description, t.Severity.ToString(), t.Department?.Name, t.Developers.Count));
    }
    public ReadTicketsVM GetTicketDeptDevById(Guid id)
    {
        var ticket = TicketsRepo.GetTicketDeptDevById(id);
        return new ReadTicketsVM(ticket.Id, ticket.Title, ticket.Description, ticket.Severity.ToString(), ticket.Department?.Name, ticket.Developers.Count);
    }
    public void Delete(Guid id)
    {
        TicketsRepo.Delete(id);
        TicketsRepo.SaveChanges();
    }
    public EditTicketsVM? GetTicketForEdit(Guid id)
    {
        Ticket? x = TicketsRepo.GetTicketDeptDevById(id);
        if (x == null) return null;
        return new EditTicketsVM(x.Id, x.Title, x.Description, x.Severity, x.Department?.Id, x.Developers.Select(d => d.Id).ToHashSet());
    }
    public void UpdateTicket(EditTicketsVM ticket)
    {
        Ticket? TicketToUpdate = TicketsRepo.GetById(ticket.Id);
        if (TicketToUpdate == null) return;

        TicketToUpdate.Title = ticket.Title;
        TicketToUpdate.Description = ticket.Description;
        TicketToUpdate.Severity = ticket.Severity;
        TicketToUpdate.DeptId = ticket.Department;

        if (ticket.Developers == null)
        {
            TicketToUpdate.Developers = new HashSet<Developer>();
        }
        else
        {
            TicketToUpdate.Developers = DevRepo.getAllDevelopers().Where(d => ticket.Developers.Contains(d.Id)).ToHashSet();
        }

        TicketsRepo.SaveChanges();
    }
    public void AddNewTicket(AddTicketsVM ticket)
    {
        var developers = DevRepo.getAllDevelopers().Where(d => ticket.Developers.Contains(d.Id)).ToHashSet();
        Ticket TicketToAdd = new Ticket(ticket.Title, ticket.Description, ticket.Severity, ticket.Department, developers);
        TicketsRepo.AddNewTicket(TicketToAdd);
        TicketsRepo.SaveChanges();
    }


}

