using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.DepartmentsRepo;

public interface IDeptRepo
{
    IQueryable<Department> getAllDepartments();
    Department? GetDepartmentById(Guid id);
}
