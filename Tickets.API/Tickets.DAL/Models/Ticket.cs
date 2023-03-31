using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL;
public class Ticket
{
    public int Id { get; set; }
    public string? Desc { get; set; }
    public Severity? Severity { get; set; }
    public int EstimationCost { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    public Department? Department { get; set; }
}
