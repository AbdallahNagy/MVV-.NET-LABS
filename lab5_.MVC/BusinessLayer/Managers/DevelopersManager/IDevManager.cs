using DataAccessLayer.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.DevelopersManager;

public interface IDevManager
{
    public IEnumerable<SelectListItem> GetAllDevelopers();
}
