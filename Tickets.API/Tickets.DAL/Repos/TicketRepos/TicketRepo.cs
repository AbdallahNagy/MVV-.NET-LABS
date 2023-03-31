using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL;
public class TicketRepo : GenericRepo<Ticket>, ITicketRepo
{
    public TicketRepo(TicketDbContext _context) : base(_context)
    {
    }
}
