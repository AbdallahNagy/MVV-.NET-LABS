using DataAccessLayer.Repositories.DevelopersRepo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.DevelopersManager;

public class DevManager : IDevManager
{
    private readonly IDevRepo DevRepo;

    public DevManager(IDevRepo devRepo)
    {
        DevRepo = devRepo;
    }
    public IEnumerable<SelectListItem> GetAllDevelopers()
    {
        var x = DevRepo.getAllDevelopers();
        return x.Select(d => new SelectListItem(d.FullName(), d.Id.ToString()));
    }
}