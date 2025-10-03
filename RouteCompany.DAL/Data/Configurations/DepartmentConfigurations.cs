using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteCompany.DAL.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10); // to make the Identity start from 10 and increment by 10
            builder.Property(D => D.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(D => D.Code).HasColumnType("varchar(20)").IsRequired();
            builder.Property(D=> D.CreatedOn).HasDefaultValueSql(" GETDATE()"); // to make the default value of CreatedOn is the current date and time 
            builder.Property(D=> D.ModifiedOn).HasComputedColumnSql(" GETDATE()"); // to make the default value of ModifiedOn is the current date and time
            builder.HasMany(D => D.Employees)
                .WithOne(E => E.Department)
                .HasForeignKey(E => E.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);  // on removal the id go to null.
        }
    }
}
