using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.DepartmentDTOs
{
    public class UpdateDepartmentDTO
    {
        public int Dept_ID { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int ModifiedBy { get; set; }   
        public DateTime? ModifiedOn { get; set; }
    }
}
