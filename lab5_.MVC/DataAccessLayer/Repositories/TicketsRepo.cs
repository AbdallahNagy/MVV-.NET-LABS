using DataAccessLayer.Context;
using DataAccessLayer.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class TicketsRepo : ITicketsRepo
{
    private readonly myContext context;

    public TicketsRepo(myContext _context)
    {
        context = _context;
    }
    public IEnumerable<Ticket> GetAll()
    {
        return context.Set<Ticket>();
    }
    public IEnumerable<Ticket> GetTicketsDeptDev()
    {
        return context.Set<Ticket>().Include(t => t.Department).Include(t => t.Developers).AsEnumerable();
    }
    public Ticket GetTicketDeptDevById(Guid id)
    {
        return context.Set<Ticket>().Include(t => t.Department).Include(t => t.Developers).First(t => t.Id == id);
    }
    public void Delete(Guid id)
    {
        Ticket? ticket = context.Set<Ticket>().Find(id);
        if (ticket != null) { context.Set<Ticket>().Remove(ticket); }
    }
    public Ticket? GetTicketForEdit(Guid id)
    {
        return context.Set<Ticket>().Find(id);
    }
    public void AddNewTicket(Ticket ticket)
    {
        context.Set<Ticket>().Add(ticket);
    }
    public Ticket? GetById(Guid id)
    {
        return context.Set<Ticket>()
            .Include(t => t.Developers)
            .First(t => t.Id == id);
    }
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public void UpdateTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
