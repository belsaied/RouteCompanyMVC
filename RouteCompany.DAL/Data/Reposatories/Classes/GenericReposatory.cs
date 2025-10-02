using Microsoft.EntityFrameworkCore;
using RouteCompany.DAL.Data.Contexts;
using RouteCompany.DAL.Data.Reposatories.Interfaces;
using RouteCompany.DAL.Models.DepartmentModule;
using RouteCompany.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Reposatories.Classes
{
    public class GenericReposatory<TEntity>(AppDbContext _dbContext) : IGenericReposatory<TEntity> where TEntity : baseEntity
    {
        // 5 CRUD Operations
        // GetAll
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false).ToList();  // for soft Delete.
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted==false).AsNoTracking().ToList();
            }
        }
        // GetById
        public TEntity? GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
            
        }
        // Create
        public int Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
        //  Hard Delete (don't have a use in this context as i apply soft delete in the services so i use Update.)
        #region SoftDelete
        //public int Delete(int id)
        //{
        //    var department = _dbContext.Departments.Find(id);
        //    if (department != null)
        //    {
        //        department.IsDeleted = true;
        //        _dbContext.Departments.Update(department);
        //        return _dbContext.SaveChanges();
        //    }
        //    return 0;
        //} 
        #endregion

        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
