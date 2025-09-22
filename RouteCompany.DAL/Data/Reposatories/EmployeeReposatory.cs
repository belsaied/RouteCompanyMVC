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
    public class EmployeeReposatory(AppDbContext _dbContext) : IEmployeeReposatory
    {

        // Get All
        public IEnumerable<Employee> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Employees.Where(e => !e.IsDeleted).ToList();
            }
            else
            {
                return _dbContext.Employees.AsNoTracking().Where(e => !e.IsDeleted).ToList();
            }
        }
        // Get By Id
        public Employee? GetById(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return employee;
        }
        // Create
        public int Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return _dbContext.SaveChanges();
        }
        // Delete
        public int Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                employee.IsDeleted = true;
                _dbContext.Employees.Update(employee);
                return _dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
