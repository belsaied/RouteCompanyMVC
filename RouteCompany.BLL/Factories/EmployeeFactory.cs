using RouteCompany.BLL.DTOs.EmployeeDTOs;
using RouteCompany.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.Factories
{
    public static class EmployeeFactory
    {
        //Create Employee
        public static Employee ToEntity(this CreatedEmployeeDTO createdEmployeeDTO)
        {
            return new Employee
            {
                Name = createdEmployeeDTO.Name,
                Age = createdEmployeeDTO.Age,
                Address = createdEmployeeDTO.Address,
                IsActive = createdEmployeeDTO.IsActive,
                Salary = createdEmployeeDTO.Salary,
                Email = createdEmployeeDTO.Email,
                PhoneNumber = createdEmployeeDTO.PhoneNumber,
                HiringDate = createdEmployeeDTO.HiringDate,
                Gender = createdEmployeeDTO.Gender,
                EmployeeType = createdEmployeeDTO.EmployeeType,
                CreatedBy = createdEmployeeDTO.CreratedBy,
                ModifiedBy = createdEmployeeDTO.LastModifiedBy,
            };
}

        // Update Employee
        public static Employee ToEntity(this UpdatedEmployeeDTO Up)
        {
            return new Employee
            {
                Id = Up.Id,
                Name = Up.Name,
                Age = Up.Age,
                Address = Up.Address,
                IsActive = Up.IsActive,
                Salary = Up.Salary,
                Email = Up.Email,
                PhoneNumber = Up.PhoneNumber,
                HiringDate = Up.HiringDate,
                Gender = Up.Gender,
                EmployeeType = Up.EmployeeType,
                ModifiedBy = Up.LastModifiedBy,

            };
        }
    }
}
