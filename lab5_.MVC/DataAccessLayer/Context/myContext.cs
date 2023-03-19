using DataAccessLayer.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context;

public class myContext : DbContext
{
    public DbSet<Ticket> tickets => Set<Ticket>();
    public DbSet<Developer> developers => Set<Developer>();
    public DbSet<Department> departments => Set<Department>();

	public myContext(DbContextOptions options) : base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
