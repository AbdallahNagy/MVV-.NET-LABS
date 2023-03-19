using DataAccessLayer.DomainModels;
using DataAccessLayer.Repositories.DepartmentsRepo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.DepartmentsManager;

public class DeptManager : IDeptManager
{
    private readonly IDeptRepo DeptRepo;

    public DeptManager(IDeptRepo _deptRepo)
    {
        DeptRepo = _deptRepo;
    }
    public IEnumerable<SelectListItem> GetAllDepartments()
    {
        var x = DeptRepo.getAllDepartments();
        return x.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
    }
}
