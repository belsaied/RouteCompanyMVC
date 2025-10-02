using Microsoft.EntityFrameworkCore;
using RouteCompany.DAL.Data.Contexts;
using RouteCompany.DAL.Data.Reposatories.Interfaces;
using RouteCompany.DAL.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Reposatories.Classes
{
    public class EmployeeReposatory(AppDbContext _dbContext) : GenericReposatory<Employee>(_dbContext), IEmployeeReposatory
    {

    }
}
