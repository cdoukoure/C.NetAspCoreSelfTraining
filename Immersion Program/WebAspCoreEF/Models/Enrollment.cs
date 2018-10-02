using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspCoreEF.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public decimal? Band { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
