using Microsoft.EntityFrameworkCore;
using RouteCompany.DAL.Data.Contexts;
using RouteCompany.DAL.Data.Reposatories.Interfaces;
using RouteCompany.DAL.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Reposatories.Classes
{
    public class DepartmentReposatory(AppDbContext _dbContext):GenericReposatory<Department>(_dbContext) ,IDepartmentReposatory
    {

    }
}
