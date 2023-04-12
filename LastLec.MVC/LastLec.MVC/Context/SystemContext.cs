using LastLec.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LastLec.MVC.Context;

public class SystemContext: IdentityDbContext<Employee>
{
	public SystemContext(DbContextOptions<SystemContext> options) : base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Employee>().ToTable("Employees");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims");
    }
}
