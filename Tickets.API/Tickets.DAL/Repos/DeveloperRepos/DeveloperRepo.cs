using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL;
public class DeveloperRepo : GenericRepo<Developer>, IDeveloperRepo
{
    public DeveloperRepo(TicketDbContext _context) : base(_context)
    {
    }
}
