using RouteCompany.BLL.DTOs.DepartmentDTOs;

namespace RouteCompany.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreateDepartementDTO createDepartementDTO);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDetailsDTO? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO);
    }
}