using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.DepartmentDTOs
{
    public class CreateDepartementDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="Code is Required!!")]
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DateOfCreation { get; set; }
    }
}
