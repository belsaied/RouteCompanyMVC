using RouteCompany.BLL.DTOs.DepartmentDTOs;
using RouteCompany.DAL.Data.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentReposatory departmentReposatory;

        // depend on DepartmentReposatory to do the operations
        // inject DepartmentReposatory
        public DepartmentService(DepartmentReposatory _departmentReposatory)
        {
            departmentReposatory = _departmentReposatory;
        }

        // GET ALL => Data Part Only => No Logic
        public IEnumerable<DepartmentDTO> GetAllDepartments ()
        {
                       var departments = departmentReposatory.GetAll();
            // Map from Department to DepartmentDTO
            var departmentsDTO = departments.Select(d => new DepartmentDTO
            {
                DeptID = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = d.CreatedOn
            });
            return departmentsDTO;
        }

        // GET BY ID.
public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = departmentReposatory.GetById(id);
            if (department == null)
            {
                return null;
            }
            // Map from Department to DepartmentDetailsDTO
            var departmentDetailsDTO = new DepartmentDetailsDTO
            {
                Id = department.Id,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                ModifiedBy = department.ModifiedBy,
                ModifiedOn = department.ModifiedOn,
                IsDeleted = department.IsDeleted,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description
            };
            return departmentDetailsDTO;
        }



    }
}
