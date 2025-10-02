using RouteCompany.BLL.DTOs.EmployeeDTOs;

namespace RouteCompany.BLL.Services.Interfaces
{
    public interface IEmployeeServices
    {
        int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO);
        bool DeleteEmployee(int id);
        IEnumerable<AllEmployeesDTO> GetAllEmployees(bool withTarcking = false);
        EmployeeDetailsDTO? GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO);
    }
}