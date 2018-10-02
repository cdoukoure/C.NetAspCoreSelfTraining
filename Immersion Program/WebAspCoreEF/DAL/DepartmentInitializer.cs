using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCoreEF.Models;

namespace WebAspCoreEF.DAL
{
    public class DepartmentInitializer 
    {
        public static void Initialize(EmployeeContext context)
        {

            var departments = new List<Department>
            {
                new Department{Title="Microsoft",Credits=3,},
                new Department{Title="Java",Credits=3,},
                new Department{Title="Php",Credits=4,}
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{FirstName="Ark",LastName="Roop",JoiningDate=DateTime.Parse("2005-09-01")},
                new Employee{FirstName="Akash",LastName="Gupta",JoiningDate=DateTime.Parse("2002-09-01")},
                new Employee{FirstName="Saurabh",LastName="Gupta",JoiningDate=DateTime.Parse("2003-09-01")},

            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{EmployeeId=1,DepartmentId=1,Band=Convert.ToDecimal(2.00)},
                new Enrollment{EmployeeId=2,DepartmentId=1,Band=Convert.ToDecimal(3.00)},
                new Enrollment{EmployeeId=3,DepartmentId=2,Band=Convert.ToDecimal(4.00)},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}
