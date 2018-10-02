using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspCoreEF.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
