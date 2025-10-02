using RouteCompany.DAL.Models.EmployeeModule;
using RouteCompany.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Reposatories.Interfaces
{
    public interface IGenericReposatory<TEntity> where TEntity : baseEntity
    {
        int Create(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        TEntity? GetById(int id);
        int Update(TEntity entity);
    }
}
