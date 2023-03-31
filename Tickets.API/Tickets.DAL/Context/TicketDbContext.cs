using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL;
public class TicketDbContext: DbContext
{
    public DbSet<Department> Department { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<Developer> Developer{ get; set; }

    public TicketDbContext(DbContextOptions<TicketDbContext> options): base(options)
	{
			
	}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
