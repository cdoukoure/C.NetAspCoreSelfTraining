using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspCoreEF.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
