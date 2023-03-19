using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class TicketContext : DbContext
{
    //public DbSet<Ticket>? Tickets { get; set; }
    public DbSet<Ticket> Tickets => Set<Ticket>(); // from dbContext
    public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }
}
