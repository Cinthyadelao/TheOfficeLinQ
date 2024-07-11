using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOffice.DataSource
{
    internal class ListDepartmentData
    {
        public static List<Department> Departments = new List<Department>
    {
        new Department { DepartmentId = 1, Name = "Management" },
        new Department { DepartmentId = 2, Name = "Sales" },
        new Department { DepartmentId = 3, Name = "Reception" },
        new Department { DepartmentId = 4, Name = "Accounting" },
    };
    }
}
