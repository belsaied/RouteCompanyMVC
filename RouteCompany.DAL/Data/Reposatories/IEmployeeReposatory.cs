using RouteCompany.DAL.Models;

namespace RouteCompany.DAL.Data.Reposatories
{
    public interface IEmployeeReposatory
    {
        int Create(Employee employee);
        int Delete(int id);
        IEnumerable<Employee> GetAll(bool withTracking = false);
        Employee? GetById(int id);
        int Update(Employee employee);
    }
}