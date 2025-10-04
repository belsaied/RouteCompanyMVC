using RouteCompany.DAL.Models.DepartmentModule;
using RouteCompany.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Models.EmployeeModule
{
    public class Employee : baseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = null!;

        [Range(24, 50, ErrorMessage = "Age should be between 24 and 50")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^\d+-[A-Za-z\s]+-[A-Za-z\s]+-[A-Za-z\s]+$",
            ErrorMessage = "Address should be in format: 123-Street-City-Country")]
        public string Address { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }       // "Male" or "Female"

        [Required(ErrorMessage = "Employee Type is required")]
        public EmployeeType EmployeeType { get; set; }  // "Parttime" or "Fulltime"

        public  virtual Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
