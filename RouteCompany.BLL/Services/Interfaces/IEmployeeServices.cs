using RouteCompany.BLL.DTOs.EmployeeDTOs;

namespace RouteCompany.BLL.Services.Interfaces
{
    public interface IEmployeeServices
    {
        int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO);
        int DeleteEmployee(int id);
        IEnumerable<AllEmployeesDTO> GetAllEmployees();
        EmployeeDetailsDTO? GetEmployeeById(int id);
        int UpdateEmployee(CreatedEmployeeDTO updatedEmployeeDTO);
    }
}