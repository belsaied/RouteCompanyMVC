using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.DepartmentDTOs
{
    public class DepartmentDTO
    {
        public int DeptID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public DateTime? DateOfCreation { get; set; }  // to show when the department was created
    }
}
