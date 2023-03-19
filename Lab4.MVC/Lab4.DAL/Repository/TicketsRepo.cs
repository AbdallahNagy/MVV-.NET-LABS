using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class TicketsRepo : ITicketsRepo
{
    private readonly TicketContext _context;

    public TicketsRepo(TicketContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Tickets;
    }

    public Ticket? Get(int id)
    {
        return _context.Tickets.Find(id);
    }

    public void Add(Ticket ticket)
    {
        //_context.Tickets.Add(ticket);
        _context.Set<Ticket>().Add(ticket);
    }
    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Tickets.Remove(ticketToDelete); // remove takes the whole obj not just id or pk
        }
    }
    public void Update(Ticket ticket)
    {

    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
