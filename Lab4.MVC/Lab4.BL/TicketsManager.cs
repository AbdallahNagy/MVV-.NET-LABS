using Lab4.BL.ViewModels;
using Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

// for mapping view Models to Domain Models and vise versa
// business logic
public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;

    public TicketsManager(ITicketsRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }
    public ReadTicketVM? Get(int id)
    {
        var ticket = _ticketsRepo.Get(id);
        if (ticket == null) return null;

        return new ReadTicketVM
        (
            ticket.Id,
            ticket.Title,
            ticket.Description,
            ticket.Severity
        );
    }
    public List<ReadTicketVM> GetAll()
    {
        var tickets = _ticketsRepo.GetAll();
        return tickets.Select(d => new ReadTicketVM
        (
            d.Id,
            d.Title,
            d.Description,
            d.Severity
        )).ToList();
    }
    public void Add(AddTicketVM ticketVM)
    {
        var ticket = new Ticket
        {
            Description = ticketVM.Description,
            Title = ticketVM.Title,
            Severity = ticketVM.Severity
        };
        _ticketsRepo.Add(ticket);
        _ticketsRepo.SaveChanges();
    }

    public void Edit(EditTicketVM ticketVM)
    {
        var ticketDB = _ticketsRepo.Get(ticketVM.Id);

        if (ticketDB is null) return;

        ticketDB.Id = ticketVM.Id;
        ticketDB.Title = ticketVM.Title;
        ticketDB.Description = ticketVM.Description;
        ticketDB.Severity = ticketVM.Severity;
        
        _ticketsRepo.Update(ticketDB);
        _ticketsRepo.SaveChanges();
    }

    public EditTicketVM? GetToEdit(int id)
    {
        var ticket = _ticketsRepo.Get(id);
        if (ticket == null) return null;

        return new EditTicketVM
        (
            ticket.Title,
            ticket.Description,
            ticket.Severity,
            ticket.Id
        );
    }
}
