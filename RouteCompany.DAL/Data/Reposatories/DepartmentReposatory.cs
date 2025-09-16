using Microsoft.EntityFrameworkCore;
using RouteCompany.DAL.Data.Contexts;
using RouteCompany.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Reposatories
{
    public class DepartmentReposatory(AppDbContext _dbContext) : IDepartmentReposatory
    {

        // 5 CRUD Operations
        // GetAll
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.Where(d => !d.IsDeleted).ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().Where(d => !d.IsDeleted).ToList();
            }
        }
        // GetById
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
        // Create
        public int Create(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
        // Delete (Soft Delete)
        public int Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department != null)
            {
                department.IsDeleted = true;
                _dbContext.Departments.Update(department);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

    }
}
