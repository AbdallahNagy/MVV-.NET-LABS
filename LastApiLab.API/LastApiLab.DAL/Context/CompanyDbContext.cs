using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastApiLab.DAL.Context;
public class CompanyDbContext : IdentityDbContext<Employee>
{
    public DbSet<Department> Departments { get; set; }
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().ToTable("Employees");
        //modelBuilder.Entity<Employee>().Property(e => e.DepartmentId).IsRequired(false);
    }
}
