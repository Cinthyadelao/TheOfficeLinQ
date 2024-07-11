using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOffice.DataSource
{
    internal class ListEmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
    {
        new Employee { EmployeeId = 1, Name = "Michael Scott", DepartmentId = 1, Position = "Regional Manager" },
        new Employee { EmployeeId = 2, Name = "Jim Halpert", DepartmentId = 2, Position = "Sales Representative" },
        new Employee { EmployeeId = 3, Name = "Pam Beesly", DepartmentId = 3, Position = "Receptionist" },
        new Employee { EmployeeId = 4, Name = "Dwight Schrute", DepartmentId = 2, Position = "Assistant to the Regional Manager" },
        new Employee { EmployeeId = 5, Name = "Stanley Hudson", DepartmentId = 2, Position = "Sales Representative" },
        new Employee { EmployeeId = 6, Name = "Phyllis Vance", DepartmentId = 2, Position = "Sales Representative" },
        new Employee { EmployeeId = 7, Name = "Angela Martin", DepartmentId = 4, Position = "Accountant" },
        new Employee { EmployeeId = 8, Name = "Kevin Malone", DepartmentId = 4, Position = "Accountant" },
        new Employee { EmployeeId = 9, Name = "Oscar Martinez", DepartmentId = 4, Position = "Accountant" },
        new Employee { EmployeeId = 10, Name = "Ryan Howard", DepartmentId = 2, Position = "Temp" }
    };
    }
}
