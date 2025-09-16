using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.DepartmentDTOs
{
    public class DepartmentDetailsDTO
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }   // UserId
        public DateTime? CreatedOn { get; set; }   // the DateTime of Creating the Record. (Nullable because i'll put a default value for him in the configurations).
        public int ModifiedBy { get; set; }   // UserId
        public DateTime? ModifiedOn { get; set; }  // the DateTime of Modifying the Record. (Nullable because i'll put a default value for him in the configurations).
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
