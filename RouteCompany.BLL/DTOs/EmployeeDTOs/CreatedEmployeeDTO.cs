﻿using RouteCompany.DAL.Models.EmployeeModule;
using RouteCompany.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.BLL.DTOs.EmployeeDTOs
{
    public class CreatedEmployeeDTO
    {
        [Required(ErrorMessage = "Name Can't Be Null")]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(3, ErrorMessage = "Min length should be 3 characters")]
        public string Name { get; set; } = null!;

        [Range(22, 35)]
        public int? Age { get; set; }

         [RegularExpression(@"^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",

            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
