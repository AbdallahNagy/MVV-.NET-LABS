using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL;
public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
{
    public DepartmentRepo(TicketDbContext _context) : base(_context)
    {
    }
}
