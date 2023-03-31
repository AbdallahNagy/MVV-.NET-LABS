using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL; 
public class TicketReadDTO 
{
    public int Id { get; set; }
    public string? Desc { get; set; }
    public Severity? Severity { get; set; }
}
