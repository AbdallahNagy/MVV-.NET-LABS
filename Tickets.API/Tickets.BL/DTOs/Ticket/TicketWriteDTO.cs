using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL;

namespace Tickets.BL;
public class TicketWriteDTO
{
    public string? Desc { get; set; }
    public int EstimationCost { get; set; }
}
