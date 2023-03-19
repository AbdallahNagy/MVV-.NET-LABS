using DataAccessLayer.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.DepartmentsManager;

public interface IDeptManager
{
    public IEnumerable<SelectListItem> GetAllDepartments();
}
