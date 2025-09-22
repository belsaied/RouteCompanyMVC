using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.EmployeeDTOs
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime HiringDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string EmployeeType { get; set; } = string.Empty;
    }
}
