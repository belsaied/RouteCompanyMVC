using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Models
{
    public class Department:baseEntity
    {
        public string Name { get; set; }= null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
      
    }
}
