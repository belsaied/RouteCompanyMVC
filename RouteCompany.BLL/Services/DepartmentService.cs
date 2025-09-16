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
    }
}
