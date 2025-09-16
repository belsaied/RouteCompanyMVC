using RouteCompany.DAL.Models;

namespace RouteCompany.DAL.Data.Reposatories
{
    public interface IDepartmentReposatory
    {
        int Create(Department department);
        int Delete(int id);
        IEnumerable<Department> GetAll(bool withTracking = false);
        Department? GetById(int id);
        int Update(Department department);
    }
}