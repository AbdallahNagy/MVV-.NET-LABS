using DataAccessLayer.Context;
using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.DepartmentsRepo;

public class DeptRepo : IDeptRepo
{
    private readonly myContext context;

    public DeptRepo(myContext _context)
	{
		context = _context;
	}

    public IQueryable<Department> getAllDepartments()
    {
        return context.Set<Department>();
    }

    public Department? GetDepartmentById(Guid id)
    {
        return context.Set<Department>().Find(id);
    }
}
