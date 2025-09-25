using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.DepartmentDTOs
{
    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }   // for Update in Post.
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
