using Microsoft.EntityFrameworkCore;
using RouteCompany.DAL.Data.Configurations;
using RouteCompany.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Data.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Conn");

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            // (1) To Apply Configurations but i must do it for each entity
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // (2 ) Reflection to Apply All Configurations in the Assembly no need that Configuration classes are in the same assembly as the context
           //  modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            // (3) Reflection to Apply All Configurations in the Assembly that contains the context it must be in the same assembly as the context

        }
        public DbSet<Department> Departments { get; set; }
    }
}
