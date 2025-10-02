using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteCompany.DAL.Models.EmployeeModule;
using RouteCompany.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Primary Key
            builder.HasKey(e => e.Id);

            // Employee-specific properties
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Employee full name with maximum 50 characters");

            builder.Property(e => e.Age)
                .IsRequired()
                .HasComment("Employee age - must be between 24 and 50");

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200)
                .HasComment("Employee address in format: 123-Street-City-Country");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("Indicates if employee is currently active");

            builder.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasComment("Employee salary with 2 decimal places");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Employee email address - must be unique");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasComment("Employee phone number");

            builder.Property(e => e.HiringDate)
                .IsRequired()
                .HasColumnType("date")
                .HasComment("Date when employee was hired");
            // As the database can't understand the Enum i must do a conversion by mapping and then parse it into string.
            builder.Property(e => e.Gender).HasConversion(
                (empGender) => empGender.ToString(),
                (gender) => (Gender)Enum.Parse(typeof(Gender), gender));

            builder.Property(e => e.EmployeeType).HasConversion(
                (empType) => empType.ToString(),
                (employoyeetype) => (EmployeeType)Enum.Parse(typeof(EmployeeType), employoyeetype));

            builder.Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Record creation timestamp");

            builder.Property(e=> e.ModifiedOn)
                .HasComputedColumnSql("GETDATE()")
                .HasComment("Record last modification timestamp");

            
        }
    }
}
