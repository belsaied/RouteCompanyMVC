using RouteCompany.BLL.DTOs.DepartmentDTOs;
using RouteCompany.BLL.Services.Interfaces;
using RouteCompany.DAL.Data.Reposatories.Interfaces;
using RouteCompany.DAL.Models;
using RouteCompany.DAL.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.Services.Classes
{
    public class DepartmentService(IDepartmentReposatory _departmentReposatory) : IDepartmentService
    {
        private readonly IDepartmentReposatory departmentReposatory = _departmentReposatory;

        // GET ALL => Data Part Only => No Logic
        public IEnumerable<DepartmentDTO> GetAllDepartments()
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

        // Add:
        public int AddDepartment(CreateDepartementDTO createDepartementDTO)
        {
            var department = new Department()
            {
                //Id = createDepartementDTO.ID,
                Name = createDepartementDTO.Name,
                Code = createDepartementDTO.Code,
                Description = createDepartementDTO.Description,
                CreatedOn = createDepartementDTO.DateOfCreation
            };

            return departmentReposatory.Create(department);
            
        }

        // Update:
        public int UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO)
        {
            return departmentReposatory.Update(new Department()
            {
                Id = updateDepartmentDTO.Id,
                Name = updateDepartmentDTO.Name,
                Code = updateDepartmentDTO.Code,
                Description = updateDepartmentDTO.Description,
                CreatedOn = updateDepartmentDTO.CreatedOn,
            });
        }

        // Delete 
        public bool DeleteDepartment(int id)
        {
            var departments = departmentReposatory.GetById(id);
            if (departments == null) return false;
            else
            {
                departments.IsDeleted=true;
                return departmentReposatory.Update(departments) > 0 ? true : false;
            }

        }
    }
}
