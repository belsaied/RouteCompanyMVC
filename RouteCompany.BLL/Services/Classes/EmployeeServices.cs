using AutoMapper;
using RouteCompany.BLL.DTOs.EmployeeDTOs;

using RouteCompany.BLL.Services.Interfaces;
using RouteCompany.DAL.Data.Reposatories.Interfaces;
using RouteCompany.DAL.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.Services.Classes
{
    public class EmployeeServices(IEmployeeReposatory _employeeReposatory ,IMapper _mapper) : IEmployeeServices
    {
        // GetAll
        public IEnumerable<AllEmployeesDTO> GetAllEmployees(bool withTarcking = false)
        {
            var employee = _employeeReposatory.GetAll(withTarcking);
            // mapping to DTo
            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<AllEmployeesDTO>>(employee);
            #region Manual mapping
            //var employeeDto = employee.Select(e => new AllEmployeesDTO()
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Salary = e.Salary,
            //    IsActive = e.IsActive,
            //    Email = e.Email,
            //    Gender = e.Gender.ToString(),
            //    EmployeeType = e.EmployeeType.ToString(),
            //}); 
            #endregion
            return employeeDto;
        }
        // GetById
        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var result = _employeeReposatory.GetById(id);
            return result is null ? null : _mapper.Map<Employee, EmployeeDetailsDTO>(result);


            #region Manual Mapping.
            // Map 
            //return new EmployeeDetailsDTO()
            //{
            //    Id = result.Id,
            //    Name = result.Name,
            //    Age = result.Age,
            //    Salary = result.Salary,
            //    IsActive = result.IsActive,
            //    Email = result.Email,
            //    Gender = result.Gender.ToString(),
            //    EmployeeType = result.EmployeeType.ToString(),
            //    PhoneNumber = result.PhoneNumber,
            //    HiringDate = DateOnly.FromDateTime(result.HiringDate),
            //    CreatedBy = 1,
            //    CreatedOn = result.CreatedOn,
            //    ModifiedBy = 1,
            //    ModifiedOn = result.ModifiedOn,
            //}; 
            #endregion

        }
        // Create.
        public int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO)
        {
           var employee = _mapper.Map<CreatedEmployeeDTO,Employee>(createdEmployeeDTO);
            return _employeeReposatory.Create(employee);
        }
        // Update
        public int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO)
        {
            var employee = _mapper.Map<UpdatedEmployeeDTO, Employee>(updatedEmployeeDTO);
            return _employeeReposatory.Update(employee);
        }
        // Delete
        public bool DeleteEmployee(int id)
        {
            // soft Delete [IsDelted = True]
            var employee = _employeeReposatory.GetById(id);
            if(employee is null) return false;
            else
            {
                employee. IsDeleted = true;
                return _employeeReposatory.Update(employee)> 0 ? true : false;
            }
        }

        

    }

}
 