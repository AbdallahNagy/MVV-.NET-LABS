using DataAccessLayer.Context;
using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.DevelopersRepo;

public class DevRepo : IDevRepo
{
    private readonly myContext context;

    public DevRepo(myContext _context)
	{
		context = _context;
	}

    public IQueryable<Developer> getAllDevelopers()
    {
        return context.Set<Developer>();
    }

    public Developer? GetDeveloperBtId(Guid id)
    {
        return context.Set<Developer>().Find(id);
    }
}
