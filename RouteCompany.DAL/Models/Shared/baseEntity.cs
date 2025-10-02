using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCompany.DAL.Models.Shared
{
    public class baseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }   // UserId
        public DateTime? CreatedOn { get; set; }   // the DateTime of Creating the Record. (Nullable because i'll put a default value for him in the configurations).
        public int ModifiedBy { get; set; }   // UserId
        public DateTime? ModifiedOn { get; set; }  // the DateTime of Modifying the Record. (Nullable because i'll put a default value for him in the configurations).
        public bool IsDeleted { get; set; }   // to make a soft delete for the record instead of hard delete.
    }
}
