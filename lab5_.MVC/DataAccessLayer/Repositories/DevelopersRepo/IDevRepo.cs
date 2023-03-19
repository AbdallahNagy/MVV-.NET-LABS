using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.DevelopersRepo;

public interface IDevRepo
{
    IQueryable<Developer> getAllDevelopers();
    Developer? GetDeveloperBtId(Guid id);
}
