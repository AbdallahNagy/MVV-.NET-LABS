using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;
public class TicketManager : ITicketManager
{
    private readonly ITicketRepo _ticketsRepo;

    public TicketManager(ITicketRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }
    public void Add(TicketWriteDTO ticketDTO)
    {
        var ticket = new Ticket
        {
            Desc = ticketDTO.Desc,
            EstimationCost = ticketDTO.EstimationCost,
            Severity = Severity.low
        };
        _ticketsRepo.Add(ticket);
    }
    public List<TicketReadDTO> GetAll()
    {
        var ticketsFormDb = _ticketsRepo.GetAll();
        return ticketsFormDb.Select(t => new TicketReadDTO
        {
            Desc = t.Desc,
            Severity = t.Severity,
            Id = t.Id
        }).ToList();
    }
}
