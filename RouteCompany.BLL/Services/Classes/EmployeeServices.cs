using RouteCompany.BLL.DTOs.EmployeeDTOs;
using RouteCompany.BLL.Factories;
using RouteCompany.BLL.Services.Interfaces;
using RouteCompany.DAL.Data.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.Services.Classes
{
    public class EmployeeServices(IEmployeeReposatory employeeReposatory) : IEmployeeServices
    {
        private readonly IEmployeeReposatory _employeeReposatory = employeeReposatory;

        // Get All Employees
        public IEnumerable<AllEmployeesDTO> GetAllEmployees()
        {
            var employees = _employeeReposatory.GetAll();
            var employeesDTO = employees.Select(e => new AllEmployeesDTO
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Age = e.Age,
                IsActive = e.IsActive,
                Salary = e.Salary,
                Gender = e.Gender,
                EmployeeType = e.EmployeeType
            });
            return employeesDTO;
        }

        // Get Employee By Id
        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var employee = _employeeReposatory.GetById(id);
            if (employee == null || employee.IsDeleted) return null;

            return new EmployeeDetailsDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType
            };
        }

        // Create Employee

        public int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO)
        {
            var employee = createdEmployeeDTO.ToEntity();
            return _employeeReposatory.Create(employee);
        }

        // Update Employee
        public int UpdateEmployee(CreatedEmployeeDTO updatedEmployeeDTO)
        {
            return _employeeReposatory.Update(updatedEmployeeDTO.ToEntity());
        }

        // Delete Employee
        public int DeleteEmployee(int id)
        {
            return _employeeReposatory.Delete(id);
        }
    }

}
